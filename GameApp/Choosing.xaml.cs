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
    /// Логика взаимодействия для Choosing.xaml
    /// </summary>
    public partial class Choosing : Page
    {
        private GameModeController m_gmCtl;

        public Choosing(GameModeController gmCtl)
        {
            m_gmCtl = gmCtl;

            InitializeComponent();
        }

        static public int Num_Animal;
        // 1 - лиса    // 5 - заяц
        // 2 - медведь // 6 - еж
        // 3 - волк    // 7 - белка
        // 4 - рысь    // 8 - лось

        private void Ellips_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Num_Animal = 1;
            //NavigationService.Navigate(new Uri("/Training.xaml", UriKind.Relative));
            m_gmCtl.NextGame();
        }

        private void Ellips_2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Num_Animal = 2;
            //NavigationService.Navigate(new Uri("/Training.xaml", UriKind.Relative));
            m_gmCtl.NextGame();
        }

        private void Ellips_3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Num_Animal = 3;
            // NavigationService.Navigate(new Uri("/Training.xaml", UriKind.Relative));
            m_gmCtl.NextGame();
        }

        private void Ellips_4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Num_Animal = 4;
            //NavigationService.Navigate(new Uri("/Training.xaml", UriKind.Relative));

            m_gmCtl.NextGame();
        }

        private void Ellips_5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Num_Animal = 5;
            //NavigationService.Navigate(new Uri("/Training.xaml", UriKind.Relative));

            m_gmCtl.NextGame();
        }

        private void Ellips_6_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Num_Animal = 6;
            //NavigationService.Navigate(new Uri("/Training.xaml", UriKind.Relative));

            m_gmCtl.NextGame();
        }

        private void Ellips_7_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Num_Animal = 7;
            //NavigationService.Navigate(new Uri("/Training.xaml", UriKind.Relative));
            m_gmCtl.NextGame();
        }

        private void Ellips_8_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Num_Animal = 8;
            //NavigationService.Navigate(new Uri("/Training.xaml", UriKind.Relative));
            m_gmCtl.NextGame();
        }
    }
}
