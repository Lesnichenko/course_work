
using System;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace GameApp.CompGamemode
{
    public enum CmpButtonState
    {
        CBS_DEFAULT  = 0x0,
        CBS_HOVER    = 0x1,
        CBS_CHECKED  = 0x2,
        CBS_DISABLED = 0x4,
    };

    public class CmpButton : Button
    {     
        public abstract class CmpButtonCallback
        {
            public abstract void OnClick(bool bChecked);
        };

        private int                m_nState;
        private CmpButtonCallback  m_Callback;
        private static ImageSource m_WrongImage = null;
        private static ImageSource m_RightImage = null;

        public CmpButton()
        {
            m_nState   = (int)CmpButtonState.CBS_DEFAULT;
            m_Callback = null;

            this.SizeChanged += OnSizeChanged;

            if (m_WrongImage == null)
                m_WrongImage = ResourceController.GetResourceBitmap("/Image/CmpGM/cmp_wrong.png");

            if (m_RightImage == null)
                m_RightImage = ResourceController.GetResourceBitmap("/Image/CmpGM/cmp_right.png");
        }

        protected override void OnClick()
        {
            base.OnClick();

            if ((m_nState & (int)CmpButtonState.CBS_DISABLED) != 0)
                return;

            //MessageBox.Show(this.Name);
            if ((m_nState & (int)CmpButtonState.CBS_CHECKED) != 0)
                DisableState(CmpButtonState.CBS_CHECKED);
            else
                EnableState(CmpButtonState.CBS_CHECKED);

            if(m_Callback != null)
                m_Callback.OnClick((m_nState & (int)CmpButtonState.CBS_CHECKED) != 0);
        }

        public void SetImage(string imagePath)
        {
            Image img = (Image)this.GetTemplateChild("ButtonImage");

            img.Source = ResourceController.GetResourceBitmap(imagePath);
        }

        private void OnSizeChanged(object sender, RoutedEventArgs args)
        {
            Path ellipsePath = (Path)this.GetTemplateChild("ButtonEllipse");
    
            ellipsePath.Stroke = new SolidColorBrush(Color.FromRgb(128, 0, 0));

            if ((m_nState & (int)CmpButtonState.CBS_CHECKED) != 0 || 
                (m_nState & (int)CmpButtonState.CBS_HOVER) != 0)
                ellipsePath.StrokeThickness = ellipsePath.ActualWidth * 0.025;
            else
                ellipsePath.StrokeThickness = 0.0;
        }

        public void EnableState(CmpButtonState eState)
        {
            m_nState |= (int)eState;
            UpdateButton();
        }

        public void DisableState(CmpButtonState eState)
        {
            m_nState &= ~(int)eState;
            UpdateButton();
        }

        public void UpdateButton()
        {
            OnSizeChanged(this, null);
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);

            if ((m_nState & (int)CmpButtonState.CBS_DISABLED) != 0)
                return;

            EnableState(CmpButtonState.CBS_HOVER);
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);

            /*if ((m_nState & (int)CmpButtonState.CBS_DISABLED) != 0)
                return;*/

            DisableState(CmpButtonState.CBS_HOVER);
        }

        public void SetCallback(CmpButtonCallback callback)
        {
            Image img = (Image)this.GetTemplateChild("ButtonAnimImage");

            m_Callback = callback;

            m_nState    = (int)CmpButtonState.CBS_DEFAULT;
            img.BeginAnimation(Image.OpacityProperty, null);
            img.Opacity = 0.0;
            UpdateButton();
        }

        public void RightAnimation()
        {
            const int    nFlashCount = 8, nTotalCount = nFlashCount * 2 + 1;
            const double dFrameTime = 0.3;

            Image                         img = (Image)this.GetTemplateChild("ButtonAnimImage");
            DoubleAnimationUsingKeyFrames anim = new DoubleAnimationUsingKeyFrames();
            DoubleKeyFrameCollection      kfCollection = new DoubleKeyFrameCollection();

            img.Source  = m_RightImage;
            img.Opacity = 0.0;

            double dCurTime = 0.0;
            for (int i = 0; i < nTotalCount; i++, dCurTime += dFrameTime)
            {
                DoubleKeyFrame keyFrame = new DiscreteDoubleKeyFrame();

                keyFrame.KeyTime = TimeSpan.FromSeconds(dCurTime);
                keyFrame.Value = (i % 2 == 0) ? 0.75 : 0;

                kfCollection.Add(keyFrame);
            }

            anim.KeyFrames = kfCollection;
            anim.Duration  = TimeSpan.FromSeconds(dCurTime);

            img.BeginAnimation(Image.OpacityProperty, anim);
        }

        public void WrongAnimation()
        {
            const int    nFlashCount = 3, nTotalCount = nFlashCount * 2;
            const double dFrameTime = 0.3;

            Image img                             = (Image)this.GetTemplateChild("ButtonAnimImage");
            DoubleAnimationUsingKeyFrames anim    = new DoubleAnimationUsingKeyFrames();
            DoubleKeyFrameCollection kfCollection = new DoubleKeyFrameCollection();

            EnableState(CmpButtonState.CBS_DISABLED);

            img.Source  = m_WrongImage;
            img.Opacity = 0.0;

            double dCurTime = 0.0;
            for (int i = 0; i < nTotalCount; i++, dCurTime += dFrameTime)
            {
                DoubleKeyFrame keyFrame = new DiscreteDoubleKeyFrame();

                keyFrame.KeyTime = TimeSpan.FromSeconds(dCurTime);
                keyFrame.Value   = (i % 2 == 0) ? 0.75 : 0;

                kfCollection.Add(keyFrame);
            }

            anim.KeyFrames  = kfCollection;
            anim.Duration   = TimeSpan.FromSeconds(dCurTime);
            anim.Completed += OnWrongAnimationComplete;

            img.BeginAnimation(Image.OpacityProperty, anim);
        }

        private void OnWrongAnimationComplete(object sender, EventArgs args)
        {
            DisableState(CmpButtonState.CBS_DISABLED);
        }
    }
}
