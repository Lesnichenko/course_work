using System;
using System.Collections.Generic;
using System.Text;

namespace GameApp.Animals
{
    class Wolf : Animal
    {
        public Wolf(AnimalAge eAge)
        {
            m_eAge     = eAge;
            m_eType    = AnimalType.AT_WOLF;
            m_asImages = new string[] { "/Image/gait/wolf/1.png", "/Image/CmpGM/AnimalChildren/wolf.png" };

            m_sCmpSuccessImage = "/Image/CmpGM/AnimalCmpSuccess/wolf.png";
        }
    }
}
