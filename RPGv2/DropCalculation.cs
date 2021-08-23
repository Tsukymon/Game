using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGv2
{
    class DropCalculation
    {
        int CreatureIndex;
        int Slot1;
        int Slot2;
        int Slot3;
        int Slot4;
        int Slot1Count;
        int Slot2Count;
        int Slot3Count;
        int Slot4Count;
        int Slot1Flag = 0;
        int Slot2Flag = 0;
        int Slot3Flag = 0;
        int Slot4Flag = 0;
        Random random = new Random();

        public DropCalculation(int creatureIndex)
        {
            CreatureIndex = creatureIndex;
        }

        public void CalculateSlot1()
        {
            if(SQLSelections.LoadedCreatures[CreatureIndex].GetSlot1() != "0")
            {
                string Slot1string = SQLSelections.LoadedCreatures[CreatureIndex].GetSlot1();
                string[] Slot1Parse = Slot1string.Split('/');
                string[] Slot1PossibleItems = Slot1Parse[0].Split(',');
                string[] Slot1Amounts = Slot1Parse[1].Split(',');
                string[] Slot1Chances = Slot1Parse[2].Split(',');

                int RandomNumber = random.Next(1, 100);
                int[] ScalingChances = new int[Slot1PossibleItems.Length];

                for (int i = 0; i < Slot1PossibleItems.Length; i++)
                {
                    if (i == 0)
                    {
                        ScalingChances[i] = Int32.Parse(Slot1Chances[i]);
                    }
                    else
                    {
                        ScalingChances[i] = Int32.Parse(Slot1Chances[i]) + ScalingChances[i-1];
                    }
                }

                for (int i = 0; i < Slot1PossibleItems.Length; i++)
                {
                    if(ScalingChances[i] >= RandomNumber)
                    {
                        Slot1 = Int32.Parse(Slot1PossibleItems[i]);
                        int Count = random.Next(1, Int32.Parse(Slot1Amounts[i])+1);
                        Slot1Count = Count;
                        Slot1Flag = 1;
                        break;
                    }
                    else
                    {
                        Slot1 = 0;
                        Slot1Count = 0;
                    }                   
                }
            }
            else
            {
                Slot1 = 0;
                Slot1Count = 0;
            }
        }

        public void CalculateSlot2()
        {
            if (SQLSelections.LoadedCreatures[CreatureIndex].GetSlot2() != "0")
            {
                string Slot2string = SQLSelections.LoadedCreatures[CreatureIndex].GetSlot2();
                string[] Slot2Parse = Slot2string.Split('/');
                string[] Slot2PossibleItems = Slot2Parse[0].Split(',');
                string[] Slot2Amounts = Slot2Parse[1].Split(',');
                string[] Slot1Chances = Slot2Parse[2].Split(',');

                int RandomNumber = random.Next(1, 100);
                int[] ScalingChances = new int[Slot2PossibleItems.Length];

                for (int i = 0; i < Slot2PossibleItems.Length; i++)
                {
                    if (i == 0)
                    {
                        ScalingChances[i] = Int32.Parse(Slot1Chances[i]);
                    }
                    else
                    {
                        ScalingChances[i] = Int32.Parse(Slot1Chances[i]) + ScalingChances[i - 1];
                    }
                }

                for (int i = 0; i < Slot2PossibleItems.Length; i++)
                {
                    if (ScalingChances[i] >= RandomNumber)
                    {
                        Slot2 = Int32.Parse(Slot2PossibleItems[i]);
                        int Count = random.Next(1, Int32.Parse(Slot2Amounts[i])+1);
                        Slot2Count = Count;
                        Slot2Flag = 1;
                        break;
                    }
                    else
                    {
                        Slot2 = 0;
                        Slot2Count = 0;
                    }

                }
            }
            else
            {
                Slot2 = 0;
                Slot2Count = 0;
            }



        }

        public void CalculateSlot3()
        {
            if (SQLSelections.LoadedCreatures[CreatureIndex].GetSlot3() != "0")
            {
                string Slot3string = SQLSelections.LoadedCreatures[CreatureIndex].GetSlot3();
                string[] Slot3Parse = Slot3string.Split('/');
                string[] Slot3PossibleItems = Slot3Parse[0].Split(',');
                string[] Slot3Amounts = Slot3Parse[1].Split(',');
                string[] Slot3Chances = Slot3Parse[2].Split(',');

                int RandomNumber = random.Next(1, 100);
                int[] ScalingChances = new int[Slot3PossibleItems.Length];

                for (int i = 0; i < Slot3PossibleItems.Length; i++)
                {
                    if (i == 0)
                    {
                        ScalingChances[i] = Int32.Parse(Slot3Chances[i]);
                    }
                    else
                    {
                        ScalingChances[i] = Int32.Parse(Slot3Chances[i]) + ScalingChances[i - 1];
                    }
                }




                for (int i = 0; i < Slot3PossibleItems.Length; i++)
                {
                    if (ScalingChances[i] >= RandomNumber)
                    {
                        Slot3 = Int32.Parse(Slot3PossibleItems[i]);
                        int Count = random.Next(1, Int32.Parse(Slot3Amounts[i])+1);
                        Slot3Count = Count;
                        Slot3Flag = 1;
                        break;
                    }
                    else
                    {
                        Slot3 = 0;
                        Slot3Count = 0;
                    }

                }
            }
            else
            {
                Slot3 = 0;
                Slot3Count = 0;
            }



        }

        public void CalculateSlot4()
        {
            if (SQLSelections.LoadedCreatures[CreatureIndex].GetSlot4() != "0")
            {
                string Slot4string = SQLSelections.LoadedCreatures[CreatureIndex].GetSlot4();
                string[] Slot4Parse = Slot4string.Split('/');
                string[] Slot4PossibleItems = Slot4Parse[0].Split(',');
                string[] Slot4Amounts = Slot4Parse[1].Split(',');
                string[] Slot4Chances = Slot4Parse[2].Split(',');

                int RandomNumber = random.Next(1, 100);
                int[] ScalingChances = new int[Slot4PossibleItems.Length];

                for (int i = 0; i < Slot4PossibleItems.Length; i++)
                {
                    if (i == 0)
                    {
                        ScalingChances[i] = Int32.Parse(Slot4Chances[i]);
                    }
                    else
                    {
                        ScalingChances[i] = Int32.Parse(Slot4Chances[i]) + ScalingChances[i - 1];
                    }
                }




                for (int i = 0; i < Slot4PossibleItems.Length; i++)
                {
                    if (ScalingChances[i] >= RandomNumber)
                    {
                        Slot4 = Int32.Parse(Slot4PossibleItems[i]);
                        int Count = random.Next(1, Int32.Parse(Slot4Amounts[i])+1);
                        Slot4Count = Count;
                        Slot4Flag = 1;
                        break;
                    }
                    else
                    {
                        Slot4 = 0;
                        Slot4Count = 0;
                    }

                }
            }
            else
            {
                Slot4 = 0;
                Slot4Count = 0;
            }



        }

        public int GetTotalDropCount()
        {
            return Slot1Flag + Slot2Flag + Slot3Flag + Slot4Flag;
        }

        public int GetSlot1()
        {
            return Slot1;
        }

        public int GetSlot2()
        {
            return Slot2;
        }

        public int GetSlot3()
        {
            return Slot3;
        }

        public int GetSlot4()
        {
            return Slot4;
        }

        public int GetSlot1Flag()
        {
            return Slot1Flag;
        }

        public int GetSlot2Flag()
        {
            return Slot2Flag;
        }

        public int GetSlot3Flag()
        {
            return Slot3Flag;
        }

        public int GetSlot4Flag()
        {
            return Slot4Flag;
        }

        public int GetSlot1Count()
        {
            return Slot1Count;
        }

        public int GetSlot2Count()
        {
            return Slot2Count;
        }

        public int GetSlot3Count()
        {
            return Slot3Count;
        }

        public int GetSlot4Count()
        {
            return Slot4Count;
        }
    }
}
