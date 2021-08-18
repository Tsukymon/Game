using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGv2
{
    class Player
    {
        int PlayerId;
        string Name;


        public Player(int id, string name)
        {
            Name = name;
            PlayerId = id;
        }

        public string GetName()
        {
            return Name;
        }

    }


}
