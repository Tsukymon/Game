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
    public partial class HireHeroes : Form
    {
        public HireHeroes()
        {
            InitializeComponent();

            for (int i = 0; i < SQLSelections.LoadedDefaultHeroes.Count(); i++)
            {
                listBox1.Items.Add(SQLSelections.LoadedDefaultHeroes[i].GetName());
            }


            


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = $"HP: {SQLSelections.LoadedDefaultHeroes[listBox1.SelectedIndex].GetHp()}\r\nAtk: {SQLSelections.LoadedDefaultHeroes[listBox1.SelectedIndex].GetAtk()}\r\nMatk: {SQLSelections.LoadedDefaultHeroes[listBox1.SelectedIndex].GetMatk()}\r\nAcc: {SQLSelections.LoadedDefaultHeroes[listBox1.SelectedIndex].GetAcc()}\r\nCrit: {SQLSelections.LoadedDefaultHeroes[listBox1.SelectedIndex].GetCrit()}\r\nDef: {SQLSelections.LoadedDefaultHeroes[listBox1.SelectedIndex].GetDef()}\r\nMdef: {SQLSelections.LoadedDefaultHeroes[listBox1.SelectedIndex].GetMdef()}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItems.Count != 0)
            {
                this.Close();
                SQLSelections.HireHero(listBox1.SelectedIndex);
            }
        }
    }
}
