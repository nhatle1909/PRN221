using Assimp;
using HelixToolkit.Wpf;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;

namespace Convert3DObject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        string? filePath;
        string? fileExtension;

        public Model3D model = null;
        public MainMenu()
        {
            InitializeComponent();
            FileURL.IsReadOnly = true;
            ExtensionList.Items.Add("STL");
            ExtensionList.Items.Add("OBJ");
            ExtensionList.Items.Add("FBX");
            ExtensionList.Items.Add("GLTF");
            ExtensionList.Items.Add("GLB");

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
    }
}