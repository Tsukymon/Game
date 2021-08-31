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
    public partial class Crafters : Form
    {
        public Crafters()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CraftingDialog craftingDialog = new CraftingDialog(1);
            craftingDialog.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CraftingDialog craftingDialog = new CraftingDialog(2);
            craftingDialog.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CraftingDialog craftingDialog = new CraftingDialog(3);
            craftingDialog.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CraftingDialog craftingDialog = new CraftingDialog(4);
            craftingDialog.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CraftingDialog craftingDialog = new CraftingDialog(5);
            craftingDialog.ShowDialog();
        }
    }
}
