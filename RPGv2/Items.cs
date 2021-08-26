using System;
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
        int Count;

        public Items(int id, string name, int count)
        {
            ID = id;
            Name = name;
            Count = count;
        }

        public int GetID()
        {
            return ID;
        }

        public string GetName()
        {
            return Name;
        }

        public int GetCount()
        {
            return Count;
        }

        public void IncrementCount(int index)
        {
            Count = Count + index;
        }
    }
}
