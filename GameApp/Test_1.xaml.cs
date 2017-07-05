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
    public partial class Test_1 : Page
    {
        private GameModeController m_gmCtl;

        public Test_1(GameModeController gmCtl)
        {
            m_gmCtl = gmCtl;

            InitializeComponent();
            Navigation();
        }

        private Storyboard Animation_Food_1;
        private Storyboard Animation_Food_2;
        private Storyboard Animation_Food_3;
        private Storyboard Choise_1;
        private Storyboard Choise_2;
        private Storyboard Choise_3;

        public void StartGame()
        {
            Random rg = new Random();

            if(Choosing.Num_Animal == 0)
            {
                Choosing.Num_Animal = rg.Next() % 8 + 1;
            }

            Navigation();
        }

        private void Navigation()
        {
            int i = Choosing.Num_Animal;
            BitmapImage page_2 = new BitmapImage();
            BitmapImage food_img_1 = new BitmapImage();
            BitmapImage food_img_2 = new BitmapImage();
            BitmapImage food_img_3 = new BitmapImage();
            switch (i)
            {
                case (1):
                    {
                        page_2.BeginInit();
                        page_2.UriSource = new Uri("/Image/test/_1/fox.png", UriKind.Relative);
                        page_2.EndInit();
                        food_img_1.BeginInit();
                        food_img_1.UriSource = new Uri("/Image/food/жук.png", UriKind.Relative);
                        food_img_1.EndInit();
                        food_img_2.BeginInit();
                        food_img_2.UriSource = new Uri("/Image/food/rastenia.png", UriKind.Relative);
                        food_img_2.EndInit();
                        food_img_3.BeginInit();
                        food_img_3.UriSource = new Uri("/Image/food/ryba.png", UriKind.Relative);
                        food_img_3.EndInit();
                        Animation_Food_1 = (Storyboard)FindResource("Yes");
                        Animation_Food_2 = (Storyboard)FindResource("Yes");
                        Animation_Food_3 = (Storyboard)FindResource("Yes");
                        break;
                    }
                case (2):
                    {
                        page_2.BeginInit();
                        page_2.UriSource = new Uri("/Image/test/_1/bear.png", UriKind.Relative);
                        page_2.EndInit();
                        food_img_1.BeginInit();
                        food_img_1.UriSource = new Uri("/Image/food/ягоды.png", UriKind.Relative);
                        food_img_1.EndInit();
                        food_img_2.BeginInit();
                        food_img_2.UriSource = new Uri("/Image/food/жук.png", UriKind.Relative);
                        food_img_2.EndInit();
                        food_img_3.BeginInit();
                        food_img_3.UriSource = new Uri("/Image/food/грызун.png", UriKind.Relative);
                        food_img_3.EndInit();
                        Animation_Food_1 = (Storyboard)FindResource("Yes");
                        Animation_Food_2 = (Storyboard)FindResource("Yes");
                        Animation_Food_3 = (Storyboard)FindResource("Yes");
                        break;
                    }
                case (3):
                    {
                        page_2.BeginInit();
                        page_2.UriSource = new Uri("/Image/test/_1/wolf.png", UriKind.Relative);
                        page_2.EndInit();
                        food_img_1.BeginInit();
                        food_img_1.UriSource = new Uri("/Image/food/жук.png", UriKind.Relative);
                        food_img_1.EndInit();
                        food_img_2.BeginInit();
                        food_img_2.UriSource = new Uri("/Image/food/грызун.png", UriKind.Relative);
                        food_img_2.EndInit();
                        food_img_3.BeginInit();
                        food_img_3.UriSource = new Uri("/Image/food/ягоды.png", UriKind.Relative);
                        food_img_3.EndInit();
                        Animation_Food_1 = (Storyboard)FindResource("Yes");
                        Animation_Food_2 = (Storyboard)FindResource("Yes");
                        Animation_Food_3 = (Storyboard)FindResource("Yes");
                        break;
                    }
                case (4):
                    {
                        page_2.BeginInit();
                        page_2.UriSource = new Uri("/Image/test/_1/lynx.png", UriKind.Relative);
                        page_2.EndInit();
                        food_img_1.BeginInit();
                        food_img_1.UriSource = new Uri("/Image/food/жук.png", UriKind.Relative);
                        food_img_1.EndInit();
                        food_img_2.BeginInit();
                        food_img_2.UriSource = new Uri("/Image/food/грызун.png", UriKind.Relative);
                        food_img_2.EndInit();
                        food_img_3.BeginInit();
                        food_img_3.UriSource = new Uri("/Image/food/ягоды.png", UriKind.Relative);
                        food_img_3.EndInit();
                        Animation_Food_1 = (Storyboard)FindResource("Yes");
                        Animation_Food_2 = (Storyboard)FindResource("Yes");
                        Animation_Food_3 = (Storyboard)FindResource("Yes");
                        break;
                    }
                case (5):
                    {
                        page_2.BeginInit();
                        page_2.UriSource = new Uri("/Image/test/_1/hare.png", UriKind.Relative);
                        page_2.EndInit();
                        food_img_1.BeginInit();
                        food_img_1.UriSource = new Uri("/Image/food/morkov.png", UriKind.Relative);
                        food_img_1.EndInit();
                        food_img_2.BeginInit();
                        food_img_2.UriSource = new Uri("/Image/food/ягоды.png", UriKind.Relative);
                        food_img_2.EndInit();
                        food_img_3.BeginInit();
                        food_img_3.UriSource = new Uri("/Image/food/грызун.png", UriKind.Relative);
                        food_img_3.EndInit();
                        Animation_Food_1 = (Storyboard)FindResource("Yes");
                        Animation_Food_2 = (Storyboard)FindResource("Yes");
                        Animation_Food_3 = (Storyboard)FindResource("Yes");
                        break;
                    }
                case (6):
                    {
                        page_2.BeginInit();
                        page_2.UriSource = new Uri("/Image/test/_1/hedgehog.png", UriKind.Relative);
                        page_2.EndInit();
                        food_img_1.BeginInit();
                        food_img_1.UriSource = new Uri("/Image/food/жук.png", UriKind.Relative);
                        food_img_1.EndInit();
                        food_img_2.BeginInit();
                        food_img_2.UriSource = new Uri("/Image/food/ягоды.png", UriKind.Relative);
                        food_img_2.EndInit();
                        food_img_3.BeginInit();
                        food_img_3.UriSource = new Uri("/Image/food/грызун.png", UriKind.Relative);
                        food_img_3.EndInit();
                        Animation_Food_1 = (Storyboard)FindResource("Yes");
                        Animation_Food_2 = (Storyboard)FindResource("Yes");
                        Animation_Food_3 = (Storyboard)FindResource("Yes");
                        break;
                    }
                case (7):
                    {
                        page_2.BeginInit();
                        page_2.UriSource = new Uri("/Image/test/_1/squirrel.png", UriKind.Relative);
                        page_2.EndInit();
                        food_img_1.BeginInit();
                        food_img_1.UriSource = new Uri("/Image/food/орехи.png", UriKind.Relative);
                        food_img_1.EndInit();
                        food_img_2.BeginInit();
                        food_img_2.UriSource = new Uri("/Image/food/грызун.png", UriKind.Relative);
                        food_img_2.EndInit();
                        food_img_3.BeginInit();
                        food_img_3.UriSource = new Uri("/Image/food/ягоды.png", UriKind.Relative);
                        food_img_3.EndInit();
                        Animation_Food_1 = (Storyboard)FindResource("Yes");
                        Animation_Food_2 = (Storyboard)FindResource("Yes");
                        Animation_Food_3 = (Storyboard)FindResource("Yes");
                        break;
                    }
                case (8):
                    {
                        page_2.BeginInit();
                        page_2.UriSource = new Uri("/Image/test/_1/elk.png", UriKind.Relative);
                        page_2.EndInit();
                        food_img_1.BeginInit();
                        food_img_1.UriSource = new Uri("/Image/food/seno.png", UriKind.Relative);
                        food_img_1.EndInit();
                        food_img_2.BeginInit();
                        food_img_2.UriSource = new Uri("/Image/food/грызун.png", UriKind.Relative);
                        food_img_2.EndInit();
                        food_img_3.BeginInit();
                        food_img_3.UriSource = new Uri("/Image/food/ягоды.png", UriKind.Relative);
                        food_img_3.EndInit();
                        Animation_Food_1 = (Storyboard)FindResource("Yes");
                        Animation_Food_2 = (Storyboard)FindResource("Yes");
                        Animation_Food_3 = (Storyboard)FindResource("Yes");
                        break;
                    }
            }
            img_2.Source = page_2;
            food_1.Source = food_img_1;
            food_2.Source = food_img_2;
            food_3.Source = food_img_3;
        }
        private void Ellips_1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            BitmapImage Choise = new BitmapImage();
            Choise.BeginInit();
            Choise.UriSource = new Uri("/Image/test/правильный ответ.png", UriKind.Relative);
            Choise.EndInit();
            Ellips_1.Source = Choise;
            Choise_1 = (Storyboard)FindResource("Yes");
            Choise_1.Begin(this);
        }

        private void Ellips_2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            BitmapImage Choise = new BitmapImage();
            Choise.BeginInit();
            Choise.UriSource = new Uri("/Image/test/неправильный ответ.png", UriKind.Relative);
            Choise.EndInit();
            Ellips_2.Source = Choise;
            Choise_2 = (Storyboard)FindResource("No_1");
            Choise_2.Begin(this);
        }

        private void Ellips_3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            BitmapImage Choise = new BitmapImage();
            Choise.BeginInit();
            Choise.UriSource = new Uri("/Image/test/неправильный ответ.png", UriKind.Relative);
            Choise.EndInit();
            Ellips_3.Source = Choise;
            Choise_3 = (Storyboard)FindResource("No_2");
            Choise_3.Begin(this);
        }

        private void OnAnimationComplete(object sender, EventArgs args)
        {
            m_gmCtl.NextGame();
        }
    }

   
}
