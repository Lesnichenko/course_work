using System;
using System.Collections.Generic;
using System.Text;

namespace GameApp.Animals
{
    class Hedgehog : Animal
    {
        public Hedgehog(AnimalAge eAge)
        {
            m_eAge     = eAge;
            m_eType    = AnimalType.AT_HEDGEHOG;
            m_asImages = new string[] { "/Image/gait/hedgehog/1.png", "/Image/CmpGM/AnimalChildren/hedgehog.png" };

            m_sCmpSuccessImage = "/Image/CmpGM/AnimalCmpSuccess/hedgehog.png";
        }
    }
}
