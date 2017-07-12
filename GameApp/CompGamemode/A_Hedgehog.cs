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
            m_sLabelImage = "/Image/SelGM/hedgehog.png";

            m_aeFood = new FoodBase.FoodType[11]
            {
                FoodBase.FoodType.FT_CARROT,
                FoodBase.FoodType.FT_PLANT,
                FoodBase.FoodType.FT_FISH,
                FoodBase.FoodType.FT_HAY,
                FoodBase.FoodType.FT_APPLE,
                FoodBase.FoodType.FT_RODENT,
                FoodBase.FoodType.FT_BUG,
                FoodBase.FoodType.FT_NUTS,
                FoodBase.FoodType.FT_SNAIL,
                FoodBase.FoodType.FT_WORM,
                FoodBase.FoodType.FT_BERRY,
            };
        }
    }
}
