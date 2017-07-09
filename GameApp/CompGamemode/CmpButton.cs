
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
        CBS_DEFAULT    = 0x0,
        CBS_HOVER      = 0x1,
        CBS_CHECKED    = 0x2,
        CBS_DISABLED   = 0x4,
        CBS_SHOW_CHECK = 0x8,
    };

    public class CmpButton : Button
    {     
        public abstract class CmpButtonCallback
        {
            public abstract void OnClick(bool bChecked);
        };

        private int                m_nState;
        private CmpButtonCallback  m_Callback;
        private Image m_CheckImg;
        private static ImageSource m_WrongImage = null;
        private static ImageSource m_RightImage = null;
        private CmpPage            m_Parent;
        private bool m_bIgnoreAnimEnd;

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

        public void LinkParent(CmpPage page)
        {
            m_Parent = page;
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

        public override void OnApplyTemplate()
        {
            m_CheckImg = (Image)GetTemplateChild("ButtonCheckImage");
        }

        public void SetImage(string imagePath)
        {
            Image img = (Image)this.GetTemplateChild("ButtonImage");

            img.Source = ResourceController.GetResourceBitmap(imagePath);
        }

        private void OnSizeChanged(object sender, RoutedEventArgs args)
        {
            Path ellipsePath = (Path)this.GetTemplateChild("ButtonEllipse");

            if((m_nState & (int)CmpButtonState.CBS_SHOW_CHECK) != 0)
            {
                ellipsePath.Stroke = new SolidColorBrush(Color.FromRgb(87, 135, 70));
                ellipsePath.StrokeThickness = m_Parent.ActualHeight * 0.0125;//ellipsePath.ActualWidth * 0.05;
                m_CheckImg.Opacity = 0.75;
                return;
            }
    
            ellipsePath.Stroke = new SolidColorBrush(Color.FromRgb(/*128, 0, 0*/ 125, 91, 23));

            if ((m_nState & (int)CmpButtonState.CBS_CHECKED) != 0 ||
                (m_nState & (int)CmpButtonState.CBS_HOVER) != 0)
                ellipsePath.StrokeThickness = m_Parent.ActualHeight * 0.0125;//ellipsePath.ActualWidth * 0.025;
            else
                ellipsePath.StrokeThickness = 0.0;

            m_CheckImg.Opacity = 0.0;
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

            if ((m_nState & (int)CmpButtonState.CBS_SHOW_CHECK) != 0)
                Cursor = Cursors.Arrow;
            else
                Cursor = Cursors.Hand;
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

            m_bIgnoreAnimEnd = true;

            m_Callback = callback;

            m_nState    = (int)CmpButtonState.CBS_DEFAULT;
            img.BeginAnimation(Image.OpacityProperty, null);
            img.Opacity = 0.0;
            UpdateButton();
        }

        public void RightAnimation()
        {
            const int    nFlashCount = 8, nTotalCount = nFlashCount * 2;
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
            anim.Completed += OnRightAnimationComplete;

            img.BeginAnimation(Image.OpacityProperty, anim);
            m_bIgnoreAnimEnd = false;
        }

        private void OnRightAnimationComplete(object sender, EventArgs args)
        {
            if(!m_bIgnoreAnimEnd)  
                EnableState(CmpButtonState.CBS_SHOW_CHECK);
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
            for (int i = 0; i < nTotalCount; i++)
            {
                DoubleKeyFrame keyFrame = new DiscreteDoubleKeyFrame();

                keyFrame.KeyTime = TimeSpan.FromSeconds(dCurTime);
                keyFrame.Value   = (i % 2 == 0) ? 0.75 : 0;

                kfCollection.Add(keyFrame);

                dCurTime += (i == 0) ? 1.0 : dFrameTime;
            }

            anim.KeyFrames  = kfCollection;
            anim.Duration   = TimeSpan.FromSeconds(dCurTime);
            anim.Completed += OnWrongAnimationComplete;

            img.BeginAnimation(Image.OpacityProperty, anim);
            m_bIgnoreAnimEnd = false;
        }

        private void OnWrongAnimationComplete(object sender, EventArgs args)
        {
            if(!m_bIgnoreAnimEnd)
                DisableState(CmpButtonState.CBS_DISABLED);
        }
    }
}
