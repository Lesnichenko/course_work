
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace GameApp
{
    class MenuExpandButton : Button
    {
        private Image m_Img;
        private double m_dAngle;

        public MenuExpandButton()
        {
            m_dAngle = 0.0;

            this.SizeChanged += OnSizeChanged;
        }

        public override void OnApplyTemplate()
        {
            m_Img = (Image)GetTemplateChild("expanderButtonImage");
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs args)
        {
            SetRotation(m_dAngle);
        }

        public void SetRotation(double dRot)
        {
            RotateTransform trans = new RotateTransform(dRot, m_Img.ActualWidth/2, m_Img.ActualHeight/2);
            m_Img.RenderTransform = trans;
            m_dAngle = dRot;
        }
    }
}
