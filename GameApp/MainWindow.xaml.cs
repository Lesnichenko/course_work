using System;

using System.Windows;

using System.Windows.Input;

using System.Windows.Media.Animation;

namespace GameApp
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            EYE.NavigationService.Navigate(new Uri("Choosing.xaml", UriKind.Relative));
        }
        bool isFlip = false;
        double valueold = 0;

        private void ScrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double Y_top = canvas.Margin.Top;
            double Y_bot = canvas.Margin.Bottom;
            double Y_lef = canvas.Margin.Left;
            double Y_rig = canvas.Margin.Right;
            double valuenew = valueold - Bar.Value;
            double dY_down;
            double dY_up;
            if (valuenew < 0)
            {
                dY_down = Y_top - Math.Abs(valuenew);
                dY_up = Y_bot + Math.Abs(valuenew);
            }
            else
            {
                dY_down = Y_top + Math.Abs(valuenew);
                dY_up = Y_bot - Math.Abs(valuenew);
            }
            canvas.Margin = new Thickness(Y_lef, dY_down, Y_rig, dY_up);
            valueold = Bar.Value;
        }

        // управление Canvas через клик мыши
        /*
        Point startMovePosition;
        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                isMoved = true;
                startMovePosition = e.GetPosition(this);
            }
        }
        private void Rectangle_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Released)
            {
                isMoved = false;
            }
        }
        private void Rectangle_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMoved)
            {
                Point currentPoint = e.GetPosition(this);
                double dY_down = currentPoint.Y + startMovePosition.Y;
                double dY_up = currentPoint.Y - startMovePosition.Y;
                Canvas rect = sender as Canvas;
                rect.Margin = new Thickness(0, 0, dY_up, -dY_down);
            }
        }
        */


        private void image1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Storyboard Sidebar_In = (Storyboard)FindResource("Sidebar_In");
            Storyboard Sidebar_Out = (Storyboard)FindResource("Sidebar_Out");
            if (!isFlip)
            {
                Sidebar_Out.Begin(this);
                isFlip = true;
            }
            else
            {
                Sidebar_In.Begin(this);
                isFlip = false;
            }
        }
    }
   
}
