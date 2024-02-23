
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

namespace Convert3DObject
{
    /// <summary>
    /// Interaction logic for _3DModelPreview.xaml
    /// </summary>
    public partial class _3DModelPreview : Window
    {
        public Model3D _model;
        
        public _3DModelPreview(Model3D model)
        {
            InitializeComponent();
            _model = model;
            DisplayModel();
        }

        public void DisplayModel()
        {
            ModelVisual3D modelVisual = new ModelVisual3D();
            modelVisual.Content = _model;

            viewPort3d.Children.Add(modelVisual);
            viewPort3d.Camera.UpDirection = new Vector3D(0, 1, 0);
        }
    }
}
