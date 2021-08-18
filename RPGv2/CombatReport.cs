﻿using System;
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
    public partial class CombatReport : Form
    {
        string HitStatus;
        string CritStatus;
        int PhaseCounter = 1;
        int TurnCounter = 1;
        int CritMultiplier = 2;
        float HeroHp = SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetHp();
        float CreatureHp = SQLSelections.LoadedCreatures[SQLSelections.SelectedCreatureIndex].GetHp();

        public CombatReport()
        {
            InitializeComponent();
            textBox1.Text = $"---== {SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetName()} vs {SQLSelections.LoadedCreatures[SQLSelections.SelectedCreatureIndex].GetName()} ==---\r\n\r\n";
            label1.Text = $"Phase {PhaseCounter}";
            label2.Text = $"Turn {TurnCounter}";
            label3.Text = $"{SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetName()}";
            label4.Text = $"{HeroHp} HP";
            label5.Text = $"{SQLSelections.LoadedCreatures[SQLSelections.SelectedCreatureIndex].GetName()}";
            label6.Text = $"{CreatureHp} HP";
        }

     
        

        private void button1_Click(object sender, EventArgs e)
        {
            

            label2.Text = $"Turn {TurnCounter}";
            label1.Text = $"Phase {PhaseCounter}";

            HitCheck();
            CritCheck();
            textBox1.AppendText($"Phase {PhaseCounter} Turn {TurnCounter}\r\n");
            textBox1.AppendText("------------------------------------------\r\n");
            textBox1.AppendText($"{SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetName()} used basic and {HitStatus}!\r\n");
            if (HitStatus == "hit")
            {
                if(CritStatus == "!!CRITICAL HIT!!")
                {
                    //CRIT BRANCH
                    textBox1.AppendText("!!CRITICAL HIT!!\r\n");
                    textBox1.AppendText($"{SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetName()} dealt {BasicDamageEquation() * CritMultiplier} damage!\r\n");
                    CreatureHp = CreatureHp - BasicDamageEquation() * CritMultiplier;
                    
                }
                else
                {
                    //HIT BRANCH
                    textBox1.AppendText($"{SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetName()} dealt {BasicDamageEquation()} damage!\r\n");
                    CreatureHp = CreatureHp - BasicDamageEquation();
                    
                }
                
            }
            else
            {
                
                
                
            }

            if (CreatureHp <= 0)
            {
                // CREATURE DIED HERE
                CreatureHp = 0;
                textBox1.AppendText($"\r\n{SQLSelections.LoadedCreatures[SQLSelections.SelectedCreatureIndex].GetName()} has died");
                button1.Enabled = false;
                button2.Visible = true;
                SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].SetExp(SQLSelections.LoadedCreatures[SQLSelections.SelectedCreatureIndex].GetExp());
                SQLSelections.GiveHeroExp(SQLSelections.CurrentSelectedHeroIndex);
                SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].CalculateLvl(SQLSelections.ExpCurve[SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetLvl()].GetExp());
                SQLSelections.UpdateLvl();
                SQLSelections.UpdateExpForNextLvl();
            }
            else
            {
                textBox1.AppendText($"{SQLSelections.LoadedCreatures[SQLSelections.SelectedCreatureIndex].GetName()} hit for {CreatureDmageToHero()}\r\n");
                HeroHp = HeroHp - CreatureDmageToHero();
                textBox1.AppendText("------------------------------------------\r\n");

                if (HeroHp <= 0)
                {
                    HeroHp = 0;
                    textBox1.AppendText($"\r\n{SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetName()} has died");
                    button1.Enabled = false;
                    button2.Visible = true;

                }
            }


            
            

            if (TurnCounter < 5)
            {
                TurnCounter++;
            }
            else
            {
                TurnCounter = 1;
                PhaseCounter++;
            }



            UpdateLabels();

            
        }


        void CritCheck()
        {
            int CritChance;
            CritChance = ((Int32)SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetCrit());
            int RandomNumber;
            Random rd = new Random();
            RandomNumber = rd.Next(0, 100);
            if(CritChance >= RandomNumber)
            {
                CritStatus = "!!CRITICAL HIT!!";
            }
            else
            {
                CritStatus = "";
            }
        }

        int BasicDamageEquation()
        {
            int AtkDamage;
            int MatkDamage;
            int Total;
            AtkDamage = (100 * (Int32)SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetAtk() * 1 / (100 + (Int32)SQLSelections.LoadedCreatures[SQLSelections.SelectedCreatureIndex].GetDef()));
            MatkDamage = (100 * (Int32)SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetMatk() * 1 / (100 + (Int32)SQLSelections.LoadedCreatures[SQLSelections.SelectedCreatureIndex].GetMdef()));
            Total = AtkDamage + MatkDamage;
            return Total;
        }

        void HitCheck()
        {
            int HitChance;
            HitChance = ((Int32)SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetAcc() * 200) / ((Int32)SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetAcc() + (Int32)SQLSelections.LoadedCreatures[SQLSelections.SelectedCreatureIndex].GetEva());
            int RandomNumber;
            Random rd = new Random();
            RandomNumber = rd.Next(0, 100);
            if (HitChance >= RandomNumber)
            {
                HitStatus = "hit";
            }
            else
            {
                HitStatus = "missed";
            }
        }

        void UpdateLabels()
        {
            label4.Text = $"{HeroHp.ToString()} HP";
            label6.Text = $"{CreatureHp.ToString()} HP";
        }

        int CreatureDmageToHero()
        {
            int AtkDamage;
            int MatkDamage;
            int Total;
            AtkDamage = (100 * (Int32)SQLSelections.LoadedCreatures[SQLSelections.SelectedCreatureIndex].GetAtk() / (100 + (Int32)SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetDef()));
            MatkDamage = (100 * (Int32)SQLSelections.LoadedCreatures[SQLSelections.SelectedCreatureIndex].GetMatk() / (100 + (Int32)SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetMdef()));
            Total = AtkDamage + MatkDamage;
            return Total;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}