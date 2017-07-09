
using System;
using System.Windows;
using System.Collections;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace GameApp
{
    class Menu : Canvas
    {
        private enum ExpanderState
        {
            ES_HIDDEN,
            ES_EXPAND_ANIMATION,
            ES_HIDE_ANIMATION,
            ES_EXPANDED
        };


 //       private Grid          m_Grid;
 //       private Button        m_Expander;
        private ExpanderState m_eState;
        private const double  m_dSecondsPerDot = 0.0015;
   //     private double        m_W, m_H;
     //   private Size          m_CurrentSize;
 //       private Storyboard    m_SB;

        public Menu()
        {
            this.Loaded      += OnLoaded;
            this.SizeChanged += OnSizeChanged;

  //          m_Grid = null;
        }

        private void OnLoaded(object sender, RoutedEventArgs args)
        {
            /*IEnumerator en = Children.GetEnumerator();

            en.MoveNext(); m_Grid = (Grid)en.Current;

            en = m_Grid.Children.GetEnumerator();
           
            while(en.MoveNext())
            {
                if(en.Current.GetType())
                Button btn = (Button)en.Current;

                if(btn != null && btn.Name == "expanderButton")
                {
                    m_Expander = btn;
                    break;
                }
            }*/

            /*m_Grid = MainWindow.last.menuGrid;
            m_Expander = MainWindow.last.expanderButton;*/
            

            m_eState = ExpanderState.ES_HIDDEN;
            //SetLeft(MainWindow.last.menuGrid, 0.0);
            MainWindow.last.menuSelect.LinkParent(this, MenuElement.MenuElementType.ME_SELECT);
            MainWindow.last.menuLearnEating.LinkParent(this, MenuElement.MenuElementType.ME_LEARN_EATING);
            MainWindow.last.menuLearnTimes.LinkParent(this, MenuElement.MenuElementType.ME_LEARN_TIMES);
            MainWindow.last.menuGameEating.LinkParent(this, MenuElement.MenuElementType.ME_GAME_EATING);
            MainWindow.last.menuGameExcluding.LinkParent(this, MenuElement.MenuElementType.ME_GAME_EXCLUDING);
            MainWindow.last.menuGameCmp.LinkParent(this, MenuElement.MenuElementType.ME_CAME_COMPARISON);
            MainWindow.last.expanderButton.SetRotation(180);
        }

        public void OnButtonClicked(object sender)
        {
            if (sender.Equals(MainWindow.last.expanderButton))
                ExpanderAction();
            else if (sender.Equals(MainWindow.last.menuBackButton))
            {
                MainWindow.last.m_gmCtl.BackToMenu();
                HideMenu();
            }
            else if (sender.Equals(MainWindow.last.menuBtnStart))
            {
                MainWindow.last.m_gmCtl.StartGame();
                HideMenu();
            }
            else if (sender.Equals(MainWindow.last.menuBtnAbout))
            {
                MainWindow.last.ShowAbout();
                HideMenu();
            }
        }

        public void OnSizeChanged(object sender, SizeChangedEventArgs args)
        {
            //m_CurrentSize = args.NewSize;

          /*  if (m_eState == ExpanderState.ES_EXPAND_ANIMATION || m_eState == ExpanderState.ES_HIDE_ANIMATION)
            {
             

                if (m_eState == ExpanderState.ES_HIDE_ANIMATION)
                    HideMenu();
                else
                    ShowMenu();
            }
            else */if (MainWindow.last.menuGrid != null)
                UpdateMenu();
            
        }

        /*public void Resize(double w, double h, double x, double y)
        {
            Width = w;
            Height = h;
            m_W = w;
            m_H = h;

           
        }*/

        private void ExpanderAction()
        {
            switch(m_eState)
            {
                case ExpanderState.ES_EXPAND_ANIMATION:
                case ExpanderState.ES_HIDE_ANIMATION:
                    return;

                case ExpanderState.ES_EXPANDED:
                    HideMenu();
                    return;

                case ExpanderState.ES_HIDDEN:
                    ShowMenu();
                    return;
            }
            
        }

        private void ShowMenu()
        {
            DoubleAnimation  anim = new DoubleAnimation();

            MainWindow.last.expanderButton.SetRotation(0);
           
            anim.From       = GetLeft(MainWindow.last.menuGrid);
            anim.To         = ActualWidth - MainWindow.last.mainWindowMainGrid.ActualWidth;
            anim.Duration   = TimeSpan.FromSeconds(m_dSecondsPerDot * Math.Abs((double)(anim.To - anim.From)));
            anim.Completed += OnExpandActionComplete;

            MainWindow.last.menuGrid.BeginAnimation(LeftProperty, anim);
            

            m_eState = ExpanderState.ES_EXPAND_ANIMATION;
            
        }

        private void OnExpandActionComplete(object sender, EventArgs args)
        {
            if (m_eState == ExpanderState.ES_EXPAND_ANIMATION)
                m_eState = ExpanderState.ES_EXPANDED;
            else
                m_eState = ExpanderState.ES_HIDDEN;

           /* double dLeft = GetLeft(m_Grid);
            m_Grid.BeginAnimation(Canvas.LeftProperty, null);
            SetLeft(m_Grid, dLeft);*/
          //  m_SB.Stop();
        }

        private void HideMenu()
        {
            DoubleAnimation anim = new DoubleAnimation();

            if (m_eState == ExpanderState.ES_HIDDEN)
                return;

            MainWindow.last.expanderButton.SetRotation(180);

            anim.From = GetLeft(MainWindow.last.menuGrid);
            anim.To = 0;
            anim.Duration = TimeSpan.FromSeconds(m_dSecondsPerDot * Math.Abs((double)(anim.To - anim.From)));
            anim.Completed += OnExpandActionComplete;

            MainWindow.last.menuGrid.BeginAnimation(LeftProperty, anim);


            m_eState = ExpanderState.ES_HIDE_ANIMATION;
        }

        private void UpdateMenu()
        {
            MainWindow.last.menuGrid.BeginAnimation(Canvas.LeftProperty, null);

            if (m_eState == ExpanderState.ES_EXPANDED || m_eState == ExpanderState.ES_EXPAND_ANIMATION)
                SetLeft(MainWindow.last.menuGrid, ActualWidth - MainWindow.last.mainWindowMainGrid.ActualWidth);
            else
                SetLeft(MainWindow.last.menuGrid, 0);
               
        }
    }
}
