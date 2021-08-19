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
    public partial class Adventure : Form
    {
        public Adventure()
        {
            
            InitializeComponent();
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SQLSelections.SelectedCreatureIndex = 0;
            Attack attack = new Attack(0);
            attack.ShowDialog();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SQLSelections.SelectedCreatureIndex = 1;
            Attack attack = new Attack(1);
            attack.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SQLSelections.SelectedCreatureIndex = 2;
            Attack attack = new Attack(2);
            attack.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SQLSelections.SelectedCreatureIndex = 3;
            Attack attack = new Attack(3);
            attack.ShowDialog();
        }
    }
}
