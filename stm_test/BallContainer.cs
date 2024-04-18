using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace stm_test
{
    public class BallContainer
    {
        private List<Ball> balls;
        public BallContainer() 
        { 
            balls = new List<Ball>();
        }
        public Ball AddBall(Point position, double radius, SolidColorBrush color)
        {
            Ball ball = new Ball(position, radius, color);
            balls.Add(ball);
            return ball;
        }

        public void UpdateBalls(double EnvWidth, double EnvHeight)
        {
            foreach (Ball ball in balls)
            {
                ball.UpdatePosition(EnvWidth, EnvHeight);
            }
        }

        public void Clear()
        {
            balls.Clear();
        }
    }
}
