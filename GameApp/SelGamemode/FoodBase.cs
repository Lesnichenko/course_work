

namespace GameApp.FoodBase
{
    public enum FoodType
    {
        FT_CARROT,
        FT_PLANT,
        FT_FISH,
        FT_HAY,
        FT_APPLE,
        FT_RODENT,
        FT_BUG,
        FT_NUTS,
        FT_SNAIL,
        FT_WORM,
        FT_BERRY,
        NUM_FOOD_TYPES
    };

    class FoodBase
    {
        private static string[] m_asFoddImages = new string[(int)FoodType.NUM_FOOD_TYPES]
        {
            "/Image/food/morkov.png",
            "/Image/food/rastenia.png",
            "/Image/food/ryba.png",
            "/Image/food/seno.png",
            "/Image/food/yablochko.png",
            "/Image/food/грызун.png",
            "/Image/food/жук.png",
            "/Image/food/орехи.png",
            "/Image/food/улитка.png",
            "/Image/food/черви.png",
            "/Image/food/ягоды.png"
        };

        public static string GetImageAddress(FoodType eType)
        {
            return m_asFoddImages[(int)eType];
        }
    }
}
