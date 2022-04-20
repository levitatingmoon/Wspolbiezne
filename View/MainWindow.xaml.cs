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
        int speed = 5;
        DispatcherTimer MoveTimer = new DispatcherTimer();


        public MainWindow()
        {
            InitializeComponent();

            MoveTimer.Tick += MoveTimerEvent;
            MoveTimer.Interval = TimeSpan.FromMilliseconds(20);
            MoveTimer.Start();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonStart.Content == "Start")
            {
                ButtonStart.Content = "Restart";
            }
            else {
                ButtonStart.Content = "Start";
            }

            string NumberTextBoxString = NumberTextBox.Text;

            DrawCircles(CanvasBox, Int32.Parse(NumberTextBoxString));
        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

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


        private void MoveTimerEvent(object sender, EventArgs e)
        {
            Random random = new Random();
            int x = random.Next(15, 770);
            int y = random.Next(15, 270);
            Canvas.SetLeft(circle, x - speed);
            Canvas.SetTop(circle, y - speed);

            if (Canvas.GetLeft(circle) == x && Canvas.GetTop(circle) == y)
            {
                MoveTimerEvent(sender,e);
            }
        }
    }
}
