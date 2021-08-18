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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            if(SQLSelections.LoadedPlayers.Count == 0)
            {
                button2.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            NewPlayer newPlayer = new NewPlayer();
            newPlayer.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoadPlayer loadPlayer = new LoadPlayer();
            loadPlayer.ShowDialog();
            this.Show();
        }

        private void MainMenu_VisibleChanged(object sender, EventArgs e)
        {
            if (SQLSelections.LoadedPlayers.Count == 0)
            {
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
            }
        }
    }
}
