using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGv2
{
    class HiredHero
    {
        int ID;
        string Name;
        float Hp;
        float Atk;
        float Matk;
        float Acc;
        float Crit;
        float Def;
        float Mdef;        
        int Lvl;
        int PlayerID;
        int Exp;
        int ExpForNextLvl;
        bool LvldUp;


        public HiredHero(int id, string name, float hp, float atk, float matk, float acc, float crit, float def, float mdef, int lvl, int playerID, int exp, int expfornextlvl)
        {
            ID = id;
            Name = name;
            Hp = hp;
            Atk = atk;
            Matk = matk;
            Acc = acc;
            Crit = crit;
            Def = def;
            Mdef = mdef;
            Lvl = lvl;
            PlayerID = playerID;
            Exp = exp;
            ExpForNextLvl = expfornextlvl;
            
        }

        public string GetName()
        {
            return Name;
        }

        public float GetHp()
        {
            return Hp;
        }

        public float GetAtk()
        {
            return Atk;
        }

        public float GetMatk()
        {
            return Matk;
        }

        public float GetAcc()
        {
            return Acc;
        }

        public float GetCrit()
        {
            return Crit;
        }

        public float GetDef()
        {
            return Def;
        }

        public float GetMdef()
        {
            return Mdef;
        }

        public int GetLvl()
        {
            return Lvl;
        }

        public int GetPlayerID()
        {
            return PlayerID;
        }

        public int GetExpForNextLvl()
        {
            return ExpForNextLvl;
        }

        public int GetExp()
        {
            return Exp;
        }

        public void SetExp(int index)
        {
            Exp = Exp + index;
        }

        public int GetID()
        {
            return ID;
        }

        public void CalculateLvl(int index)
        {

            if(Exp - ExpForNextLvl >= 0)
            {
                ExpForNextLvl = ExpForNextLvl + index;
                Lvl++;
                LvldUp = true;
                SQLSelections.UpdateStatsForLvlUp();
                while (LvldUp == true)
                {
                    if(Exp - ExpForNextLvl >= 0)
                    {
                        Lvl++;
                        ExpForNextLvl = ExpForNextLvl + index;
                        LvldUp = true;
                        SQLSelections.UpdateStatsForLvlUp();

                    }
                    else
                    {
                        LvldUp = false;
                    }
                }
            }
            else
            {
                LvldUp = false;
            }
        }

        public void SetHp(float index)
        {
            Hp = Hp + index;
        }

        public void SetAtk(float index)
        {
            Atk = Atk + index;
        }

        public void SetMatk(float index)
        {
            Matk = Matk + index;
        }

        public void SetDef(float index)
        {
            Def = Def + index;
        }

        public void SetMdef(float index)
        {
            Mdef = Mdef + index;
        }

        public void SetCrit(float index)
        {
            Crit = Crit + index;
        }

        public void SetAcc(float index)
        {
            Acc = Acc + index;
        }
    }
}
