
using GameApp.CompGamemode;

namespace GameApp
{
    public class GameModeController
    {
        private MainMenu m_MainMenu;
        private CmpPage m_cmpPage;
        private Choosing m_Choosing;
        private Test_1 m_Test1;
        private Training m_Training;
        private MenuElement.MenuElementType m_eCurrentGame;

        public GameModeController()
        {
            m_MainMenu = new MainMenu(this);
            m_cmpPage = new CmpPage(this);
            m_Choosing = new Choosing(this);
            m_Test1 = new Test_1(this);
            m_Training = new Training(this);

            MainWindow.last.EYE.Navigate(m_MainMenu);
        }
         
        public void StartGame()
        {
            m_eCurrentGame = MenuElement.MenuElementType.ME_NONE;
            NextGame();
        }

        public void ExitGame()
        {
            MainWindow.last.Close();
        }

        private void UnselectCurrent()
        {
            switch (m_eCurrentGame)
            {
                case MenuElement.MenuElementType.ME_SELECT:
                    MainWindow.last.menuSelect.Unselect();
                    break;
                case MenuElement.MenuElementType.ME_LEARN_EATING:
                    MainWindow.last.menuLearnEating.Unselect();
                    break;
                case MenuElement.MenuElementType.ME_LEARN_TIMES:
                    MainWindow.last.menuLearnTimes.Unselect();
                    break;
                case MenuElement.MenuElementType.ME_GAME_EATING:
                    MainWindow.last.menuGameEating.Unselect();
                    break;
                case MenuElement.MenuElementType.ME_GAME_EXCLUDING:
                    MainWindow.last.menuGameExcluding.Unselect();
                    break;
                case MenuElement.MenuElementType.ME_CAME_COMPARISON:
                    MainWindow.last.menuGameCmp.Unselect();
                    break;
            }
        }

        public void NextGame()
        {
            UnselectCurrent();

            m_eCurrentGame++;

            if(m_eCurrentGame == MenuElement.MenuElementType.NUM_MENU_ELEMENTS)
            {
                MainWindow.last.EYE.Navigate(m_MainMenu);
                return;
            }

            switch (m_eCurrentGame)
            {
                case MenuElement.MenuElementType.ME_SELECT:
                    if (MainWindow.last.menuSelect.IsChecked())
                    {
                        MainWindow.last.menuSelect.Select();
                        MainWindow.last.EYE.Navigate(m_Choosing);
                        return;
                    }
                    break;
                case MenuElement.MenuElementType.ME_LEARN_EATING:
                    if (MainWindow.last.menuLearnEating.IsChecked())
                    {
                        MainWindow.last.menuLearnEating.Select();
                        MainWindow.last.EYE.Navigate(m_Training);
                        m_Training.StartGame();
                        return;
                    }
                    break;
                case MenuElement.MenuElementType.ME_LEARN_TIMES:
                    if (MainWindow.last.menuLearnTimes.IsChecked())
                        MainWindow.last.menuLearnTimes.Select();
                    break;
                case MenuElement.MenuElementType.ME_GAME_EATING:
                    if (MainWindow.last.menuGameEating.IsChecked())
                    {
                        MainWindow.last.menuGameEating.Select();
                        MainWindow.last.EYE.Navigate(m_Test1);
                        m_Test1.StartGame();
                        return;
                    }
                    break;
                case MenuElement.MenuElementType.ME_GAME_EXCLUDING:
                    if (MainWindow.last.menuGameExcluding.IsChecked())
                        MainWindow.last.menuGameExcluding.Select();
                    break;
                case MenuElement.MenuElementType.ME_CAME_COMPARISON:
                    if (MainWindow.last.menuGameCmp.IsChecked())
                    {
                        MainWindow.last.menuGameCmp.Select();
                        MainWindow.last.EYE.Navigate(m_cmpPage);
                        m_cmpPage.StartGame();
                        return;
                    }
                    break;
            }

            NextGame();
        }

        public void BackToMenu()
        {
            UnselectCurrent();

            m_eCurrentGame = MenuElement.MenuElementType.ME_NONE;
            MainWindow.last.EYE.Navigate(m_MainMenu);
        }
    }
}
