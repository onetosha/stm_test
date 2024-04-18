using System;
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
using System.Windows.Threading;

namespace stm_test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BallContainer ballContainer;
        private DispatcherTimer animationTimer;
        SolidColorBrush magicBrush;

        public MainWindow()
        {
            InitializeComponent();
            animationTimer = new DispatcherTimer();
            animationTimer.Interval = TimeSpan.FromMilliseconds(20);
            animationTimer.Tick += animationTimer_Tick;

            magicBrush = (SolidColorBrush)this.Resources["magicBrush"];

            ballContainer = new BallContainer();
        }

        private void animationTimer_Tick(object? sender, EventArgs e)
        {
            ballContainer.UpdateBalls(canvas.ActualWidth, canvas.ActualHeight);
        }

        private void canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point position = e.GetPosition(canvas);

            if (IsPositionInsideCanvas(position, radiusSlider.Value))
            {
                canvas.Children.Add(ballContainer.AddBall(position, radiusSlider.Value, new SolidColorBrush(magicBrush.Color)).Shape);
            }
        }

        private bool IsPositionInsideCanvas(Point position, double radius)
        {
            double leftLimit = radius;
            double rightLimit = canvas.ActualWidth - radius;
            double topLimit = radius;
            double bottomLimit = canvas.ActualHeight - radius;

            return position.X >= leftLimit && position.X <= rightLimit && position.Y >= topLimit && position.Y <= bottomLimit;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if ((redSlider != null) && (greenSlider != null) && (blueSlider != null))
            {
                magicBrush.Color = Color.FromRgb((byte)redSlider.Value, (byte)greenSlider.Value, (byte)blueSlider.Value);
            }
        }

        private void btnClear(object sender, RoutedEventArgs e)
        {
            ballContainer.Clear();
            canvas.Children.Clear();
        }

        private void btnStartStopAnimation_Click(object sender, RoutedEventArgs e)
        {
            if (animationTimer.IsEnabled)
            {
                animationTimer.Stop();
                btnStartStopAnimation.Content = "Запустить анимацию";
            }
            else
            {
                animationTimer.Start();
                btnStartStopAnimation.Content = "Приостановить анимацию";
            }
        }
    }
}