using System;
using System.Collections.Generic;
using System.Text;

namespace GameApp.Animals
{
    class Bear : Animal
    {
        public Bear(AnimalAge eAge)
        {
            m_eAge     = eAge;
            m_eType    = AnimalType.AT_BEAR;
            m_asImages = new string[] { "/Image/gait/bear/giphy_1.png", "/Image/CmpGM/AnimalChildren/bear.png" };

            m_sCmpSuccessImage = "/Image/CmpGM/AnimalCmpSuccess/bear.png";
        }
    }
}
