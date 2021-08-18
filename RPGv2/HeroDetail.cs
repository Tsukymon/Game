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
    public partial class HeroDetail : Form
    {

        int SelectedIndex;

        public HeroDetail()
        {
            
            InitializeComponent();
            LabelsInit();
                      
            GearInitialize(1, comboBox1, textBox1);
            GearInitialize(2, comboBox2, textBox2);
            GearInitialize(3, comboBox3, textBox3);
            GearInitialize(4, comboBox4, textBox4);
            GearInitialize(5, comboBox5, textBox5);
            GearInitialize(6, comboBox6, textBox6);
            


            if (SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetLvl() >= 10)
            {
                button1.Enabled = true;
                button1.Text = "Skillset";
            }
            else
            {
                button1.Enabled = false;
                button1.Text = "Skillset\r\nLvl 10";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void GearInitialize(int index, ComboBox combo, TextBox text)
        {
            int Indexer = 0;
            combo.Items.Clear();
            for(int i = 0; i < SQLSelections.AvailableGear.Count(); i++)
            {               
                if(SQLSelections.AvailableGear[i].GetGearType() == index)
                {
                    if (SQLSelections.AvailableGear[i].GetEquipedStatus() == false && SQLSelections.AvailableGear[i].GetPlayerID() == SQLSelections.CurrentPlayerID)
                    {
                        SQLSelections.AvailableGear[i].SetComboIndex(Indexer);
                        Indexer++;
                        combo.Items.Add($"Lvl {SQLSelections.AvailableGear[i].GetLvlReq()} {SQLSelections.AvailableGear[i].GetName()}");                                                                    
                    }
                    else
                    {
                        if (SQLSelections.AvailableGear[i].GetHeroID() == SQLSelections.CurrentSelectedHeroIndex)
                        {
                            text.Text = SQLSelections.AvailableGear[i].GetName();
                        }
                    }
                }
            }                      
        }

        

        void EquipGear(int index, ComboBox combo, TextBox text)
        {
            int LvlReq;
            string b = string.Empty;

            for (int j = 0; j < combo.SelectedItem.ToString().Length; j++)
            {
                if (Char.IsDigit(combo.SelectedItem.ToString()[j]))
                {
                    b += combo.SelectedItem.ToString()[j];
                }
            }
            LvlReq = int.Parse(b);
            if (LvlReq <= SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetLvl())
            {
                for (int i = 0; i < SQLSelections.AvailableGear.Count; i++)
                {
                    if (SQLSelections.AvailableGear[i].GetHeroID() == SQLSelections.CurrentSelectedHeroIndex && SQLSelections.AvailableGear[i].GetGearType() == index)
                    {
                        if (SQLSelections.AvailableGear[i].GetEquipedStatus() == true)
                        {
                            SQLSelections.EquipRemoveStats(i);
                        }
                        SQLSelections.AvailableGear[i].SetEquipedStatus(false);
                        SQLSelections.UpdateEquipedStatusFALSE(i);
                    }
                }

                for (int i = 0; i < SQLSelections.AvailableGear.Count; i++)
                {
                    if (SQLSelections.AvailableGear[i].GetComboIndex() == SelectedIndex && SQLSelections.AvailableGear[i].GetLvlReq() <= SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetLvl())
                    {
                        if (SQLSelections.AvailableGear[i].GetGearType() == index)
                        {

                            text.Text = combo.SelectedItem.ToString();

                            SQLSelections.AvailableGear[i].SetEquipedStatus(true);
                            SQLSelections.AvailableGear[i].SetComboIndex(-2);
                            SQLSelections.UpdateEquipedStatusTRUE(i);
                            SQLSelections.AvailableGear[i].SetHeroID(SQLSelections.CurrentSelectedHeroIndex);

                            // EQUIPED ITEM HERE !!!!!!!!

                            SQLSelections.EquipAddStats(i);
                        }
                    }
                }
            }


        }

            


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedIndex = comboBox1.SelectedIndex;
            EquipGear(1, comboBox1, textBox1);
            GearInitialize(1, comboBox1, textBox1);
            LabelsInit();
            
            

        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedIndex = comboBox2.SelectedIndex;
            EquipGear(2, comboBox2, textBox2);
            GearInitialize(2, comboBox2, textBox2);
            LabelsInit();

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedIndex = comboBox3.SelectedIndex;
            EquipGear(3, comboBox3, textBox3);
            GearInitialize(3, comboBox3, textBox3);
            LabelsInit();

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedIndex = comboBox4.SelectedIndex;
            EquipGear(4, comboBox4, textBox4);
            GearInitialize(4, comboBox4, textBox4);
            LabelsInit();

        }

        private void LabelsInit()
        {
            label1.Text = SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetName();
            label2.Text = $"Atk: {SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetAtk().ToString("n1")}";
            label3.Text = $"Matk: {SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetMatk().ToString("n1")}";
            label4.Text = $"Acc: {SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetAcc().ToString("n1")}";
            label5.Text = $"Crit: {SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetCrit().ToString("n1")}";
            label6.Text = $"Def: {SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetDef().ToString("n1")}";
            label7.Text = $"Mdef: {SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetMdef().ToString("n1")}";
            label8.Text = $"Lvl: {SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetLvl()}";
        }

        void Unequip(int index, ComboBox combo, TextBox text)
        {

            for (int i = 0; i < SQLSelections.AvailableGear.Count; i++)
            {
                if (SQLSelections.AvailableGear[i].GetGearType() == index && SQLSelections.AvailableGear[i].GetHeroID() == SQLSelections.CurrentSelectedHeroIndex && SQLSelections.AvailableGear[i].GetEquipedStatus() == true)
                {
                    SQLSelections.UpdateEquipedStatusFALSE(i);
                    text.Clear();
                    SQLSelections.AvailableGear[i].SetEquipedStatus(false);
                    SQLSelections.AvailableGear[i].SetHeroID(-1);
                    SQLSelections.EquipRemoveStats(i);
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Unequip(1, comboBox1, textBox1);
            LabelsInit();
            GearInitialize(1, comboBox1, textBox1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Unequip(2, comboBox2, textBox2);
            LabelsInit();
            GearInitialize(2, comboBox2, textBox2);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Unequip(3, comboBox3, textBox3);
            LabelsInit();
            GearInitialize(3, comboBox3, textBox3);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Unequip(4, comboBox4, textBox4);
            LabelsInit();
            GearInitialize(4, comboBox4, textBox4);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Unequip(5, comboBox5, textBox5);
            LabelsInit();
            GearInitialize(5, comboBox5, textBox5);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Unequip(6, comboBox6, textBox6);
            LabelsInit();
            GearInitialize(6, comboBox6, textBox6);
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedIndex = comboBox5.SelectedIndex;
            EquipGear(5, comboBox5, textBox5);
            GearInitialize(5, comboBox5, textBox5);
            LabelsInit();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedIndex = comboBox6.SelectedIndex;
            EquipGear(6, comboBox6, textBox6);
            GearInitialize(6, comboBox6, textBox6);
            LabelsInit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Skills skills = new Skills();
            skills.ShowDialog();

        }
    }
}
