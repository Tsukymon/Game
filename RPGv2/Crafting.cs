using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGv2
{
    class Crafting
    {
        int ID;
        int GearType;
        int LvlReq;
        int Hp;
        int Atk;
        int Matk;
        int Acc;
        int Crit;
        int Def;
        int Mdef;
        string Name;
        int CrafterType;
        string Slot1Req;
        string Slot2Req;
        string Slot3Req;
        string Slot4Req;

        public Crafting(int id, int type, int lvlreq, int hp, int atk, int matk, int acc, int crit, int def, int mdef, string name, int craftertype, string slot1, string slot2, string slot3, string slot4)
        {
            ID = id;
            GearType = type;
            LvlReq = lvlreq;
            Hp = hp;
            Atk = atk;
            Matk = matk;
            Acc = acc;
            Crit = crit;
            Def = def;
            Mdef = mdef;
            Name = name;
            CrafterType = craftertype;
            Slot1Req = slot1;
            Slot2Req = slot2;
            Slot3Req = slot3;
            Slot4Req = slot4;
        }

        public int GetID()
        {
            return ID;
        }

        public int GetGearType()
        {
            return GearType;
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

        public int GetCrafterType()
        {
            return CrafterType;
        }

        public string GetSlot1Req()
        {
            return Slot1Req;
        }

        public string GetSlot2Req()
        {
            return Slot2Req;
        }

        public string GetSlot3Req()
        {
            return Slot3Req;
        }

        public string GetSlot4Req()
        {
            return Slot4Req;
        }
    }


    
}
