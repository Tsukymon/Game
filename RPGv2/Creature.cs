using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGv2
{
    class Creature
    {
        int ID;
        string Name;
        float Hp;
        float Atk;
        float Matk;
        float Eva;
        float Def;
        float Mdef;
        int Exp;
        string Slot1;
        string Slot2;
        string Slot3;
        string Slot4;

        public Creature(int id, string name, float hp, float atk, float matk, float eva, float def, float mdef, int exp, string slot1, string slot2, string slot3, string slot4)
        {
            ID = id;
            Name = name;
            Hp = hp;
            Atk = atk;
            Matk = matk;
            Eva = eva;
            Def = def;
            Mdef = mdef;
            Exp = exp;
            Slot1 = slot1;
            Slot2 = slot2;
            Slot3 = slot3;
            Slot4 = slot4;
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

        public float GetDef()
        {
            return Def;
        }

        public float GetMdef()
        {
            return Mdef;
        }

        public float GetEva()
        {
            return Eva;
        }

        public int GetExp()
        {
            return Exp;
        }

        public string GetSlot1()
        {
            return Slot1;
        }

        public string GetSlot2()
        {
            return Slot2;
        }

        public string GetSlot3()
        {
            return Slot3;
        }

        public string GetSlot4()
        {
            return Slot4;
        }
    }
}
