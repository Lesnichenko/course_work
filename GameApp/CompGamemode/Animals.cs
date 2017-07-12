
using GameApp.FoodBase;

namespace GameApp.Animals
{
    enum AnimalType
    {
        AT_UNKNOWN = -1,
        AT_BEAR,
        AT_ELK,
        AT_FOX,
        AT_HARE,
        AT_HEDGEHOG,
        AT_LYNX,
        AT_SQUIRREL,
        AT_WOLF,
        NUM_ANIMALS
    };

    enum AnimalAge
    {
        AA_PARENT,
        AA_CHILD,
        NUM_AGES
    };


    class Animal
    {
        protected AnimalType m_eType;
        protected AnimalAge  m_eAge;
        protected string[]   m_asImages;
        protected string     m_sCmpSuccessImage;
        protected FoodType[] m_aeFood;
        protected string     m_sLabelImage;

        public    AnimalType GetAnimalType()          { return m_eType; }
        public    AnimalAge  GetAnimalAge()           { return m_eAge; }
        public    string     GetImagePath()           { return m_asImages[(int)m_eAge]; }
        public    string     GetCompareSuccessImage() { return m_sCmpSuccessImage; }
        public    int        GetFoodCount()           { return m_aeFood.Length; }
        public    FoodType   GetFoodType(int nId)     { return m_aeFood[nId]; }
        public    string     GetLabelImage()          { return m_sLabelImage; }
    };
}
