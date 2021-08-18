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

        public Creature(int id, string name, float hp, float atk, float matk, float eva, float def, float mdef, int exp)
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

    }
}
