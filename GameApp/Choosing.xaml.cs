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
        public Choosing()
        {
            InitializeComponent();
        }

        private void Ellips_MouseEnter(object sender, MouseEventArgs e)
        {
            Storyboard On_1 = (Storyboard)FindResource("On_1");
            
            On_1.Begin(this);
        }

        private void Ellips_MouseLeave(object sender, MouseEventArgs e)
        {
            Storyboard Off_1 = (Storyboard)FindResource("Off_1");

            Off_1.Begin(this);
        }
    }
}
