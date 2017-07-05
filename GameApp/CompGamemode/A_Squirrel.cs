using System;
using System.Collections.Generic;
using System.Text;

namespace GameApp.Animals
{
    class Squirrel : Animal
    {
        public Squirrel(AnimalAge eAge)
        {
            m_eAge     = eAge;
            m_eType    = AnimalType.AT_SQUIRREL;
            m_asImages = new string[] { "/Image/gait/squirrel/1.png", "/Image/CmpGM/AnimalChildren/squirrel.png" };

            m_sCmpSuccessImage = "/Image/CmpGM/AnimalCmpSuccess/squirrel.png";
        }
    }
}
