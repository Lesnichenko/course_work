
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

using GameApp.Animals;
using GameApp.FoodBase;

namespace GameApp.SelectionGamemode
{
    class SelGame : SelButton.SelButtonCallback
    {
        private SelPage m_Parent;

        private static AnimalType[] m_aeTypes = new AnimalType[8]
        {
            AnimalType.AT_FOX,
            AnimalType.AT_BEAR,
            AnimalType.AT_WOLF,
            AnimalType.AT_LYNX,
            AnimalType.AT_HARE,
            AnimalType.AT_HEDGEHOG,
            AnimalType.AT_SQUIRREL,
            AnimalType.AT_ELK
        };

        private Animal m_CurrentAnimal;
        private int m_nLeft;
        private SelButton[] m_aButtons;
        private Image[] m_aLabelImages;
        private static ImageSource m_SuccessImage;

        public SelGame(SelPage page, SelButton[] buttons, Image[] labelImages)
        {
            m_Parent = page;
            m_aButtons = buttons;
            m_aLabelImages = labelImages;

            if (m_SuccessImage == null)
                m_SuccessImage = ResourceController.GetResourceBitmap("/Image/SelGM/success.png");
        }

        public void RestartGame()
        {
            Random rg = new Random();
            AnimalType eType;

            if (!Choosing.selected)
            {
                Choosing.Num_Animal = rg.Next() % 8 + 1;
            }

            eType = m_aeTypes[Choosing.Num_Animal - 1];

            switch(eType)
            {
                case AnimalType.AT_BEAR:
                    m_CurrentAnimal = new Bear(AnimalAge.AA_PARENT);
                    break;
                case AnimalType.AT_ELK:
                    m_CurrentAnimal = new Elk(AnimalAge.AA_PARENT);
                    break;
                case AnimalType.AT_FOX:
                    m_CurrentAnimal = new Fox(AnimalAge.AA_PARENT);
                    break;
                case AnimalType.AT_HARE:
                    m_CurrentAnimal = new Hare(AnimalAge.AA_PARENT);
                    break;
                case AnimalType.AT_HEDGEHOG:
                    m_CurrentAnimal = new Hedgehog(AnimalAge.AA_PARENT);
                    break;
                case AnimalType.AT_LYNX:
                    m_CurrentAnimal = new Lynx(AnimalAge.AA_PARENT);
                    break;
                case AnimalType.AT_SQUIRREL:
                    m_CurrentAnimal = new Squirrel(AnimalAge.AA_PARENT);
                    break;
                case AnimalType.AT_WOLF:
                    m_CurrentAnimal = new Wolf(AnimalAge.AA_PARENT);
                    break;
            }

            SetSlots();

            m_aLabelImages[0].Source = ResourceController.GetResourceBitmap(m_CurrentAnimal.GetLabelImage());
            m_aLabelImages[1].Source = ResourceController.GetResourceBitmap(m_CurrentAnimal.GetImagePath());

            m_Parent.btnRestart.Visibility = m_Parent.btnNext.Visibility = Visibility.Collapsed;
        }

        private void SetSlots()
        {
            const int nSlotCount = 3;
            int nAnimalWrongCount, nMaxWrong, nWrongCount;
            Random rg = new Random();
           // bool[] abUsedSlots = new bool[nSlotCount] { false, false, false };
            bool[] abSlotValid = new bool[nSlotCount] { true, true, true};
            bool[] abFoodUsed = new bool[(int)FoodType.NUM_FOOD_TYPES];
            bool[] abFoodValid = new bool[(int)FoodType.NUM_FOOD_TYPES];
            int nCurrent, nWrongLeft, nSlotsLeft = nSlotCount, nValidLeft;

            for(int i = 0; i < (int)FoodType.NUM_FOOD_TYPES; i++)
                abFoodValid[i] = abFoodUsed[i] = false;

            for (int i = 0; i < m_CurrentAnimal.GetFoodCount(); i++)
                abFoodValid[(int)m_CurrentAnimal.GetFoodType(i)] = true;
         


            nAnimalWrongCount = (int)FoodType.NUM_FOOD_TYPES - m_CurrentAnimal.GetFoodCount();
            nMaxWrong = Math.Max(1, Math.Min(nSlotCount - 1, nAnimalWrongCount));
            nWrongLeft = nWrongCount = Math.Min(((rg.Next() % nMaxWrong) + 1), nAnimalWrongCount);

            while(nWrongLeft-- > 0)
            {
                nCurrent = rg.Next() % nSlotsLeft--;

                int q = 0;
                for(int i = 0; i < nSlotCount; i++)
                {
                    if(abSlotValid[i])
                    {
                        if(q++ == nCurrent)
                        {
                            abSlotValid[i] = false;
                            break;
                        }
                    }
                }
            }

            nWrongLeft = nAnimalWrongCount;
            nValidLeft = m_CurrentAnimal.GetFoodCount();

            for(int i = 0; i < nSlotCount; i++)
            {
                int q = 0;

                nCurrent = abSlotValid[i] ? (rg.Next() % nValidLeft--) : (rg.Next() % nWrongLeft--);

                for(int j = 0; j < (int)FoodType.NUM_FOOD_TYPES; j++)
                {
                    if (abFoodUsed[j])
                        continue;

                    if (abFoodValid[j] != abSlotValid[i])
                        continue;

                    if (q++ == nCurrent)
                    {
                        abFoodUsed[j] = true;

                        m_aButtons[i].SetCallback(this, FoodBase.FoodBase.GetImageAddress((FoodType)j), abSlotValid[i]);
                        break;
                    }
                }
            }

            m_nLeft = nSlotCount - nWrongCount;
        }

        public void OnClick(bool bValid)
        {
           // MessageBox.Show(bValid.ToString());

            if(bValid)
                m_nLeft--;

            if(m_nLeft == 0)
            {
                m_Parent.btnRestart.Visibility = m_Parent.btnNext.Visibility = Visibility.Visible;
                m_aLabelImages[0].Source = m_SuccessImage;
            }
            /*if (m_nLeft == 0)
                MessageBox.Show("Game completed");*/
        }
    }
}
