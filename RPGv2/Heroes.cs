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
    public partial class Heroes : Form
    {
        public Heroes()
        {
            

            InitializeComponent();
            HeroesInitialize();
            if(SQLSelections.CurrentHiredHeroes.Count >= 5)
            {
                button1.Enabled = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HireHeroes hireHeroes = new HireHeroes();
            this.Hide();
            hireHeroes.ShowDialog();
            this.Show();
        }

        private void Heroes_VisibleChanged(object sender, EventArgs e)
        {
            HeroesInitialize();
            if (SQLSelections.CurrentHiredHeroes.Count >= 5)
            {
                button1.Enabled = false;
            }
        }

        void HeroesInitialize()
        {
            switch (SQLSelections.CurrentHiredHeroes.Count)
            {
                case 0:
                    button1.Location = new Point(12, 12);
                    break;
                case 1:
                    button1.Location = new Point(12, 12 + 55);
                    button2.Location = new Point(12, 12);
                    button3.Location = new Point(370, 12);
                    label1.Location = new Point(138, 31);
                    button2.Visible = true;
                    button3.Visible = true;
                    label1.Visible = true;
                    label1.Text = $"Lvl: {SQLSelections.CurrentHiredHeroes[0].GetLvl()}        Exp: {SQLSelections.CurrentHiredHeroes[0].GetExp()} / {SQLSelections.CurrentHiredHeroes[0].GetExpForNextLvl()}          {SQLSelections.CurrentHiredHeroes[0].GetCurentHp()} / {SQLSelections.CurrentHiredHeroes[0].GetHp()} Hp";
                    button2.Text = SQLSelections.CurrentHiredHeroes[0].GetName();
                    break;
                case 2:
                    button1.Location = new Point(12, 12 + 55+55);
                    button2.Location = new Point(12, 12);
                    button3.Location = new Point(370, 12);
                    button4.Location = new Point(12, 12 + 55);
                    button8.Location = new Point(370, 12 + 55);
                    label1.Location = new Point(138, 31);
                    label2.Location = new Point(138, 31 + 55);
                    label1.Visible = true;
                    label2.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    button8.Visible = true;
                    label1.Text = $"Lvl: {SQLSelections.CurrentHiredHeroes[0].GetLvl()}         Exp: {SQLSelections.CurrentHiredHeroes[0].GetExp()} / {SQLSelections.CurrentHiredHeroes[0].GetExpForNextLvl()}          {SQLSelections.CurrentHiredHeroes[0].GetCurentHp()} / {SQLSelections.CurrentHiredHeroes[0].GetHp()} Hp";
                    label2.Text = $"Lvl: {SQLSelections.CurrentHiredHeroes[1].GetLvl()}         Exp: {SQLSelections.CurrentHiredHeroes[1].GetExp()} / {SQLSelections.CurrentHiredHeroes[1].GetExpForNextLvl()}          {SQLSelections.CurrentHiredHeroes[1].GetCurentHp()} / {SQLSelections.CurrentHiredHeroes[1].GetHp()} Hp";
                    button2.Text = SQLSelections.CurrentHiredHeroes[0].GetName();
                    button4.Text = SQLSelections.CurrentHiredHeroes[1].GetName();
                    break;
                case 3:
                    button1.Location = new Point(12, 12 + 55 + 55 + 55);
                    button2.Location = new Point(12, 12);
                    button3.Location = new Point(350, 12);
                    button4.Location = new Point(12, 12 + 55);
                    button8.Location = new Point(350, 12 + 55);
                    button5.Location = new Point(12, 12 + 55 + 55);
                    button9.Location = new Point(350, 12 + 55 + 55);
                    label1.Location = new Point(138, 31);
                    label2.Location = new Point(138, 31 + 55);
                    label3.Location = new Point(138, 31 + 55 + 55);
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    button8.Visible = true;
                    button5.Visible = true;
                    button9.Visible = true;
                    label1.Text = $"Lvl: {SQLSelections.CurrentHiredHeroes[0].GetLvl()}         Exp: {SQLSelections.CurrentHiredHeroes[0].GetExp()} / {SQLSelections.CurrentHiredHeroes[0].GetExpForNextLvl()}          {SQLSelections.CurrentHiredHeroes[0].GetCurentHp()} / {SQLSelections.CurrentHiredHeroes[0].GetHp()} Hp";
                    label2.Text = $"Lvl: {SQLSelections.CurrentHiredHeroes[1].GetLvl()}         Exp: {SQLSelections.CurrentHiredHeroes[1].GetExp()} / {SQLSelections.CurrentHiredHeroes[1].GetExpForNextLvl()}          {SQLSelections.CurrentHiredHeroes[1].GetCurentHp()} / {SQLSelections.CurrentHiredHeroes[1].GetHp()} Hp";
                    label3.Text = $"Lvl: {SQLSelections.CurrentHiredHeroes[2].GetLvl()}         Exp: {SQLSelections.CurrentHiredHeroes[2].GetExp()} / {SQLSelections.CurrentHiredHeroes[2].GetExpForNextLvl()}          {SQLSelections.CurrentHiredHeroes[2].GetCurentHp()} / {SQLSelections.CurrentHiredHeroes[2].GetHp()} Hp";
                    button2.Text = SQLSelections.CurrentHiredHeroes[0].GetName();
                    button4.Text = SQLSelections.CurrentHiredHeroes[1].GetName();
                    button5.Text = SQLSelections.CurrentHiredHeroes[2].GetName();

                    break;
                case 4:
                    button1.Location = new Point(12, 12 + 55 + 55 + 55 + 55);
                    button2.Location = new Point(12, 12);
                    button3.Location = new Point(350, 12);
                    button4.Location = new Point(12, 12 + 55);
                    button8.Location = new Point(350, 12 + 55);
                    button5.Location = new Point(12, 12 + 55 + 55);
                    button9.Location = new Point(350, 12 + 55 + 55);
                    button6.Location = new Point(12, 12 + 55 + 55 + 55);
                    button10.Location = new Point(350, 12 + 55 + 55 + 55);
                    label1.Location = new Point(138, 31);
                    label2.Location = new Point(138, 31 + 55);
                    label3.Location = new Point(138, 31 + 55 + 55);
                    label4.Location = new Point(138, 31 + 55 + 55 + 55);
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    button8.Visible = true;
                    button5.Visible = true;
                    button9.Visible = true;
                    button6.Visible = true;
                    button10.Visible = true;
                    label1.Text = $"Lvl: {SQLSelections.CurrentHiredHeroes[0].GetLvl()}         Exp: {SQLSelections.CurrentHiredHeroes[0].GetExp()} / {SQLSelections.CurrentHiredHeroes[0].GetExpForNextLvl()}          {SQLSelections.CurrentHiredHeroes[0].GetCurentHp()} / {SQLSelections.CurrentHiredHeroes[0].GetHp()} Hp";
                    label2.Text = $"Lvl: {SQLSelections.CurrentHiredHeroes[1].GetLvl()}         Exp: {SQLSelections.CurrentHiredHeroes[1].GetExp()} / {SQLSelections.CurrentHiredHeroes[1].GetExpForNextLvl()}          {SQLSelections.CurrentHiredHeroes[1].GetCurentHp()} / {SQLSelections.CurrentHiredHeroes[1].GetHp()} Hp";
                    label3.Text = $"Lvl: {SQLSelections.CurrentHiredHeroes[2].GetLvl()}         Exp: {SQLSelections.CurrentHiredHeroes[2].GetExp()} / {SQLSelections.CurrentHiredHeroes[2].GetExpForNextLvl()}          {SQLSelections.CurrentHiredHeroes[2].GetCurentHp()} / {SQLSelections.CurrentHiredHeroes[2].GetHp()} Hp";
                    label4.Text = $"Lvl: {SQLSelections.CurrentHiredHeroes[3].GetLvl()}         Exp: {SQLSelections.CurrentHiredHeroes[3].GetExp()} / {SQLSelections.CurrentHiredHeroes[3].GetExpForNextLvl()}          {SQLSelections.CurrentHiredHeroes[3].GetCurentHp()} / {SQLSelections.CurrentHiredHeroes[3].GetHp()} Hp";
                    button2.Text = SQLSelections.CurrentHiredHeroes[0].GetName();
                    button4.Text = SQLSelections.CurrentHiredHeroes[1].GetName();
                    button5.Text = SQLSelections.CurrentHiredHeroes[2].GetName();
                    button6.Text = SQLSelections.CurrentHiredHeroes[3].GetName();

                    break;
                case 5:
                    button1.Location = new Point(12, 12 + 55 + 55 + 55 + 55 + 55);
                    button2.Location = new Point(12, 12);
                    button3.Location = new Point(350, 12);
                    button4.Location = new Point(12, 12 + 55);
                    button8.Location = new Point(350, 12 + 55);
                    button5.Location = new Point(12, 12 + 55 + 55);
                    button9.Location = new Point(350, 12 + 55 + 55);
                    button6.Location = new Point(12, 12 + 55 + 55 + 55);
                    button10.Location = new Point(350, 12 + 55 + 55 + 55);
                    button7.Location = new Point(12, 12 + 55 + 55 + 55 + 55);
                    button11.Location = new Point(350, 12 + 55 + 55 + 55 + 55);
                    label1.Location = new Point(138, 31);
                    label2.Location = new Point(138, 31 + 55);
                    label3.Location = new Point(138, 31 + 55 + 55);
                    label4.Location = new Point(138, 31 + 55 + 55 + 55);
                    label5.Location = new Point(138, 31 + 55 + 55 + 55 + 55);
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    label4.Visible = true;
                    label5.Visible = true;
                    button7.Visible = true;
                    button11.Visible = true;
                    button2.Visible = true;
                    button3.Visible = true;
                    button4.Visible = true;
                    button8.Visible = true;
                    button5.Visible = true;
                    button9.Visible = true;
                    button6.Visible = true;
                    button10.Visible = true;
                    label1.Text = $"Lvl: {SQLSelections.CurrentHiredHeroes[0].GetLvl()}         Exp: {SQLSelections.CurrentHiredHeroes[0].GetExp()} / {SQLSelections.CurrentHiredHeroes[0].GetExpForNextLvl()}          {SQLSelections.CurrentHiredHeroes[0].GetCurentHp()} / {SQLSelections.CurrentHiredHeroes[0].GetHp()} Hp";
                    label2.Text = $"Lvl: {SQLSelections.CurrentHiredHeroes[1].GetLvl()}         Exp: {SQLSelections.CurrentHiredHeroes[1].GetExp()} / {SQLSelections.CurrentHiredHeroes[1].GetExpForNextLvl()}          {SQLSelections.CurrentHiredHeroes[1].GetCurentHp()} / {SQLSelections.CurrentHiredHeroes[1].GetHp()} Hp";
                    label3.Text = $"Lvl: {SQLSelections.CurrentHiredHeroes[2].GetLvl()}         Exp: {SQLSelections.CurrentHiredHeroes[2].GetExp()} / {SQLSelections.CurrentHiredHeroes[2].GetExpForNextLvl()}          {SQLSelections.CurrentHiredHeroes[2].GetCurentHp()} / {SQLSelections.CurrentHiredHeroes[2].GetHp()} Hp";
                    label4.Text = $"Lvl: {SQLSelections.CurrentHiredHeroes[3].GetLvl()}         Exp: {SQLSelections.CurrentHiredHeroes[3].GetExp()} / {SQLSelections.CurrentHiredHeroes[3].GetExpForNextLvl()}          {SQLSelections.CurrentHiredHeroes[3].GetCurentHp()} / {SQLSelections.CurrentHiredHeroes[3].GetHp()} Hp";
                    label5.Text = $"Lvl: {SQLSelections.CurrentHiredHeroes[4].GetLvl()}         Exp: {SQLSelections.CurrentHiredHeroes[4].GetExp()} / {SQLSelections.CurrentHiredHeroes[4].GetExpForNextLvl()}          {SQLSelections.CurrentHiredHeroes[4].GetCurentHp()} / {SQLSelections.CurrentHiredHeroes[4].GetHp()} Hp";
                    button2.Text = SQLSelections.CurrentHiredHeroes[0].GetName();
                    button4.Text = SQLSelections.CurrentHiredHeroes[1].GetName();
                    button5.Text = SQLSelections.CurrentHiredHeroes[2].GetName();
                    button6.Text = SQLSelections.CurrentHiredHeroes[3].GetName();
                    button7.Text = SQLSelections.CurrentHiredHeroes[4].GetName();

                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SQLSelections.CurrentSelectedHeroIndex = 0;
            HeroDetail heroDetail = new HeroDetail();
            heroDetail.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SQLSelections.CurrentSelectedHeroIndex = 0;           
            Adventure adventure = new Adventure();
            adventure.ShowDialog();                                        
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SQLSelections.CurrentSelectedHeroIndex = 1;
            Adventure adventure = new Adventure();
            adventure.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SQLSelections.CurrentSelectedHeroIndex = 2;
            Adventure adventure = new Adventure();
            adventure.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SQLSelections.CurrentSelectedHeroIndex = 3;
            Adventure adventure = new Adventure();
            adventure.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SQLSelections.CurrentSelectedHeroIndex = 4;
            Adventure adventure = new Adventure();
            adventure.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SQLSelections.CurrentSelectedHeroIndex = 1;
            HeroDetail heroDetail = new HeroDetail();
            heroDetail.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SQLSelections.CurrentSelectedHeroIndex = 2;
            HeroDetail heroDetail = new HeroDetail();
            heroDetail.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SQLSelections.CurrentSelectedHeroIndex = 3;
            HeroDetail heroDetail = new HeroDetail();
            heroDetail.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SQLSelections.CurrentSelectedHeroIndex = 4;
            HeroDetail heroDetail = new HeroDetail();
            heroDetail.ShowDialog();
        }

        private void Heroes_Activated(object sender, EventArgs e)
        {
            HeroesInitialize();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
