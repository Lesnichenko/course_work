﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GameApp.Animals
{
    class Lynx : Animal
    {
        public Lynx(AnimalAge eAge)
        {
            m_eAge     = eAge;
            m_eType    = AnimalType.AT_LYNX;
            m_asImages = new string[] { "/Image/gait/lynx/1.png", "/Image/CmpGM/AnimalChildren/lynx.png" };

            m_sCmpSuccessImage = "/Image/CmpGM/AnimalCmpSuccess/lynx.png";
            m_sLabelImage = "/Image/SelGM/lynx.png";

            m_aeFood = new FoodBase.FoodType[3]
            {
                FoodBase.FoodType.FT_RODENT,
                FoodBase.FoodType.FT_BUG,
                FoodBase.FoodType.FT_BERRY,
            };
        }
    }
}
