
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace GameApp.SelectionGamemode
{
    class SelButton : Button
    {
        public interface SelButtonCallback
        {
            void OnClick(bool bValid);
        };

        private SelButtonCallback m_Callback;
        private bool              m_bValid;
        private Image             m_Img, m_animImg, m_checkImg;
        private Path m_Path;
        private bool m_bHover, m_bDisabled, m_bShowCheck;
        private bool m_bIgnoreAnimEnd;

        private static ImageSource[] m_aAnimImages = null;

        public SelButton()
        {
            this.SizeChanged += OnSizeChanged;

            m_bHover = m_bDisabled = false;

            if(m_aAnimImages == null)
            {
                m_aAnimImages = new ImageSource[2] 
                {
                    ResourceController.GetResourceBitmap("/Image/CmpGM/cmp_wrong.png"),
                    ResourceController.GetResourceBitmap("/Image/CmpGM/cmp_right.png")
                };
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            m_Img = (Image)GetTemplateChild("contentImage");
            m_Path = (Path)GetTemplateChild("background");
            m_animImg = (Image)GetTemplateChild("animImage");
            m_checkImg = (Image)GetTemplateChild("checkImage");
        }

        public void SetCallback(SelButtonCallback callback, string imagePath, bool bValid)
        {
            m_Callback = callback;
            m_Img.Source = ResourceController.GetResourceBitmap(imagePath);
            m_bValid = bValid;

            m_bIgnoreAnimEnd = true;
            m_animImg.BeginAnimation(Image.OpacityProperty, null);
            m_animImg.Source = m_aAnimImages[bValid ? 1 : 0];
            m_animImg.Opacity = 0.0;

            m_bDisabled = false;
            m_bShowCheck = false;
            Update();

        }

        protected override void OnClick()
        {
            base.OnClick();

            if (m_bDisabled)
                return;

            m_Callback.OnClick(m_bValid);

            m_bDisabled = true;
            Update();
            PlayAnimation();
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);

            if (m_bDisabled)
                return;

            m_bHover = true;
            Update();
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);

            m_bHover = false;
            Update();
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs args)
        {
            if(m_bShowCheck || m_bHover)
                m_Path.StrokeThickness = 0.05 * ActualHeight;
            else
                m_Path.StrokeThickness = 0.0;

            if(m_bDisabled || m_bShowCheck)
                Cursor = Cursors.Arrow;
            else
                Cursor = Cursors.Hand;
            if (m_bShowCheck)
                m_Path.Stroke = new SolidColorBrush(Color.FromRgb(87, 135, 70));
            else if (m_bHover)
                m_Path.Stroke = new SolidColorBrush(Color.FromRgb(125, 91, 23));

            m_checkImg.Opacity = m_bShowCheck ? 0.75 : 0.0;

        }

        private void Update()
        {
            OnSizeChanged(null, null);
        }

        private void PlayAnimation()
        {
            const int nFlashCount = 3, nTotalCount = nFlashCount * 2;
            const double dFrameTime = 0.3;
            
            DoubleAnimationUsingKeyFrames anim = new DoubleAnimationUsingKeyFrames();
            DoubleKeyFrameCollection kfCollection = new DoubleKeyFrameCollection();
            

            double dCurTime = 0.0;
            for (int i = 0; i < nTotalCount; i++)
            {
                DoubleKeyFrame keyFrame = new DiscreteDoubleKeyFrame();

                keyFrame.KeyTime = TimeSpan.FromSeconds(dCurTime);
                keyFrame.Value = (i % 2 == 0) ? 0.75 : 0;

                kfCollection.Add(keyFrame);

                dCurTime += (i == 0 && !m_bValid) ? 1.0 : dFrameTime;
            }

            anim.KeyFrames = kfCollection;
            anim.Duration = TimeSpan.FromSeconds(dCurTime);
            anim.Completed += OnAnimationCompleted;

            m_animImg.BeginAnimation(Image.OpacityProperty, anim);
            m_bIgnoreAnimEnd = false;
        }

        private void OnAnimationCompleted(object sender, EventArgs args)
        {
            if (m_bIgnoreAnimEnd)
                return;

            if (!m_bValid)
                m_bDisabled = false;
            else
                m_bShowCheck = true;


            Update();
        }
    }
}
