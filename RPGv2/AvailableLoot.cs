using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGv2
{
    class AvailableLoot
    {
        int ID;
        string Name;
        int Count;
        int PlayerID;

        public AvailableLoot(int id, string name, int count, int playerID)
        {
            ID = id;
            Name = name;
            Count = count;
            PlayerID = playerID;
        }
    }
}
