using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGv2
{
    class ExpCurve
    {
        int Lvl;
        int Exp;

        public ExpCurve(int lvl, int exp)
        {
            Lvl = lvl;
            Exp = exp;
        }

        public int GetLvl()
        {
            return Lvl;
        }

        public int GetExp()
        {
            return Exp;
        }
    }
}
