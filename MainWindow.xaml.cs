using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _19._09_2_zad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isDrawing;
        private Ellipse currentShape;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void DrawingCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (DrawMode.IsChecked == true)
            {
                isDrawing = true;
                currentShape = new Ellipse
                {
                    Fill = GetSelectedColor(),
                    Width = BrushSizeSlider.Value,
                    Height = BrushSizeSlider.Value
                };
                Canvas.SetLeft(currentShape, e.GetPosition(DrawingCanvas).X);
                Canvas.SetTop(currentShape, e.GetPosition(DrawingCanvas).Y);
                DrawingCanvas.Children.Add(currentShape);
            }
        }

        private void DrawingCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing && DrawMode.IsChecked == true)
            {
                Canvas.SetLeft(currentShape, e.GetPosition(DrawingCanvas).X - currentShape.Width / 2);
                Canvas.SetTop(currentShape, e.GetPosition(DrawingCanvas).Y - currentShape.Height / 2);
            }
        }

        private Brush GetSelectedColor()
        {
            switch (ColorPicker.Text)
            {
                case "Red": return Brushes.Red;
                case "Green": return Brushes.Green;
                case "Blue": return Brushes.Blue;
                default: return Brushes.Black;
            }
        }
    }


}
