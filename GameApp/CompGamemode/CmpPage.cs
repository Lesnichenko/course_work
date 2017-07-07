﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

using System.Windows.Media;
using System;
using System.Windows.Media.Imaging;
using GameApp;

namespace GameApp.CompGamemode
{
    partial class CmpPage : Page
    {
        private CmpGame m_Game;
        private bool    m_bPageLoaded, m_bNeedStart;
        private GameModeController m_gmCtl;

        public CmpPage(GameModeController gmCtl)
        {
            m_gmCtl = gmCtl;

            InitializeComponent();

            backgroundImage.Source = ResourceController.GetResourceBitmap("/Image/CmpGM/bg.jpg");
            titleImage.Source      = ResourceController.GetResourceBitmap("/Image/CmpGM/cmp_gmode_title.png");

            m_Game = new CmpGame(this, new CmpButton[] 
            {
                cmpButton_0_0, cmpButton_0_1, cmpButton_0_2,
                cmpButton_1_0, cmpButton_1_1, cmpButton_1_2
            });

            m_bPageLoaded = m_bNeedStart = false;

            this.Loaded += OnPageLoad;
            this.SizeChanged += OnSizeChanged;
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs args)
        {
            //titleLabel.FontSize = ActualHeight * 0.08;
        }

        public void StartGame()
        {
            if (m_bPageLoaded)
                m_Game.RestartGame();
            else
                m_bNeedStart = true;
        }

        public void OnPageLoad(object sender, RoutedEventArgs args)
        {
            m_bPageLoaded = true;

            if(m_bNeedStart)
            {
                m_bNeedStart = false;
                m_Game.RestartGame();
            }

            messageCanvas.Opacity          = 0.0;
            messageCanvas.IsHitTestVisible = false;
        }

        public void PlayMessageAnimation(string imagePath)
        {
            DoubleAnimationUsingKeyFrames anim         = new DoubleAnimationUsingKeyFrames();
            DoubleAnimationUsingKeyFrames animBG = new DoubleAnimationUsingKeyFrames();
            DoubleKeyFrameCollection      kfCollection = new DoubleKeyFrameCollection();
            DoubleKeyFrameCollection kfBGCollection = new DoubleKeyFrameCollection();
            DoubleKeyFrame[]              aFrames      = new SplineDoubleKeyFrame[4] 
            {
                new SplineDoubleKeyFrame(), new SplineDoubleKeyFrame(), new SplineDoubleKeyFrame(), new SplineDoubleKeyFrame()
            };

            DoubleKeyFrame[] aBGFrames = new SplineDoubleKeyFrame[4]
            {
                new SplineDoubleKeyFrame(), new SplineDoubleKeyFrame(), new SplineDoubleKeyFrame(), new SplineDoubleKeyFrame()
            };

            messageCanvas.IsHitTestVisible = true;

            messageImage.Source = ResourceController.GetResourceBitmap(imagePath);

            aFrames[0].KeyTime = TimeSpan.FromSeconds(0.0);
            aFrames[0].Value   = 0.0;
            aFrames[1].KeyTime = TimeSpan.FromSeconds(1.0);
            aFrames[1].Value   = 1.0;
            aFrames[2].KeyTime = TimeSpan.FromSeconds(3.0);
            aFrames[2].Value   = 1.0;
            aFrames[3].KeyTime = TimeSpan.FromSeconds(4.0);
            aFrames[3].Value   = 0.0;

            aBGFrames[0].KeyTime = TimeSpan.FromSeconds(0.0);
            aBGFrames[0].Value = 1.0;
            aBGFrames[1].KeyTime = TimeSpan.FromSeconds(1.0);
            aBGFrames[1].Value = 0.0;
            aBGFrames[2].KeyTime = TimeSpan.FromSeconds(3.0);
            aBGFrames[2].Value = 0.0;
            aBGFrames[3].KeyTime = TimeSpan.FromSeconds(4.0);
            aBGFrames[3].Value = 1.0;

            for (int i = 0; i < aFrames.Length; i++)
            {
                kfCollection.Add(aFrames[i]);
                kfBGCollection.Add(aBGFrames[i]);
            }

            anim.KeyFrames  = kfCollection;
            anim.Duration   = TimeSpan.FromSeconds(4.0);
            anim.Completed += OnMessageAnimationComplete;

            animBG.KeyFrames = kfBGCollection;
            animBG.Duration = TimeSpan.FromSeconds(4.0);
            animBG.Completed += OnMessageAnimationComplete;


            messageCanvas.BeginAnimation(Canvas.OpacityProperty, anim);
            pageMainGrid.BeginAnimation(Grid.OpacityProperty, animBG);
        }

        private void OnMessageAnimationComplete(object sender, EventArgs args)
        {
            messageCanvas.IsHitTestVisible = false;
        }

        public void NextButtonClick(object sender, RoutedEventArgs args)
        {
            //m_Game.RestartGame();
            m_gmCtl.NextGame();
        }

        public void RestartButtonClick(object sender, RoutedEventArgs args)
        {
            StartGame();
        }

        /*public void TestClick(object sender, RoutedEventArgs args)
        {
            Button s = sender as Button;

            MessageBox.Show("Clicked. " + (sender.Equals(CmpButton_0_0)));
        }*/
    }
}
