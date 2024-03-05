using Assimp;
using Convert3DObject.Models;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using HelixToolkit.Wpf;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Convert3DObject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        string? filePath;
        string? fileExtension;
        string pattern = @"^[a-zA-Z0-9\s]+$";

        public Model3D model = null;
        private DriveService _driveService;
        private GGDrive GGDrive;
        private List<FolderDrive> folderDrives = new List<FolderDrive>();
        private string FileUpload;
        private readonly string ParentFolder = "1oTWK5ovrP4zEDmfy-spYlYX2YxrnrCc3";


        public MainMenu()
        {
            InitializeComponent();
            FileURL.IsReadOnly = true;
            ExtensionList.Items.Add("STL");
            ExtensionList.Items.Add("OBJ");
            ExtensionList.Items.Add("FBX");
            ExtensionList.Items.Add("GLTF");
            ExtensionList.Items.Add("GLB");

            InitServiceDrive();
            GGDrive = new GGDrive(_driveService);
            GetFolderName();
        }

        private void InitServiceDrive()
        {
            GoogleCredential credential;
            using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream).CreateScoped(new[]
                {
                DriveService.ScopeConstants.Drive,
                DriveService.ScopeConstants.DriveFile
            });
            }

            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "DriveServiceApp"
            });
            _driveService = service;
        }

        private async void GetFolderName()
        {
            var folders = await GGDrive.GetDriveFolders();

            folderDrives.Clear();
            foreach (var item in folders)
            {
                if (item.Id != ParentFolder)
                {
                    folderDrives.Add(new FolderDrive { Id = item.Id, Name = item.Name });
                }
            }
            cbFolder.ItemsSource = null;
            cbFolder.ItemsSource = folderDrives;
            cbFolder.DisplayMemberPath = "Name";
            cbFolder.SelectedValuePath = "Id";
        }

        private void Browser_Click(object sender, RoutedEventArgs e) //Finish
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                FileURL.Text = dialog.FileName;
                filePath = dialog.FileName;
            }
        }
        private void Convert_Click(object sender, RoutedEventArgs e) // Finish
        {
            Validation(fileExtension, filePath);
            Convert3DFile(fileExtension, filePath);
        }
        private void ExtensionList_SelectionChanged(object sender, SelectionChangedEventArgs e) // Finish
        {
            fileExtension = ExtensionList.SelectedItem.ToString();

        }
        private void Convert3DFile(string fileExtention, string filepath) //Finish
        {
            string outputPath = Path.GetDirectoryName(filePath) + "\\" + Path.GetFileNameWithoutExtension(filePath) + "." + fileExtension.ToLower();
            var scene = new AssimpContext();
            var model = scene.ImportFile(filepath);

            scene.ExportFile(model, outputPath, fileExtention.ToLower());
        }
        public void Validation(string fileExtenstion, string filePath)
        {
            if (filePath == null || filePath.Equals(""))
            {
                System.Windows.MessageBox.Show("Invalid File Path");
                return;
            }
            if (fileExtension == null || fileExtension.Equals(""))
            {
                System.Windows.MessageBox.Show("Please choose output file extension");
                return;
            }
        }
        public void LoadModel(string path)
        {
            if (filePath == null || filePath.Equals(""))
            {
                System.Windows.MessageBox.Show("Invalid File Path");
                return;
            }

            if (Path.GetExtension(path).ToLower().Equals(".obj") || Path.GetExtension(path).ToLower().Equals(".stl"))
            {
                ModelImporter import = new ModelImporter();
                model = import.Load(path);
                _3DModelPreview preview = new _3DModelPreview(model);
                preview.Show();
                return;
            }
            else
            {
                System.Windows.MessageBox.Show("Only support preview OBJ and STL file");
                return;
            }
        }
        private void Preview_Click(object sender, RoutedEventArgs e)
        {
            LoadModel(filePath);
        }

        private async void btnCreateDriveFolder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txbNameDriveFolder.Text))
                {
                    System.Windows.Forms.MessageBox.Show("Folder name is required");
                    return;
                }

                if (!(Regex.IsMatch(txbNameDriveFolder.Text, pattern)))
                {
                    System.Windows.Forms.MessageBox.Show("No special character please");
                    return;
                }
                if (!(await CheckName(txbNameDriveFolder.Text)))
                {
                    System.Windows.Forms.MessageBox.Show("Folder name duplicated");
                    txbNameDriveFolder.Text = "";
                    return;
                }
                if (await GGDrive.CreateFolder(txbNameDriveFolder.Text, ParentFolder))
                {
                    System.Windows.Forms.MessageBox.Show("Created successful folder " + txbNameDriveFolder.Text);
                    txbNameDriveFolder.Text = "";
                    GetFolderName();
                    await Task.Delay(2000);
                    return;
                }
                System.Windows.Forms.MessageBox.Show("Create failed");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Create failed");
            }
        }

        private async Task<bool> CheckName(string name)
        {
            var folders = new List<Google.Apis.Drive.v3.Data.File>();

            var listRequest = _driveService.Files.List();
            listRequest.PageSize = 10;
            listRequest.Q = "mimeType='application/vnd.google-apps.folder'";

            do
            {
                var fileList = await listRequest.ExecuteAsync();
                folders.AddRange(fileList.Files);
                listRequest.PageToken = fileList.NextPageToken;
            } while (listRequest.PageToken != null);

            foreach (var item in folders)
            {
                if (item.Name == name) return false;
            }
            return true;
        }

        private async void btnUpload_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(FileUpload) || !File.Exists(FileUpload))
                {
                    System.Windows.Forms.MessageBox.Show("Not found file to upload");
                    return;
                }
                if (cbFolder.SelectedItem != null)
                {
                    if (await GGDrive.UpLoadToGGDrive(cbFolder.SelectedValue + "", FileUpload))
                    {
                        System.Windows.Forms.MessageBox.Show($"Uploaded file {lbNameFileDrive.Content} successful");
                    }
                }
                else
                {
                    if (await GGDrive.UpLoadToGGDrive(ParentFolder, FileUpload))
                    {
                        System.Windows.Forms.MessageBox.Show($"Uploaded file {lbNameFileDrive.Content} successful");
                    }
                }
                lbNameFileDrive.Content = "";
                FileUpload = "";
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Not found file to upload");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                lbNameFileDrive.Content = openFile.FileName.Substring(openFile.FileName.LastIndexOf("\\") + 1);
                FileUpload = openFile.FileName;
            }
            else
            {
                FileUpload = "";
                lbNameFileDrive.Content = "";
            }
        }
    }

    public class GGDrive
    {
        private readonly DriveService _driveService;

        public GGDrive(DriveService driveService)
        {
            _driveService = driveService;
        }
        public async Task<bool> UpLoadToGGDrive(string folderId, string fileToUpLoad)
        {
            var metadataFile = new Google.Apis.Drive.v3.Data.File()
            {
                Name = Path.GetFileName(fileToUpLoad),
                Parents = new List<string>
                {
                    folderId
                }
            };
            FilesResource.CreateMediaUpload request;
            using (var streams = new FileStream(fileToUpLoad, FileMode.Open))
            {
                request = _driveService.Files.Create(metadataFile, streams, "");
                request.Fields = "id";
                await request.UploadAsync();
            }
            return request.ResponseBody.Id + "" != "";
        }

        public async Task<bool> CreateFolder(string folderName, string parentFolderId = null)
        {

            var folderMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = folderName,
                MimeType = "application/vnd.google-apps.folder"
            };

            if (!string.IsNullOrEmpty(parentFolderId))
            {
                folderMetadata.Parents = new List<string> { parentFolderId };
            }

            var request = _driveService.Files.Create(folderMetadata);
            request.Fields = "id";

            var createdFolder = await request.ExecuteAsync();

            return createdFolder.Id + "" != "";
        }

        public async Task<List<Google.Apis.Drive.v3.Data.File>> GetDriveFolders()
        {
            var folders = new List<Google.Apis.Drive.v3.Data.File>();

            var listRequest = _driveService.Files.List();
            listRequest.PageSize = 10;
            listRequest.Q = "mimeType='application/vnd.google-apps.folder'";
            do
            {
                var fileList = await listRequest.ExecuteAsync();
                folders.AddRange(fileList.Files);
                listRequest.PageToken = fileList.NextPageToken;
            } while (listRequest.PageToken != null);

            return folders;
        }
    }
}