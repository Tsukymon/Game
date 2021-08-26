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
    public partial class LoadPlayer : Form
    {
        public LoadPlayer()
        {
            InitializeComponent();
            
            for(int i = 0; i < SQLSelections.LoadedPlayers.Count; i++)
            {
                listBox1.Items.Add(SQLSelections.LoadedPlayers[i].GetName());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItems.Count != 0)
            {
                SQLSelections.SetCurrentPlayerID(listBox1.SelectedItem.ToString());
                SQLSelections.LoadHiredHeroes();
                SQLSelections.LoadAvailableGear();
                SQLSelections.InitializeActiveSkills();
                SQLSelections.LoadPlayersItems(listBox1.SelectedItem.ToString());

                this.Hide();
                MainGameScreen mainGameScreen = new MainGameScreen();
                mainGameScreen.ShowDialog();
                // CONTINUE TO GAME MENU
            }
            else
            {
                MessageBox.Show("Please select a player");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
