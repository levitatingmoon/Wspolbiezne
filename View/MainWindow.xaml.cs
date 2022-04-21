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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Windows.Threading;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

        }
        /*
        private void Button_Click(object sender, RoutedEventArgs e)

        {
            string NumberTextBoxString = NumberTextBox.Text;
            if (NumberTextBoxString == "") {
                NumberTextBoxString = "1";
            }
            if ((string)ButtonStart.Content == "Start")
            {
                ButtonStart.Content = "Restart";
                DrawCircles(CanvasBox, Int32.Parse(NumberTextBoxString));
            }
            else {
                DrawCircles(CanvasBox, Int32.Parse(NumberTextBoxString));
            }

        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        //viewmodel
        public void DrawCircles(Canvas MyCanvas, int numberOfCircles)
        {
            Random rnd = new Random();
            for (int j = 0; j < numberOfCircles; j++)
            {
                Ellipse circle = new Ellipse();
                circle.Height = 30;
                circle.Width = 30;
                int x = rnd.Next(15, 770);
                int y = rnd.Next(15, 270);
                Canvas.SetLeft(circle, x);
                Canvas.SetTop(circle, y);
                circle.Fill = new SolidColorBrush(Colors.Red);

                MyCanvas.Children.Add(circle);


            }
        }
        */
    }
}
