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
    public partial class MainGameScreen : Form
    {
        public MainGameScreen()
        {
            InitializeComponent();
            label1.Text = SQLSelections.LoadedPlayers[SQLSelections.CurrentPlayerID-1].GetName();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Heroes heroes = new Heroes();
            
            heroes.ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Inventory inventory = new Inventory();
            inventory.ShowDialog();
        }
    }
}
