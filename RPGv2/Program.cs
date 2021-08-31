using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPGv2
{
    static class Program
    {
        /// <summary>
        /// Hlavní vstupní bod aplikace.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SQLSelections.LoadCreatures();
            SQLSelections.LoadPlayers();
            SQLSelections.LoadDefaultHeroes();
            SQLSelections.LoadExpCurve();
            SQLSelections.LoadGear();
            SQLSelections.LoadItems();
            SQLSelections.GetAvailableGearMaxID();
            SQLSelections.LoadCraftingItems();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenu());
            
        }
    }
}
