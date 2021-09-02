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
    public partial class CombatReport : Form
    {
        string HitStatus;
        string CritStatus;
        int PhaseCounter = 1;
        int TurnCounter = 1;
        int CritMultiplier = 2;
        float HeroHp = SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetCurentHp();
        float CreatureHp = SQLSelections.LoadedCreatures[SQLSelections.SelectedCreatureIndex].GetHp();

        List<PictureBox> pictureBoxes = new List<PictureBox>();
        List<ToolTip> toolTips = new List<ToolTip>();
        

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
                SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].SetCurentHp((Int32)HeroHp);
                CreatureHp = 0;              
                int x = 0;
                int counter = 0;
                textBox1.AppendText($"\r\n{SQLSelections.LoadedCreatures[SQLSelections.SelectedCreatureIndex].GetName()} has died");
                button1.Enabled = false;
                button2.Visible = true;
                SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].SetExp(SQLSelections.LoadedCreatures[SQLSelections.SelectedCreatureIndex].GetExp());
                SQLSelections.GiveHeroExp(SQLSelections.CurrentSelectedHeroIndex);
                SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].CalculateLvl(SQLSelections.ExpCurve[SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetLvl()].GetExp());
                SQLSelections.UpdateLvl();
                SQLSelections.UpdateExpForNextLvl((Int32)HeroHp);

                DropCalculation dropCalculation = new DropCalculation(SQLSelections.SelectedCreatureIndex);
                dropCalculation.CalculateSlot1();
                dropCalculation.CalculateSlot2();
                dropCalculation.CalculateSlot3();
                dropCalculation.CalculateSlot4();
                this.Size = new Size(460, 475);
                label7.Visible = true;

                if(dropCalculation.GetSlot1Flag() == 1)
                {
                    pictureBoxes.Add(new PictureBox());
                    toolTips.Add(new ToolTip());
                    


                    this.Controls.Add(pictureBoxes[counter]);
                    pictureBoxes[counter].Visible = true;
                    pictureBoxes[counter].Location = new Point(15 + x, 360);
                    pictureBoxes[counter].Size = new Size(70, 70);
                    pictureBoxes[counter].Image = Image.FromFile($@"C:\Programy\RPGv2\Pics\Drops\{dropCalculation.GetSlot1()}.png");
                    toolTips[counter].SetToolTip(pictureBoxes[counter], $"{SQLSelections.Items[dropCalculation.GetSlot1()-1].GetName()} {dropCalculation.GetSlot1Count()}x");
                    
   
                    counter++;
                    x += 82;

                    SQLSelections.UpdateItems(SQLSelections.LoadedPlayers[SQLSelections.CurrentPlayerID-1].GetName(), dropCalculation.GetSlot1(), dropCalculation.GetSlot1Count());
                    SQLSelections.PlayersItems[dropCalculation.GetSlot1() - 1].IncrementCount(dropCalculation.GetSlot1Count());
                }

                if(dropCalculation.GetSlot2Flag() == 1)
                {
                    pictureBoxes.Add(new PictureBox());
                    toolTips.Add(new ToolTip());

                    this.Controls.Add(pictureBoxes[counter]);
                    pictureBoxes[counter].Visible = true;
                    pictureBoxes[counter].Location = new Point(15 + x, 360);
                    pictureBoxes[counter].Size = new Size(70, 70);
                    pictureBoxes[counter].Image = Image.FromFile($@"C:\Programy\RPGv2\Pics\Drops\{dropCalculation.GetSlot2()}.png");
                    toolTips[counter].SetToolTip(pictureBoxes[counter], $"{SQLSelections.Items[dropCalculation.GetSlot2() - 1].GetName()} {dropCalculation.GetSlot2Count()}x");
                    counter++;
                    x += 82;
                    SQLSelections.UpdateItems(SQLSelections.LoadedPlayers[SQLSelections.CurrentPlayerID - 1].GetName(), dropCalculation.GetSlot2(), dropCalculation.GetSlot2Count());
                    SQLSelections.PlayersItems[dropCalculation.GetSlot2() - 1].IncrementCount(dropCalculation.GetSlot2Count());
                }

                if(dropCalculation.GetSlot3Flag() == 1)
                {
                    pictureBoxes.Add(new PictureBox());
                    toolTips.Add(new ToolTip());

                    this.Controls.Add(pictureBoxes[counter]);
                    pictureBoxes[counter].Visible = true;
                    pictureBoxes[counter].Location = new Point(15 + x, 360);
                    pictureBoxes[counter].Size = new Size(70, 70);
                    pictureBoxes[counter].Image = Image.FromFile($@"C:\Programy\RPGv2\Pics\Drops\{dropCalculation.GetSlot3()}.png");
                    toolTips[counter].SetToolTip(pictureBoxes[counter], $"{SQLSelections.Items[dropCalculation.GetSlot3() - 1].GetName()} {dropCalculation.GetSlot3Count()}x");
                    counter++;
                    x += 82;
                    SQLSelections.UpdateItems(SQLSelections.LoadedPlayers[SQLSelections.CurrentPlayerID - 1].GetName(), dropCalculation.GetSlot3(), dropCalculation.GetSlot3Count());
                    SQLSelections.PlayersItems[dropCalculation.GetSlot3() - 1].IncrementCount(dropCalculation.GetSlot3Count());
                }

                if(dropCalculation.GetSlot4Flag() == 1)
                {
                    pictureBoxes.Add(new PictureBox());
                    toolTips.Add(new ToolTip());

                    this.Controls.Add(pictureBoxes[counter]);
                    pictureBoxes[counter].Visible = true;
                    pictureBoxes[counter].Location = new Point(15 + x, 360);
                    pictureBoxes[counter].Size = new Size(70, 70);
                    pictureBoxes[counter].Image = Image.FromFile($@"C:\Programy\RPGv2\Pics\Drops\{dropCalculation.GetSlot4()}.png");
                    toolTips[counter].SetToolTip(pictureBoxes[counter], $"{SQLSelections.Items[dropCalculation.GetSlot4() - 1].GetName()} {dropCalculation.GetSlot4Count()}x");
                    counter++;
                    x += 82;
                    SQLSelections.UpdateItems(SQLSelections.LoadedPlayers[SQLSelections.CurrentPlayerID - 1].GetName(), dropCalculation.GetSlot4(), dropCalculation.GetSlot4Count());
                    SQLSelections.PlayersItems[dropCalculation.GetSlot4() - 1].IncrementCount(dropCalculation.GetSlot4Count());
                }


                //LIST DROPS HERE
            }
            else
            {
                textBox1.AppendText($"{SQLSelections.LoadedCreatures[SQLSelections.SelectedCreatureIndex].GetName()} hit for {CreatureDmageToHero()}\r\n");
                HeroHp = HeroHp - CreatureDmageToHero();
                textBox1.AppendText("------------------------------------------\r\n");

                if (HeroHp <= 0)
                {
                    HeroHp = 0;
                    SQLSelections.UpdateExpForNextLvl((Int32)HeroHp);
                    SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].SetCurentHp(0);
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
