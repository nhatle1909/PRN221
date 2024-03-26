using HelixToolkit.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace Convert3DObject.Views
{
    /// <summary>
    /// Interaction logic for _3DModelView.xaml
    /// </summary>
    public partial class _3DModelView : Window
    {
        public Model3D _model;

        public _3DModelView(Model3D model)
        {
            InitializeComponent();
            _model = model;
            DisplayModel();
            CompositionTarget.Rendering += OnRendering;
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            this.Owner.Show();
        }

        public void DisplayModel()
        {
            ModelVisual3D modelVisual = new ModelVisual3D();
            modelVisual.Content = _model;

            viewPort3d.Children.Add(modelVisual);
            viewPort3d.Camera.UpDirection = new Vector3D(0, 1, 0);
        }

        private void OnRendering(object sender, EventArgs e)
        {
            if (viewPort3d.Camera is PerspectiveCamera camera)
            {
                var position = camera.Position;
                var lookDirection = camera.LookDirection;
                var upDirection = camera.UpDirection;

                // Display the camera's position and orientation
                Rotation.Text = $"Position: {position}, LookDirection: {lookDirection}, UpDirection: {upDirection}";
            }
        }


    }
}
