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
    public partial class Potions : Form
    {
        public Potions()
        {
            
            InitializeComponent();
            ListBoxInit();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListBoxInit()
        {
            for(int i = 0; i < SQLSelections.AvailableGear.Count; i++)
            {
                if(SQLSelections.AvailableGear[i].GetGearType() == 7)
                {
                    listBox1.Items.Add(SQLSelections.AvailableGear[i].GetName());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex != -1)
            {
                for(int i = 0; i < SQLSelections.AvailableGear.Count; i++)
                {
                    if(SQLSelections.AvailableGear[i].GetGearType() == 7 && SQLSelections.AvailableGear[i].GetName() == listBox1.SelectedItem.ToString())
                    {
                        SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].Heal(SQLSelections.AvailableGear[i].GetHp());
                        SQLSelections.UpdateExpForNextLvl((Int32)SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetCurentHp());
                        SQLSelections.RemoveGear(SQLSelections.AvailableGear[i].GetID());
                        SQLSelections.AvailableGear.RemoveAt(i);
                        SQLSelections.LoadAvailableGear();
                        MessageBox.Show($"You hero used a potion", "Yay!");
                        this.Close();
                        break;                       
                    }
                    
                }

            }
            else
            {
                MessageBox.Show("Please select a potion to use", "Nothing selected");
            }
        }
    }
}
