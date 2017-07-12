using System;
using System.Collections.Generic;
using System.Text;

namespace GameApp.Animals
{
    class Elk : Animal
    {
        public Elk(AnimalAge eAge)
        {
            m_eAge     = eAge;
            m_eType    = AnimalType.AT_ELK;
            m_asImages = new string[] { "/Image/gait/elk/1.png", "/Image/CmpGM/AnimalChildren/elk.png" };

            m_sCmpSuccessImage = "/Image/CmpGM/AnimalCmpSuccess/elk.png";
            m_sLabelImage = "/Image/SelGM/elk.png";

            m_aeFood = new FoodBase.FoodType[3]
            {
                FoodBase.FoodType.FT_RODENT,
                FoodBase.FoodType.FT_BUG,
                FoodBase.FoodType.FT_BERRY,
            };
        }
    }
}
