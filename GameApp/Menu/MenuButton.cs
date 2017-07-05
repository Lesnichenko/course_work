
using System.Windows.Controls;
using System.Windows.Media;

namespace GameApp
{
    class MenuButton : Button
    {
        private MenuElement m_Element;
        private Image m_Img;
        private bool m_bChecked;
        private static ImageSource m_Checked = null;
        private static ImageSource m_Unchecked = null;

        public MenuButton()
        {
            if (m_Checked == null)
                m_Checked = ResourceController.GetResourceBitmap("/Image/Menu/checked.png");

            if (m_Unchecked == null)
                m_Unchecked = ResourceController.GetResourceBitmap("/Image/Menu/unchecked.png");

            m_bChecked = false;
          //  Update();
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            m_Img = (Image)GetTemplateChild("menuElementButtonImage");
            Update();
        }

        public void LinkParent(MenuElement menuElement)
        {
            m_Element = menuElement;
        }

        protected override void OnClick()
        {
            base.OnClick();

            m_bChecked = !m_bChecked;

            m_Element.OnClick(m_bChecked);

            Update();
        }

        private void Update()
        {
            m_Img.Source = (m_bChecked) ? m_Checked : m_Unchecked;
        }
    }
}
