
using System.Windows;
using System.Windows.Controls;

namespace GameApp
{
    partial class MainMenu : Page
    {
        private GameModeController m_gmCtl;

        public MainMenu(GameModeController gmCtl)
        {
            m_gmCtl = gmCtl;

            InitializeComponent();
        }

        public void OnButtonClick(object sender, RoutedEventArgs args)
        {
            if (sender.Equals(startButton))
                m_gmCtl.StartGame();
            else
                m_gmCtl.ExitGame();
        }

        public void OnAboutButtonClicked(object sender, RoutedEventArgs args)
        {
            MainWindow.last.ShowAbout();
        }
    }
}
