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
            TextBoxInit();
            int Ap = 0;

            if(Ap < 20)
            {
                Ap = 5 + (SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetLvl() - 10) / 2;
            }
            label2.Text = $"AP: {Ap}";

            if(SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetName() == "Warrior")
            {
                comboBox1.Items.Add("Might - Atk+10%");
                comboBox1.Items.Add("Vitality - Def+12%  Atk+6%");
                comboBox1.Items.Add("Juggernaut - Hp+25%");
            }
            else
            {
                if(SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetName() == "Rogue")
                {
                    comboBox1.Items.Add("Might - Atk+10%");
                    comboBox1.Items.Add("Keen Eye - Acc+10%");
                    comboBox1.Items.Add("Critical strike - Crit+10%");
                }
                else
                {
                    if(SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetName() == "Mage")
                    {
                        
                        {
                            comboBox1.Items.Add("Intellect - Matk+10%");
                            comboBox1.Items.Add("Wisdom - Matk+5%  Acc+5%");
                            comboBox1.Items.Add("Mind - Acc+10%  Mdef+10%");
                            
                        }
                        
                    }
                    
                }
            }

            void TextBoxInit()
            {
                if (SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetName() == "Warrior" && SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetSelectedSkill() == 0)
                {
                    textBox1.Text = "Might - Atk+10%";
                }
                if (SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetName() == "Warrior" && SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetSelectedSkill() == 1)
                {
                    textBox1.Text = "Vitality - Def+12%  Atk+6%";
                }
                if (SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetName() == "Warrior" && SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetSelectedSkill() == 2)
                {
                    textBox1.Text = "Juggernaut - Hp+25%";
                }

                if (SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetName() == "Rogue" && SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetSelectedSkill() == 0)
                {
                    textBox1.Text = "Might - Atk+10%";
                }
                if (SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetName() == "Rogue" && SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetSelectedSkill() == 1)
                {
                    textBox1.Text = "Keen Eye - Acc+10%";
                }
                if (SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetName() == "Rogue" && SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetSelectedSkill() == 2)
                {
                    textBox1.Text = "Critical strike - Crit+10%";
                }

                if (SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetName() == "Mage" && SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetSelectedSkill() == 0)
                {
                    textBox1.Text = "Intellect - Matk+10%";
                }
                if (SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetName() == "Mage" && SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetSelectedSkill() == 1)
                {
                    textBox1.Text = "Wisdom - Matk+5%  Acc+5%";
                }
                if (SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetName() == "Mage" && SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetSelectedSkill() == 2)
                {
                    textBox1.Text = "Mind - Acc+10%  Mdef+10%";
                }
            }

            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].ResetMultipliers();
            SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].SetSelectedSkill(comboBox1.SelectedIndex);
            SQLSelections.InitializeActiveSkills();
            textBox1.Text = comboBox1.SelectedItem.ToString();
            SQLSelections.UpdateSelectedSkill();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
