using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;

namespace stm_test
{
    public class Ball
    {
        public double Radius { get; private set; }
        public double X { get; private set; }
        public double Y { get; private set; }
        public double VelocityX { get; private set; }
        public double VelocityY { get; private set; }
        public Ellipse Shape { get; private set; }
        public Ball(Point point, double radius, SolidColorBrush color)
        {
            X = point.X;
            Y = point.Y;
            VelocityX = GetRandomVelocity();
            VelocityY = GetRandomVelocity();

            Radius = radius;

            Shape = new Ellipse();
            Shape.Width = Radius * 2;
            Shape.Height = Radius * 2;
            Shape.Fill = color;
            Shape.DataContext = this;
            Canvas.SetLeft(Shape, X - Radius);
            Canvas.SetTop(Shape, Y - Radius);
        }

        private double GetRandomVelocity()
        {
            Random random = new Random();
            double velocity = random.Next(-6, 7);
            while (velocity == 0)
            {
                velocity = random.Next(-6, 7);
            }
            return velocity;
        }

        public void UpdatePosition(double EnvWidth, double EnvHeight)
        {
            double leftLimit = Radius;
            double rightLimit = EnvWidth - Radius;
            double topLimit = Radius;
            double bottomLimit = EnvHeight - Radius;

            X += VelocityX;
            Y += VelocityY;

            if (X <= leftLimit || X >= rightLimit)
            {
                VelocityX *= -1;
            }

            if (Y <= topLimit || Y >= bottomLimit)
            {
                VelocityY *= -1;
            }

            Canvas.SetLeft(Shape, X - Radius);
            Canvas.SetTop(Shape, Y - Radius);
        }

        private SolidColorBrush ChangeColor()
        {
            Random random = new Random();
            byte r = (byte)random.Next(256);
            byte g = (byte)random.Next(256);
            byte b = (byte)random.Next(256);
            return new SolidColorBrush(Color.FromRgb(r, g, b));
        }
    }
}
