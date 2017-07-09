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
            Creating_test(Number_Animal_Test);
        }

        private Storyboard Animation_Food;
        private Storyboard Choise_1;
        private Storyboard Choise_2;
        private Storyboard Choise_3;
        private int num_true;
        private int Number_Animal_Test;
        private Random rgb = new Random();

        public void StartGame()
        {
            Random rg = new Random();

            if (!Choosing.selected)
            {
                Choosing.Num_Animal = rg.Next() % 8 + 1;
            }
            Rest.Visibility = Visibility.Collapsed;
            Number_Animal_Test = Choosing.Num_Animal;
            Creating_test(Number_Animal_Test);
            Resume();
        }

        private void Ellips_1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            BitmapImage Choise = new BitmapImage();
            Choise.BeginInit();
            if (num_true == 1)
            {
                next_button.Opacity = 100;
                Choise.UriSource = new Uri("/Image/test/правильный ответ.png", UriKind.Relative);
                Rest.Visibility = Visibility.Visible;
            }
            else Choise.UriSource = new Uri("/Image/test/неправильный ответ.png", UriKind.Relative);
            Choise.EndInit();
            Ellips_1.Source = Choise;
            Choise_1 = (Storyboard)FindResource("Yes");
            Choise_1.Begin(this);
        }

        private void Ellips_2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            BitmapImage Choise = new BitmapImage();
            Choise.BeginInit();
            if (num_true == 2)
            {
                next_button.Opacity = 100;
                Choise.UriSource = new Uri("/Image/test/правильный ответ.png", UriKind.Relative);
                Rest.Visibility = Visibility.Visible;
            }
            else Choise.UriSource = new Uri("/Image/test/неправильный ответ.png", UriKind.Relative);
            Choise.EndInit();
            Ellips_2.Source = Choise;
            Choise_2 = (Storyboard)FindResource("No_1");
            Choise_2.Begin(this);
        }

        private void Ellips_3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            BitmapImage Choise = new BitmapImage();
            Choise.BeginInit();
            if (num_true == 3)
            {
                next_button.Opacity = 100;
                Choise.UriSource = new Uri("/Image/test/правильный ответ.png", UriKind.Relative);
                Rest.Visibility = Visibility.Visible;
            }
            else Choise.UriSource = new Uri("/Image/test/неправильный ответ.png", UriKind.Relative);
            Choise.EndInit();
            Ellips_3.Source = Choise;
            Choise_3 = (Storyboard)FindResource("No_2");
            Choise_3.Begin(this);
        }
        /*
        private void OnAnimationComplete(object sender, EventArgs args)
        {
            Resume();
            m_gmCtl.NextGame();
        }
        */
        private void Resume()
        {
            BitmapImage Choise = new BitmapImage();
            Choise.BeginInit();
            Choise.UriSource = new Uri("/Image/обводка.png", UriKind.Relative);
            Choise.EndInit();
            Ellips_1.Source = Choise;
            Ellips_2.Source = Choise;
            Ellips_3.Source = Choise;
            next_button.Opacity = 0;
        }

        private void Creating_test(int Number)
        {
            Random rg = new Random();
            BitmapImage page_2 = new BitmapImage();
            BitmapImage food_img_1 = new BitmapImage();
            BitmapImage food_img_2 = new BitmapImage();
            BitmapImage food_img_3 = new BitmapImage();
            switch (Number)
            {
                case (1):
                    {
                        page_2.BeginInit();
                        page_2.UriSource = new Uri("/Image/test/_1/fox.png", UriKind.Relative);
                        page_2.EndInit();
                        num_true = rg.Next() % 3 + 1;
                        Answer_Options(num_true, Number);
                        break;
                    }
                case (2):
                    {
                        page_2.BeginInit();
                        page_2.UriSource = new Uri("/Image/test/_1/bear.png", UriKind.Relative);
                        page_2.EndInit();
                        num_true = rg.Next() % 3 + 1;
                        Answer_Options(num_true, Number);
                        break;
                    }
                case (3):
                    {
                        page_2.BeginInit();
                        page_2.UriSource = new Uri("/Image/test/_1/wolf.png", UriKind.Relative);
                        page_2.EndInit();
                        num_true = rg.Next() % 3 + 1;
                        Answer_Options(num_true, Number);
                        break;
                    }
                case (4):
                    {
                        page_2.BeginInit();
                        page_2.UriSource = new Uri("/Image/test/_1/lynx.png", UriKind.Relative);
                        page_2.EndInit();
                        num_true = rg.Next() % 3 + 1;
                        Answer_Options(num_true, Number);
                        break;
                    }
                case (5):
                    {
                        page_2.BeginInit();
                        page_2.UriSource = new Uri("/Image/test/_1/hare.png", UriKind.Relative);
                        page_2.EndInit();
                        num_true = rg.Next() % 3 + 1;
                        Answer_Options(num_true, Number);
                        break;
                    }
                case (6):
                    {
                        page_2.BeginInit();
                        page_2.UriSource = new Uri("/Image/test/_1/hedgehog.png", UriKind.Relative);
                        page_2.EndInit();
                        num_true = rg.Next() % 3 + 1;
                        Answer_Options(num_true, Number);
                        break;
                    }
                case (7):
                    {
                        page_2.BeginInit();
                        page_2.UriSource = new Uri("/Image/test/_1/squirrel.png", UriKind.Relative);
                        page_2.EndInit();
                        num_true = rg.Next() % 3 + 1;
                        Answer_Options(num_true, Number);
                        break;
                    }
                case (8):
                    {
                        page_2.BeginInit();
                        page_2.UriSource = new Uri("/Image/test/_1/elk.png", UriKind.Relative);
                        page_2.EndInit();
                        num_true = rg.Next() % 3 + 1;
                        Answer_Options(num_true, Number);
                        break;
                    }
            }
            img_2.Source = page_2;
        }

        private void Answer_Options(int Number, int Number_Animal)
        {
            BitmapImage food_img_1 = new BitmapImage();
            BitmapImage food_img_2 = new BitmapImage();
            BitmapImage food_img_3 = new BitmapImage();
            BitmapImage Choise = new BitmapImage();
            Random rg = new Random();

            food_img_1.BeginInit();
            if (Number == 1) food_img_1.UriSource = new Uri(Random_Food(Number_Animal), UriKind.Relative);
            else
            {
                food_img_1.UriSource = new Uri(Random_Food_False(Number_Animal), UriKind.Relative);
            }
            food_img_1.EndInit();
            food_1.Source = food_img_1;
            food_img_2.BeginInit();
            if (Number == 2) food_img_2.UriSource = new Uri(Random_Food(Number_Animal), UriKind.Relative);
            else
            {
                food_img_2.UriSource = new Uri(Random_Food_False(Number_Animal), UriKind.Relative);
            }
            food_img_2.EndInit();
            food_2.Source = food_img_2;
            food_img_3.BeginInit();
            if (Number == 3) food_img_3.UriSource = new Uri(Random_Food(Number_Animal), UriKind.Relative);
            else
            {
                food_img_3.UriSource = new Uri(Random_Food_False(Number_Animal), UriKind.Relative);
            }
            food_img_3.EndInit();
            food_3.Source = food_img_3;
        }

        private string Random_Food(int Number)
        {
            Random rg = new Random();
            switch (Number)
            {
                case (1):
                    {
                        switch (rg.Next() % 3 + 1)
                        {
                            case (1):
                                {
                                    Animation_Food = (Storyboard)FindResource("Yes");
                                    return ("/Image/food/жук.png");
                                }
                            case (2):
                                {
                                    Animation_Food = (Storyboard)FindResource("Yes");
                                    return ("/Image/food/грызун.png");
                                }
                            case (3):
                                {
                                    Animation_Food = (Storyboard)FindResource("Yes");
                                    return ("/Image/food/ягоды.png");
                                }
                        }
                        break;
                    }
                case (2):
                    {
                        switch (rg.Next() % 3 + 1)
                        {
                            case (1):
                                {
                                    Animation_Food = (Storyboard)FindResource("Yes");
                                    return ("/Image/food/ягоды.png");
                                }
                            case (2):
                                {
                                    Animation_Food = (Storyboard)FindResource("Yes");
                                    return ("/Image/food/rastenia.png");
                                }
                            case (3):
                                {
                                    Animation_Food = (Storyboard)FindResource("Yes");
                                    return ("/Image/food/ryba.png");
                                }
                        }
                        break;
                    }
                case (3):
                    {
                        switch (rg.Next() % 3 + 1)
                        {
                            case (1):
                                {
                                    Animation_Food = (Storyboard)FindResource("Yes");
                                    return ("/Image/food/food_test.png");
                                }
                            case (2):
                                {
                                    Animation_Food = (Storyboard)FindResource("Yes");
                                    return ("/Image/food/food_test.png");
                                }
                            case (3):
                                {
                                    Animation_Food = (Storyboard)FindResource("Yes");
                                    return ("/Image/food/food_test.png");
                                }
                        }
                        break;
                    }
                case (4):
                    {
                        switch (rg.Next() % 3 + 1)
                        {
                            case (1):
                                {
                                    Animation_Food = (Storyboard)FindResource("Yes");
                                    return ("/Image/food/food_test.png");
                                }
                            case (2):
                                {
                                    Animation_Food = (Storyboard)FindResource("Yes");
                                    return ("/Image/food/food_test.png");
                                }
                            case (3):
                                {
                                    Animation_Food = (Storyboard)FindResource("Yes");
                                    return ("/Image/food/food_test.png");
                                }
                        }
                        break;
                    }
                case (5):
                    {
                        switch (rg.Next() % 3 + 1)
                        {
                            case (1):
                                {
                                    Animation_Food = (Storyboard)FindResource("Yes");
                                    return ("/Image/food/morkov.png");
                                }
                            case (2):
                                {
                                    Animation_Food = (Storyboard)FindResource("Yes");
                                    return ("/Image/food/seno.png");
                                }
                            case (3):
                                {
                                    Animation_Food = (Storyboard)FindResource("Yes");
                                    return ("/Image/food/rastenia.png");
                                }
                        }
                        break;
                    }
                case (6):
                    {
                        switch (rg.Next() % 3 + 1)
                        {
                            case (1):
                                {
                                    Animation_Food = (Storyboard)FindResource("Yes");
                                    return ("/Image/food/жук.png");
                                }
                            case (2):
                                {
                                    Animation_Food = (Storyboard)FindResource("Yes");
                                    return ("/Image/food/улитку.png");
                                }
                            case (3):
                                {
                                    Animation_Food = (Storyboard)FindResource("Yes");
                                    return ("/Image/food/черви.png");
                                }
                        }
                        break;
                    }
                case (7):
                    {
                        switch (rg.Next() % 3 + 1)
                        {
                            case (1):
                                {
                                    Animation_Food = (Storyboard)FindResource("Yes");
                                    return ("/Image/food/food_test.png");
                                }
                            case (2):
                                {
                                    Animation_Food = (Storyboard)FindResource("Yes");
                                    return ("/Image/food/food_test.png");
                                }
                            case (3):
                                {
                                    Animation_Food = (Storyboard)FindResource("Yes");
                                    return ("/Image/food/food_test.png");
                                }
                        }
                        break;
                    }
                case (8):
                    {
                        switch (rg.Next() % 3 + 1)
                        {
                            case (1):
                                {
                                    Animation_Food = (Storyboard)FindResource("Yes");
                                    return ("/Image/food/food_test.png");
                                }
                            case (2):
                                {
                                    Animation_Food = (Storyboard)FindResource("Yes");
                                    return ("/Image/food/food_test.png");
                                }
                            case (3):
                                {
                                    Animation_Food = (Storyboard)FindResource("Yes");
                                    return ("/Image/food/food_test.png");
                                }
                            
                        }
                        break;
                    }
                default:
                    {
                        return ("/Image/food/food_test.png");
                    }
            }
            return ("/Image/food/food_test.png");
        }

        private string Random_Food_False(int Number)
        {
            int random_food_num = rgb.Next() % 9 + 1;
            switch (Number)
            {
                case (1):
                    {
                        switch (random_food_num)
                        {
                            case (1):
                                {
                                    return ("/Image/food/food_test.png");
                                }
                            case (2):
                                {
                                    return ("/Image/food/morkov.png");
                                }
                            case (3):
                                {
                                    return ("/Image/food/rastenia.png");
                                }
                            case (4):
                                {
                                    return ("/Image/food/ryba.png");
                                }
                            case (5):
                                {
                                    return ("/Image/food/seno.png");
                                }
                            case (6):
                                {
                                    return ("/Image/food/yablochko.png");
                                }
                            case (7):
                                {
                                    return ("/Image/food/орехи.png");
                                }
                            case (8):
                                {
                                    return ("/Image/food/улитка.png");
                                }
                            case (9):
                                {
                                    return ("/Image/food/черви.png");
                                }
                        }
                        break;
                    }
                case (2):
                    {
                        switch (random_food_num)
                        {
                            case (1):
                                {
                                    return ("/Image/food/food_test.png");
                                }
                            case (2):
                                {
                                    return ("/Image/food/morkov.png");
                                }
                            case (3):
                                {
                                    return ("/Image/food/грызун.png");
                                }
                            case (4):
                                {
                                    return ("/Image/food/жук.png");
                                }
                            case (5):
                                {
                                    return ("/Image/food/seno.png");
                                }
                            case (6):
                                {
                                    return ("/Image/food/yablochko.png");
                                }
                            case (7):
                                {
                                    return ("/Image/food/орехи.png");
                                }
                            case (8):
                                {
                                    return ("/Image/food/улитка.png");
                                }
                            case (9):
                                {
                                    return ("/Image/food/черви.png");
                                }
                        }
                        break;
                    }
                case (3):
                    {
                        switch (random_food_num)
                        {
                            case (1):
                                {
                                    return ("/Image/food/food_test.png");
                                }
                            case (2):
                                {
                                    return ("/Image/food/morkov.png");
                                }
                            case (3):
                                {
                                    return ("/Image/food/rastenia.png");
                                }
                            case (4):
                                {
                                    return ("/Image/food/ryba.png");
                                }
                            case (5):
                                {
                                    return ("/Image/food/seno.png");
                                }
                            case (6):
                                {
                                    return ("/Image/food/yablochko.png");
                                }
                            case (7):
                                {
                                    return ("/Image/food/орехи.png");
                                }
                            case (8):
                                {
                                    return ("/Image/food/улитка.png");
                                }
                            case (9):
                                {
                                    return ("/Image/food/черви.png");
                                }
                        }
                        break;
                    }
                case (4):
                    {
                        switch (random_food_num)
                        {
                            case (1):
                                {
                                    return ("/Image/food/food_test.png");
                                }
                            case (2):
                                {
                                    return ("/Image/food/morkov.png");
                                }
                            case (3):
                                {
                                    return ("/Image/food/rastenia.png");
                                }
                            case (4):
                                {
                                    return ("/Image/food/ryba.png");
                                }
                            case (5):
                                {
                                    return ("/Image/food/seno.png");
                                }
                            case (6):
                                {
                                    return ("/Image/food/yablochko.png");
                                }
                            case (7):
                                {
                                    return ("/Image/food/орехи.png");
                                }
                            case (8):
                                {
                                    return ("/Image/food/улитка.png");
                                }
                            case (9):
                                {
                                    return ("/Image/food/черви.png");
                                }
                        }
                        break;
                    }
                case (5):
                    {
                        switch (random_food_num)
                        {
                            case (1):
                                {
                                    return ("/Image/food/food_test.png");
                                }
                            case (2):
                                {
                                    return ("/Image/food/ryba.png");
                                }
                            case (3):
                                {
                                    return ("/Image/food/жук.png");
                                }
                            case (4):
                                {
                                    return ("/Image/food/ryba.png");
                                }
                            case (5):
                                {
                                    return ("/Image/food/ягоды.png");
                                }
                            case (6):
                                {
                                    return ("/Image/food/yablochko.png");
                                }
                            case (7):
                                {
                                    return ("/Image/food/орехи.png");
                                }
                            case (8):
                                {
                                    return ("/Image/food/улитка.png");
                                }
                            case (9):
                                {
                                    return ("/Image/food/черви.png");
                                }
                        }
                        break;
                    }
                case (6):
                    {
                            switch (random_food_num)
                            {
                                case (1):
                                    {
                                        return ("/Image/food/food_test.png");
                                    }
                                case (2):
                                    {
                                        return ("/Image/food/morkov.png");
                                    }
                                case (3):
                                    {
                                        return ("/Image/food/rastenia.png");
                                    }
                                case (4):
                                    {
                                        return ("/Image/food/ryba.png");
                                    }
                                case (5):
                                    {
                                        return ("/Image/food/seno.png");
                                    }
                                case (6):
                                    {
                                        return ("/Image/food/yablochko.png");
                                    }
                                case (7):
                                    {
                                        return ("/Image/food/орехи.png");
                                    }
                                case (8):
                                    {
                                        return ("/Image/food/ягода.png");
                                    }
                                case (9):
                                    {
                                        return ("/Image/food/грызун.png");
                                    }
                            }
                            break;
                    }
                case (7):
                    { 
                            switch (random_food_num)
                            {
                                case (1):
                                    {
                                        return ("/Image/food/food_test.png");
                                    }
                                case (2):
                                    {
                                        return ("/Image/food/morkov.png");
                                    }
                                case (3):
                                    {
                                        return ("/Image/food/rastenia.png");
                                    }
                                case (4):
                                    {
                                        return ("/Image/food/ryba.png");
                                    }
                                case (5):
                                    {
                                        return ("/Image/food/seno.png");
                                    }
                                case (6):
                                    {
                                        return ("/Image/food/yablochko.png");
                                    }
                                case (7):
                                    {
                                        return ("/Image/food/жук.png");
                                    }
                                case (8):
                                    {
                                        return ("/Image/food/улитка.png");
                                    }
                                case (9):
                                    {
                                        return ("/Image/food/черви.png");
                                    }
                            }
                            break;
                    }
                case (8):
                    {
                        switch (random_food_num)
                        {
                            case (1):
                                {
                                    return ("/Image/food/food_test.png");
                                }
                            case (2):
                                {
                                    return ("/Image/food/morkov.png");
                                }
                            case (3):
                                {
                                    return ("/Image/food/rastenia.png");
                                }
                            case (4):
                                {
                                    return ("/Image/food/ryba.png");
                                }
                            case (5):
                                {
                                    return ("/Image/food/seno.png");
                                }
                            case (6):
                                {
                                    return ("/Image/food/yablochko.png");
                                }
                            case (7):
                                {
                                    return ("/Image/food/жук.png");
                                }
                            case (8):
                                {
                                    return ("/Image/food/улитка.png");
                                }
                            case (9):
                                {
                                    return ("/Image/food/черви.png");
                                }
                        }
                        break;
                    }
                default:
                    {
                        return ("/Image/food/food_test.png");
                    }
            }
            return ("/Image/food/food_test.png");
        }

        private void next_button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Resume();
            m_gmCtl.NextGame();
        }

        private void back_button_MouseDown(object sender, MouseButtonEventArgs e)
        {
            m_gmCtl.PrevGame();
        }

        private void Rest_Click(object sender, RoutedEventArgs e)
        {
            StartGame();
        }
    }

}
