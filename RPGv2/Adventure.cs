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

        
        private void button6_Click(object sender, EventArgs e)
        {

            SQLSelections.SelectedCreatureIndex = 4;
            Attack attack = new Attack(4);
            attack.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            SQLSelections.SelectedCreatureIndex = 5;
            Attack attack = new Attack(5);
            attack.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {

            SQLSelections.SelectedCreatureIndex = 6;
            Attack attack = new Attack(6);
            attack.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {

            SQLSelections.SelectedCreatureIndex = 7;
            Attack attack = new Attack(7);
            attack.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {

            SQLSelections.SelectedCreatureIndex = 8;
            Attack attack = new Attack(8);
            attack.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
