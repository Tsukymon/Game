using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGv2
{
    class Gear
    {
        int ID;
        int Type;
        int LvlReq;
        int Hp;
        int Atk;
        int Matk;
        int Acc;
        int Crit;
        int Def;
        int Mdef;
        string Name;
    
        public Gear(int id, int type, int lvlreq, int hp, int atk, int matk, int acc, int crit, int def, int mdef, string name)
        {
            ID = id;
            Type = type;
            LvlReq = lvlreq;
            Hp = hp;
            Atk = atk;
            Matk = matk;
            Acc = acc;
            Crit = crit;
            Def = def;
            Mdef = mdef;
            Name = name;
        }

        public int GetID()
        {
            return ID;
        }

        public int GetGearType()
        {
            return Type;
        }

        public int GetLvlReq()
        {
            return LvlReq;
        }

        public int GetHp()
        {
            return Hp;
        }

        public int GetAtk()
        {
            return Atk;
        }

        public int GetMatk()
        {
            return Matk;
        }

        public int GetAcc()
        {
            return Acc;
        }

        public int GetCrit()
        {
            return Crit;
        }

        public int GetDef()
        {
            return Def;
        }

        public int GetMdef()
        {
            return Mdef;
        }

        public string GetName()
        {
            return Name;
        }


    }
}
