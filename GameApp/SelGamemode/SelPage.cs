
using System.Windows;
using System.Windows.Controls;

namespace GameApp.SelectionGamemode
{
    public partial class SelPage : Page
    {
        private GameModeController m_gmCtl;
        private SelGame m_Game;
        private bool m_bNeedStart;

        public SelPage(GameModeController gmCtl)
        {
            m_gmCtl = gmCtl;
            m_Game = null;
            m_bNeedStart = false;

            this.Loaded += OnLoaded;

            InitializeComponent();
        }

        private void OnLoaded(object sender, RoutedEventArgs args)
        {
            m_Game = new SelGame(this, new SelButton[3] { selBtn_0, selBtn_1, selBtn_2 }, new Image[2] { labelBackground, labelContent});

            if(m_bNeedStart)
            {
                m_Game.RestartGame();
                m_bNeedStart = false;
            }
        }

        public void StartGame()
        {
            if (m_Game != null)
                m_Game.RestartGame();
            else
                m_bNeedStart = true;
        }

        private void OnPrevButtonClick(object sender, RoutedEventArgs args)
        {
            m_gmCtl.PrevGame();
        }

        private void OnNextButtonClick(object sender, RoutedEventArgs args)
        {
            m_gmCtl.NextGame();
        }

        private void OnRestartButtonClick(object sender, RoutedEventArgs args)
        {
            StartGame();
        }
    }
}
