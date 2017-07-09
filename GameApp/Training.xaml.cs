using System;
using System.Collections.Generic;
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
using System.Windows.Media.Animation;

namespace GameApp
{
    /// <summary>
    /// Логика взаимодействия для Training.xaml
    /// </summary>
    public partial class Training : Page
    {
        private GameModeController m_gmCtl;

        public Training(GameModeController gmCtl)
        {
            m_gmCtl = gmCtl;
            
            InitializeComponent();
            //Navigation();

            this.Loaded += OnLoaded;
        }

        public void OnLoaded(object sender, RoutedEventArgs args)
        {
            Canvas.SetZIndex(B_1, 3);
            Canvas.SetZIndex(W_1, 2);
            Canvas.SetZIndex(B_2, 3);
            Canvas.SetZIndex(W_2, 2);
            Canvas.SetZIndex(B_2, 3);
            Canvas.SetZIndex(W_2, 2);
            B_1.Opacity = 0;
            B_2.Opacity = 100;
            B_3.Opacity = 100;
            canvas.Opacity = 100;
            training_1.Opacity = 100;
            training_2.Opacity = 0;
            training_3.Opacity = 0;
        }

        private Storyboard Animation_Animal;

        public void StartGame()
        {
            Random rg = new Random();

            if (!Choosing.selected)
            {
                Choosing.Num_Animal = rg.Next() % 8 + 1;
            }

            Navigation();
        }

        private void Navigation()
        {
            int i = Choosing.Num_Animal;
            BitmapImage page_1 = new BitmapImage();
            BitmapImage page_2 = new BitmapImage();
            BitmapImage page_3 = new BitmapImage();
            BitmapImage food_img_1 = new BitmapImage();
            BitmapImage food_img_2 = new BitmapImage();
            BitmapImage food_img_3 = new BitmapImage();
            // bi3.BeginInit();
            // bi3.UriSource = new Uri(".PNG", UriKind.Relative);
            // bi3.EndInit();
            switch (i){
                case (1):
                    {
                        page_1.BeginInit();
                        page_1.UriSource = new Uri("/Image/training/1/fox.png", UriKind.Relative);
                        page_1.EndInit();
                        page_2.BeginInit();
                        page_2.UriSource = new Uri("/Image/training/2/fox.png", UriKind.Relative);
                        page_2.EndInit();
                        page_3.BeginInit();
                        page_3.UriSource = new Uri("/Image/training/3/fox.png", UriKind.Relative);
                        page_3.EndInit();
                        food_img_1.BeginInit();
                        food_img_1.UriSource = new Uri("/Image/food/жук.png", UriKind.Relative);
                        food_img_1.EndInit();
                        food_img_2.BeginInit();
                        food_img_2.UriSource = new Uri("/Image/food/грызун.png", UriKind.Relative);
                        food_img_2.EndInit();
                        food_img_3.BeginInit();
                        food_img_3.UriSource = new Uri("/Image/food/ягоды.png", UriKind.Relative);
                        food_img_3.EndInit();
                        Animation_Animal = (Storyboard)FindResource("fox");
                        break;
                    }
                case (2):
                    {
                        page_1.BeginInit();
                        page_1.UriSource = new Uri("/Image/training/1/bear.png", UriKind.Relative);
                        page_1.EndInit();
                        page_2.BeginInit();
                        page_2.UriSource = new Uri("/Image/training/2/bear.png", UriKind.Relative);
                        page_2.EndInit();
                        page_3.BeginInit();
                        page_3.UriSource = new Uri("/Image/training/3/bear.png", UriKind.Relative);
                        page_3.EndInit();
                        food_img_1.BeginInit();
                        food_img_1.UriSource = new Uri("/Image/food/ягоды.png", UriKind.Relative);
                        food_img_1.EndInit();
                        food_img_2.BeginInit();
                        food_img_2.UriSource = new Uri("/Image/food/rastenia.png", UriKind.Relative);
                        food_img_2.EndInit();
                        food_img_3.BeginInit();
                        food_img_3.UriSource = new Uri("/Image/food/ryba.png", UriKind.Relative);
                        food_img_3.EndInit();
                        Animation_Animal = (Storyboard)FindResource("bear");
                        break;
                    }
                case (3):
                    {
                        page_1.BeginInit();
                        page_1.UriSource = new Uri("/Image/training/1/wolf.png", UriKind.Relative);
                        page_1.EndInit();
                        page_2.BeginInit();
                        page_2.UriSource = new Uri("/Image/training/2/wolf.png", UriKind.Relative);
                        page_2.EndInit();
                        page_3.BeginInit();
                        page_3.UriSource = new Uri("/Image/training/3/wolf.png", UriKind.Relative);
                        page_3.EndInit();
                        food_img_1.BeginInit();
                        food_img_1.UriSource = new Uri("/Image/food/жук.png", UriKind.Relative);
                        food_img_1.EndInit();
                        food_img_2.BeginInit();
                        food_img_2.UriSource = new Uri("/Image/food/грызун.png", UriKind.Relative);
                        food_img_2.EndInit();
                        food_img_3.BeginInit();
                        food_img_3.UriSource = new Uri("/Image/food/ягоды.png", UriKind.Relative);
                        food_img_3.EndInit();
                        Animation_Animal = (Storyboard)FindResource("wolf");
                        break;
                    }
                case (4):
                    {
                        page_1.BeginInit();
                        page_1.UriSource = new Uri("/Image/training/1/lynx.png", UriKind.Relative);
                        page_1.EndInit();
                        page_2.BeginInit();
                        page_2.UriSource = new Uri("/Image/training/2/lynx.png", UriKind.Relative);
                        page_2.EndInit();
                        page_3.BeginInit();
                        page_3.UriSource = new Uri("/Image/training/3/lynx.png", UriKind.Relative);
                        page_3.EndInit();
                        food_img_1.BeginInit();
                        food_img_1.UriSource = new Uri("/Image/food/жук.png", UriKind.Relative);
                        food_img_1.EndInit();
                        food_img_2.BeginInit();
                        food_img_2.UriSource = new Uri("/Image/food/грызун.png", UriKind.Relative);
                        food_img_2.EndInit();
                        food_img_3.BeginInit();
                        food_img_3.UriSource = new Uri("/Image/food/ягоды.png", UriKind.Relative);
                        food_img_3.EndInit();
                        Animation_Animal = (Storyboard)FindResource("lynx");
                        break;
                    }
                case (5):
                    {
                        page_1.BeginInit();
                        page_1.UriSource = new Uri("/Image/training/1/hare.png", UriKind.Relative);
                        page_1.EndInit();
                        page_2.BeginInit();
                        page_2.UriSource = new Uri("/Image/training/2/hare.png", UriKind.Relative);
                        page_2.EndInit();
                        page_3.BeginInit();
                        page_3.UriSource = new Uri("/Image/training/3/hare.png", UriKind.Relative);
                        page_3.EndInit();
                        food_img_1.BeginInit();
                        food_img_1.UriSource = new Uri("/Image/food/morkov.png", UriKind.Relative);
                        food_img_1.EndInit();
                        food_img_2.BeginInit();
                        food_img_2.UriSource = new Uri("/Image/food/seno.png", UriKind.Relative);
                        food_img_2.EndInit();
                        food_img_3.BeginInit();
                        food_img_3.UriSource = new Uri("/Image/food/rastenia.png", UriKind.Relative);
                        food_img_3.EndInit();
                        Animation_Animal = (Storyboard)FindResource("hare");
                        break;
                    }
                case (6):
                    {
                        page_1.BeginInit();
                        page_1.UriSource = new Uri("/Image/training/1/hedgehog.png", UriKind.Relative);
                        page_1.EndInit();
                        page_2.BeginInit();
                        page_2.UriSource = new Uri("/Image/training/2/hedgehog.png", UriKind.Relative);
                        page_2.EndInit();
                        page_3.BeginInit();
                        page_3.UriSource = new Uri("/Image/training/3/hedgehog.png", UriKind.Relative);
                        page_3.EndInit();
                        food_img_1.BeginInit();
                        food_img_1.UriSource = new Uri("/Image/food/жук.png", UriKind.Relative);
                        food_img_1.EndInit();
                        food_img_2.BeginInit();
                        food_img_2.UriSource = new Uri("/Image/food/улитка.png", UriKind.Relative);
                        food_img_2.EndInit();
                        food_img_3.BeginInit();
                        food_img_3.UriSource = new Uri("/Image/food/черви.png", UriKind.Relative);
                        food_img_3.EndInit();
                        Animation_Animal = (Storyboard)FindResource("hedgehog");
                        break;
                    }
                case (7):
                    {
                        page_1.BeginInit();
                        page_1.UriSource = new Uri("/Image/training/1/squirrel.png", UriKind.Relative);
                        page_1.EndInit();
                        page_2.BeginInit();
                        page_2.UriSource = new Uri("/Image/training/2/squirrel.png", UriKind.Relative);
                        page_2.EndInit();
                        page_3.BeginInit();
                        page_3.UriSource = new Uri("/Image/training/3/squirrel.png", UriKind.Relative);
                        page_3.EndInit();
                        food_img_1.BeginInit();
                        food_img_1.UriSource = new Uri("/Image/food/жук.png", UriKind.Relative);
                        food_img_1.EndInit();
                        food_img_2.BeginInit();
                        food_img_2.UriSource = new Uri("/Image/food/грызун.png", UriKind.Relative);
                        food_img_2.EndInit();
                        food_img_3.BeginInit();
                        food_img_3.UriSource = new Uri("/Image/food/ягоды.png", UriKind.Relative);
                        food_img_3.EndInit();
                        Animation_Animal = (Storyboard)FindResource("squirrel");
                        break;
                    }
                case (8):
                    {
                        page_1.BeginInit();
                        page_1.UriSource = new Uri("/Image/training/1/elk.png", UriKind.Relative);
                        page_1.EndInit();
                        page_2.BeginInit();
                        page_2.UriSource = new Uri("/Image/training/2/elk.png", UriKind.Relative);
                        page_2.EndInit();
                        page_3.BeginInit();
                        page_3.UriSource = new Uri("/Image/training/3/elk.png", UriKind.Relative);
                        page_3.EndInit();
                        food_img_1.BeginInit();
                        food_img_1.UriSource = new Uri("/Image/food/жук.png", UriKind.Relative);
                        food_img_1.EndInit();
                        food_img_2.BeginInit();
                        food_img_2.UriSource = new Uri("/Image/food/грызун.png", UriKind.Relative);
                        food_img_2.EndInit();
                        food_img_3.BeginInit();
                        food_img_3.UriSource = new Uri("/Image/food/ягоды.png", UriKind.Relative);
                        food_img_3.EndInit();
                        Animation_Animal = (Storyboard)FindResource("elk");
                        break;
                    }
            }
            img_1.Source = page_1;
            img_2.Source = page_2;
            img_3.Source = page_3;
            food_1.Source = food_img_1;
            food_2.Source = food_img_2;
            food_3.Source = food_img_3;
            Animation_Animal.Begin(this);
        }

        private void B_1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            B_1.Opacity = 0;
            B_2.Opacity = 100;
            B_3.Opacity = 100;
            training_1.Opacity = 100;
            canvas.Opacity = 100;
            training_2.Opacity = 0;
            training_3.Opacity = 0;
            Animation_Animal.Begin(this);
        }

        private void B_2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            B_1.Opacity = 100;
            B_2.Opacity = 0;
            B_3.Opacity = 100;
            training_1.Opacity = 0;
            canvas.Opacity = 0;
            training_2.Opacity = 100;
            training_3.Opacity = 0;
            Animation_Animal.Stop(this);
        }

        private void B_3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            B_1.Opacity = 100;
            B_2.Opacity = 100;
            B_3.Opacity = 0;
            training_1.Opacity = 0;
            canvas.Opacity = 0;
            training_2.Opacity = 0;
            training_3.Opacity = 100;
            Animation_Animal.Stop(this);
        }

        private void next_button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //NavigationService.Navigate(new Uri("/Test_1.xaml", UriKind.Relative));
            m_gmCtl.NextGame();
        }

        private void back_button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            m_gmCtl.PrevGame();
        }
    }
}
