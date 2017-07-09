
using System;
using System.Windows;
using GameApp.Animals;

namespace GameApp.CompGamemode
{
    class CmpGame
    {
        enum CmpGameState
        {
            CGS_NOT_LOADED,
            CGS_WAITING,
            CGS_WAITING_NEXT,
            CGS_COMPLETED,
        };

        private CmpButton[]  m_aParentControls;
        private CmpButton[]  m_aChildrenControls;
        private AnimalType[] m_aLastTypes;
        private CmpAnimal[]  m_aAnimals;
        private CmpGameState m_eState;
        private int          m_nPairsLeft;
        private CmpPage      m_Parent;

        public CmpGame(CmpPage parent, CmpButton[] aControls)
        {
            m_aParentControls  = new CmpButton[] { aControls[0], aControls[1], aControls[2]};
            m_aChildrenControls = new CmpButton[] { aControls[3], aControls[4], aControls[5]};

            m_aLastTypes = new AnimalType[] { AnimalType.AT_UNKNOWN, AnimalType.AT_UNKNOWN, AnimalType.AT_UNKNOWN};
            m_aAnimals   = new CmpAnimal[6];

            m_eState = CmpGameState.CGS_NOT_LOADED;
            m_Parent = parent;
        }

        public void RestartGame()
        {
            bool[] abUsedAnimals = new bool[(int)AnimalType.NUM_ANIMALS];
            int[]  anIDs         = new int[(int)AnimalType.NUM_ANIMALS];
            int    nIDCount, nCurrent, nFillCount = 0;
            Random randGenerator = new Random();
            int[]  anSelected    = new int[3];
            bool[] abUsedSlots   = new bool[3];

            for(int i = 0; i < abUsedAnimals.Length; i++)
            {
                abUsedAnimals[i] = false;
                for(int j = 0; j < m_aLastTypes.Length; j++)
                {
                    if ((int)m_aLastTypes[j] == i)
                        abUsedAnimals[i] = true;
                }
            }

            for(int i = 0; i < 3; i++)
            {
                nIDCount = 0;
                for (int j = 0; j < abUsedAnimals.Length; j++)
                    if (!abUsedAnimals[j])
                        anIDs[nIDCount++] = j;

                nCurrent = randGenerator.Next() % nIDCount;

                abUsedAnimals[anIDs[nCurrent]] = true;
                anSelected[i] = anIDs[nCurrent];
            }
            
            for (int i = 0; i < 3; i++)
                m_aLastTypes[i] = (AnimalType)anSelected[i];

            nFillCount = PushIntoSlots(m_aParentControls, AnimalAge.AA_PARENT, nFillCount, ref randGenerator);
            PushIntoSlots(m_aChildrenControls, AnimalAge.AA_CHILD, nFillCount, ref randGenerator);

            m_eState     = CmpGameState.CGS_WAITING;
            m_nPairsLeft = 3;

            m_Parent.nextButton.Visibility = Visibility.Collapsed;
            m_Parent.restartButton.Visibility = Visibility.Collapsed;
        }

        private int PushIntoSlots(CmpButton[] aControls, AnimalAge eAge, int nFillCount, ref Random randGenerator)
        {
            bool[] abUsedSlots = new bool[3];
            int    nIDCount, nCurrent;

            Array.Clear(abUsedSlots, 0, abUsedSlots.Length);
            nIDCount = 3;

            for (int i = 0; i < 3; i++)
            {
                nCurrent = randGenerator.Next() % (nIDCount--);

                for (int j = 0, q = 0; j < 3; j++)
                {
                    if (abUsedSlots[j])
                        continue;

                    if (q == nCurrent)
                    {
                        abUsedSlots[j] = true;
                        m_aAnimals[nFillCount++] = new CmpAnimal(this, aControls[j], m_aLastTypes[i], eAge);
                        break;
                    }

                    q++;
                }
            }

            return nFillCount;
        }

        public void OnButtonCheck(bool bChecked)
        {
            switch (m_eState)
            {
                case CmpGameState.CGS_NOT_LOADED:
                case CmpGameState.CGS_COMPLETED:
                    return;

                case CmpGameState.CGS_WAITING:
                    if (bChecked)
                        m_eState = CmpGameState.CGS_WAITING_NEXT;
                    break;
                case CmpGameState.CGS_WAITING_NEXT:
                    if (!bChecked)
                    {
                        m_eState = CmpGameState.CGS_WAITING;
                        break;
                    }
                    TestSelected();
                    break;
            }
        }

        private void TestSelected()
        {
            CmpAnimal[] aSelectedAnimals = new CmpAnimal[2];

            for (int i = 0, q = 0; i < m_aAnimals.Length; i++)
                if (m_aAnimals[i].IsEnabled() && m_aAnimals[i].IsChecked())
                    aSelectedAnimals[q++] = m_aAnimals[i];

            if (aSelectedAnimals[0].GetAnimal().GetAnimalType() != aSelectedAnimals[1].GetAnimal().GetAnimalType())
            {
                //MessageBox.Show("Wrong!");
                aSelectedAnimals[0].Uncheck();
                aSelectedAnimals[1].Uncheck();
                aSelectedAnimals[0].PlayWrongAnimation();
                aSelectedAnimals[1].PlayWrongAnimation();
            }
            else
            {
                aSelectedAnimals[0].Uncheck();
                aSelectedAnimals[1].Uncheck();
                aSelectedAnimals[0].Disable();
                aSelectedAnimals[1].Disable();

                //MessageBox.Show("Right!");
                aSelectedAnimals[0].PlayRightAnimation();
                aSelectedAnimals[1].PlayRightAnimation();
                m_nPairsLeft--;

                m_Parent.PlayMessageAnimation(aSelectedAnimals[0].GetAnimal().GetCompareSuccessImage());
            }

            if (m_nPairsLeft == 0)
            {
                m_eState = CmpGameState.CGS_COMPLETED;

                m_Parent.nextButton.Visibility = Visibility.Visible;
                m_Parent.restartButton.Visibility = Visibility.Visible;
                //MessageBox.Show("Game completed.");
            }
            else
                m_eState = CmpGameState.CGS_WAITING;
        }
    }
}
