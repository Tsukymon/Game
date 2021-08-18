using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPGv2
{
    public partial class Skills : Form
    {
        public Skills()
        {
            InitializeComponent();
            int Ap = 0;

            if(Ap < 20)
            {
                Ap = 5 + (SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetLvl() - 10) / 2;
            }
            label2.Text = $"AP: {Ap}";

        }
    }
}
