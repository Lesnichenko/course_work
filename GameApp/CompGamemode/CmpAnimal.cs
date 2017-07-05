
using System.Windows;
using GameApp.Animals;

namespace GameApp.CompGamemode
{
    class CmpAnimal : CmpButton.CmpButtonCallback
    {
        private Animal    m_Animal;
        private CmpButton m_Control;
        private CmpGame   m_Parent;
        private bool      m_bChecked;
        private bool      m_bEnabled;

        public CmpAnimal(CmpGame parent, CmpButton control, AnimalType eType, AnimalAge eAge)
        {
            m_Parent  = parent;
            m_Control = control;

            switch(eType)
            {
                case AnimalType.AT_BEAR:
                    m_Animal = new Bear(eAge);
                    break;
                case AnimalType.AT_ELK:
                    m_Animal = new Elk(eAge);
                    break;
                case AnimalType.AT_FOX:
                    m_Animal = new Fox(eAge);
                    break;
                case AnimalType.AT_HARE:
                    m_Animal = new Hare(eAge);
                    break;
                case AnimalType.AT_HEDGEHOG:
                    m_Animal = new Hedgehog(eAge);
                    break;
                case AnimalType.AT_LYNX:
                    m_Animal = new Lynx(eAge);
                    break;
                case AnimalType.AT_SQUIRREL:
                    m_Animal = new Squirrel(eAge);
                    break;
                case AnimalType.AT_WOLF:
                    m_Animal = new Wolf(eAge);
                    break;
            }

            m_Control.SetCallback(this);
            m_Control.SetImage(m_Animal.GetImagePath());
            Uncheck();
            Enable();
        }

        public override void OnClick(bool bChecked)
        {
            //MessageBox.Show(this.ToString() + "(" + bChecked + ")");
            m_bChecked = bChecked;
            m_Parent.OnButtonCheck(bChecked);
        }

        public void Check()
        {
            m_Control.EnableState(CmpButtonState.CBS_CHECKED);
            m_bChecked = true;
        }

        public void Uncheck()
        {
            m_bChecked = false;
            m_Control.DisableState(CmpButtonState.CBS_CHECKED);
        }

        public void Enable()
        {
            m_bEnabled = true;
            m_Control.DisableState(CmpButtonState.CBS_DISABLED);
        }

        public void Disable()
        {
            m_bEnabled = false;
            m_Control.EnableState(CmpButtonState.CBS_DISABLED);
        }

        public bool IsEnabled()
        {
            return m_bEnabled;
        }

        public bool IsChecked()
        {
            return m_bChecked;
        }

        public Animal GetAnimal()
        {
            return m_Animal;
        }

        public void PlayRightAnimation()
        {
            m_Control.RightAnimation();
        }

        public void PlayWrongAnimation()
        {
            m_Control.WrongAnimation();
        }
    }
}
