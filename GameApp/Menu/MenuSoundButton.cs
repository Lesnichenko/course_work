
using System.Windows.Controls;
using System.Windows.Media;

namespace GameApp
{
    class MenuSoundButton : Button
    {
        private bool m_bChecked;
        private Image m_Img;
        private ImageSource m_Checked = null, m_Unchecked = null;

        public MenuSoundButton()
        {
            m_bChecked = true;

            if (m_Checked == null)
                m_Checked = ResourceController.GetResourceBitmap("/Image/Menu/sound_btn_checked.png");

            if (m_Unchecked == null)
                m_Unchecked = ResourceController.GetResourceBitmap("/Image/Menu/sound_btn_unchecked.png");

        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            m_Img = (Image)GetTemplateChild("buttonImg");

            Update();
        }

        protected override void OnClick()
        {
            base.OnClick();

            m_bChecked = !m_bChecked;
            Update();
        }

        private void Update()
        {
            m_Img.Source = (m_bChecked) ? m_Checked : m_Unchecked;
        }

        public bool IsChecked()
        {
            return m_bChecked; 
        }
    }
}
