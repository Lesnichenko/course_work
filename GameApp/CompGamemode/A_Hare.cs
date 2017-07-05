using System;
using System.Collections.Generic;
using System.Text;

namespace GameApp.Animals
{
    class Hare : Animal
    {
        public Hare(AnimalAge eAge)
        {
            m_eAge     = eAge;
            m_eType    = AnimalType.AT_HARE;
            m_asImages = new string[] { "/Image/gait/hare/1.png", "/Image/CmpGM/AnimalChildren/hare.png" };

            m_sCmpSuccessImage = "/Image/CmpGM/AnimalCmpSuccess/hare.png";
        }
    }
}
