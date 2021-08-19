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
        float HpMultiplier = 1; 
        float AtkMultiplier = 1;
        float MatkMultiplier = 1;
        float AccMultiplier = 1;
        float CritMultiplier = 1;
        float DefMultiplier = 1;
        float MdefMultiplier = 1;
        int SelectedSkill;


        public HiredHero(int id, string name, float hp, float atk, float matk, float acc, float crit, float def, float mdef, int lvl, int playerID, int exp, int expfornextlvl, int selectedskill)
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
            SelectedSkill = selectedskill;           
        }

        public string GetName()
        {
            return Name;
        }

        public float GetHp()
        {
            return Hp * HpMultiplier;
        }

        public float GetAtk()
        {
            return Atk * AtkMultiplier;
        }

        public float GetMatk()
        {
            return Matk * MatkMultiplier;
        }

        public float GetAcc()
        {
            return Acc * AccMultiplier;
        }

        public float GetCrit()
        {
            return Crit * CritMultiplier;
        }

        public float GetDef()
        {
            return Def * DefMultiplier;
        }

        public float GetMdef()
        {
            return Mdef * MdefMultiplier;
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

        public void SetHpMultiplier(float index)
        {
            HpMultiplier = index;
        }

        public void SetAtkMultiplier(float index)
        {
            AtkMultiplier = index;
        }

        public void SetMatkMultiplier(float index)
        {
            MatkMultiplier = index;
        }

        public void SetAccMultiplier(float index)
        {
            AccMultiplier = index;
        }

        public void SetCritMultiplier(float index)
        {
            CritMultiplier = index;
        }
        public void SetDefMultiplier(float index)
        {
            DefMultiplier = index;
        }

        public void SetMdefMultiplier(float index)
        {
            MdefMultiplier = index;
        }

        public int GetSelectedSkill()
        {
            return SelectedSkill;
        }

        public void SetSelectedSkill(int index)
        {
            SelectedSkill = index;
        }

        public void ResetMultipliers()
        {
            HpMultiplier = 1;
            AtkMultiplier = 1;
            MatkMultiplier = 1;
            AccMultiplier = 1;
            CritMultiplier = 1;
            DefMultiplier = 1;
            MdefMultiplier = 1;
        }
    }
}
