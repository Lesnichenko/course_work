using System;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

using System.Windows.Input;


namespace GameApp
{

    public partial class MainWindow : Window
    {
        public interface ICanvasClickCallback
        {
            void OnClick();
        };

        private ICanvasClickCallback m_ClickCallback;
        public static MainWindow last;
        public GameModeController m_gmCtl;

        public MainWindow()
        {
            last = this;

            InitializeComponent();
            //EYE.NavigationService.Navigate(new Uri("Choosing.xaml", UriKind.Relative));
            //EYE.NavigationService.Navigate(new Uri("/CompGamemode/CmpPage.xaml", UriKind.Relative));
            /*CompGamemode.CmpPage cmpPage = new CompGamemode.CmpPage();
            EYE.Navigate(cmpPage);
            cmpPage.StartGame();*/

            m_gmCtl = new GameModeController();

            this.Loaded      += OnWindowLoaded;
            this.SizeChanged += OnSizeChanged;
        }

        private void OnWindowLoaded(object sender, RoutedEventArgs args)
        {
            
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs args)
        {
            menuCanvas.Width = mainWindowMainGrid.ActualWidth * 1.333333;
            menuCanvas.Height = mainWindowMainGrid.ActualHeight;

            //menuCanvas.Resize(args.NewSize.Width * 1.333333, args.NewSize.Height, args.NewSize.Width, args.NewSize.Height);

            //menuCanvas.OnSizeChanged(sender, args);
        }

        public void ShowAbout()
        {
            mainViewBox.Visibility = Visibility.Collapsed;
            aboutGrid.Visibility = Visibility.Visible;
        }

        public void HideAbout()
        {
            mainViewBox.Visibility = Visibility.Visible;
            aboutGrid.Visibility = Visibility.Collapsed;
        }

        private void OnButtonClicked(object sender, RoutedEventArgs args)
        {
            /*Button b = (Button)sender;

            if (b.Name == "menuElementButton")
            { 
                MessageBox.Show(b.GetHashCode().ToString());
            }*/

            if(sender.Equals(aboutBtnClose))
            {
                HideAbout();
                return;
            }

            menuCanvas.OnButtonClicked(sender);
        }

        public void ShowClickableCanvas(ICanvasClickCallback callback)
        {
            m_ClickCallback = callback;

            clickableCanvas.Visibility = Visibility.Visible;
        }

        public void HideClickableCanvas()
        {
            clickableCanvas.Visibility = Visibility.Collapsed;
        }

        private void ClickableCanvasClick(object sender, RoutedEventArgs args)
        {
            m_ClickCallback.OnClick();
        }

        /*private void TestClick(object sender, RoutedEventArgs args)
        {
            Storyboard sb = new Storyboard();
            DoubleAnimation anim = new DoubleAnimation();

            anim.Duration = TimeSpan.FromSeconds(3);
            Canvas.SetLeft(menuGrid, menuCanvas.ActualWidth - Canvas.GetRight(menuGrid) - menuGrid.ActualWidth);
            anim.From = Canvas.GetLeft(menuGrid);
            anim.To = 0;

            sb.Duration = TimeSpan.FromSeconds(3);
            sb.Children.Add(anim);

            Storyboard.SetTarget(sb, menuGrid);
            Storyboard.SetTargetProperty(sb, new PropertyPath("(Canvas.Left)"));
            BeginStoryboard(sb);
        }*/
        /*bool isFlip = false;
        double valueold = 0;*/

       /* private void ScrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
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
        }*/

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


        /*private void image1_MouseDown(object sender, MouseButtonEventArgs e)
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
        }*/
    }
   
}
