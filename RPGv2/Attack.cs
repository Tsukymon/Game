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
    public partial class Attack : Form
    {
        public Attack(int index)
        {
            InitializeComponent();
            label7.Text = SQLSelections.LoadedCreatures[index].GetName();
            label1.Text = $"HP: {SQLSelections.LoadedCreatures[index].GetHp().ToString()}";
            label2.Text = $"Atk: {SQLSelections.LoadedCreatures[index].GetAtk().ToString()}";
            label3.Text = $"Def: {SQLSelections.LoadedCreatures[index].GetDef().ToString()}";
            label4.Text = $"Matk: {SQLSelections.LoadedCreatures[index].GetMatk().ToString()}";
            label5.Text = $"Mdef: {SQLSelections.LoadedCreatures[index].GetMdef().ToString()}";
            label6.Text = $"Eva: {SQLSelections.LoadedCreatures[index].GetEva().ToString()}";

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(SQLSelections.CurrentHiredHeroes[SQLSelections.CurrentSelectedHeroIndex].GetCurentHp() != 0)
            {
                CombatReport combatReport = new CombatReport();
                combatReport.ShowDialog();
            }
            else
            {
                MessageBox.Show("Sadly your hero is dead", "Hero is dead");
            }
            
        }



        
    }
}
