using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGv2
{
    class Hero
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
        float HpPLvl;
        float AtkPLvl;
        float MatkPLvl;
        float AccPLvl;
        float CritPLvl;
        float DefPLvl;
        float MdefPLvl;
        


        public Hero(int id, string name, float hp, float atk, float matk, float acc, float crit, float def, float mdef, float hpplvl, float atkplvl, float matkplvl, float accplvl, float critplvl, float defplvl, float mdefplvl)
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
            HpPLvl = hpplvl;
            AtkPLvl = atkplvl;
            MatkPLvl = matkplvl;
            AccPLvl = accplvl;
            CritPLvl = critplvl;
            DefPLvl = defplvl;
            MdefPLvl = mdefplvl;
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

        

        public float GetHpPLvl()
        {
            return HpPLvl;
        }

        public float GetAtkPLvl()
        {
            return AtkPLvl;
        }

        public float GetMatkPLvl()
        {
            return MatkPLvl;
        }

        public float GetAccPLvl()
        {
            return AccPLvl;
        }

        public float GetCritPLvl()
        {
            return CritPLvl;
        }

        public float GetDefPLvl()
        {
            return DefPLvl;
        }

        public float GetMdefPLvl()
        {
            return MdefPLvl;
        }

        
    }
}
