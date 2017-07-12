using System;
using System.Collections.Generic;
using System.Text;

namespace GameApp.Animals
{
    class Fox : Animal
    {
        public Fox(AnimalAge eAge)
        {
            m_eAge     = eAge;
            m_eType    = AnimalType.AT_FOX;
            m_asImages = new string[] { "/Image/gait/fox/giphy_1.png", "/Image/CmpGM/AnimalChildren/fox.png" };

            m_sCmpSuccessImage = "/Image/CmpGM/AnimalCmpSuccess/fox.png";
            m_sLabelImage = "/Image/SelGM/fox.png";

            m_aeFood = new FoodBase.FoodType[3]
            {
                FoodBase.FoodType.FT_RODENT,
                FoodBase.FoodType.FT_BUG,
                FoodBase.FoodType.FT_BERRY,
            };
        }
    }
}