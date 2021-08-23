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
    public partial class NewPlayer : Form
    {
        public NewPlayer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                SQLSelections.AddNewPlayer(textBox1.Text);
                SQLSelections.AddNewPlayerTabs(textBox1.Text);
                SQLSelections.LoadHiredHeroes();
                SQLSelections.LoadAvailableGear();
                SQLSelections.LoadItems();
                

                this.Hide();
                MainGameScreen mainGameScreen = new MainGameScreen();
                mainGameScreen.ShowDialog();
                // CONTINUE TO GAME MENU
            }
            else
            {
                MessageBox.Show("Please enter a name");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
