﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGv2
{
    class Items
    {
        int ID;
        string Name;

        public Items(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public int GetID()
        {
            return ID;
        }

        public string GetName()
        {
            return Name;
        }
    }
}
