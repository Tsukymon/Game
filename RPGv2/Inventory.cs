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
    public partial class Inventory : Form
    {
        public Inventory()
        {
            InitializeComponent();
            InitializeInventory();
            
            
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void InitializeInventory()
        {
            int Count = 0;
            int j = 0;
            int x = 0;
            int y = 0;
            List<PictureBox> pictureBoxesGear = new List<PictureBox>();
            List<PictureBox> pictureBoxesItems = new List<PictureBox>();
            List<ToolTip> toolTipsGear = new List<ToolTip>();
            List<ToolTip> toolTipsItems = new List<ToolTip>();
            pictureBoxesGear.Clear();
            pictureBoxesItems.Clear();
            toolTipsGear.Clear();
            toolTipsItems.Clear();

            for (int i = 0; i < SQLSelections.AvailableGear.Count; i++)
            {
                if (SQLSelections.AvailableGear[i].GetPlayerID() == SQLSelections.CurrentPlayerID)
                {
                    Count++;
                }
            }

            for (int i = 0; i < Count; i++)
            {
                pictureBoxesGear.Add(new PictureBox());
                toolTipsGear.Add(new ToolTip());

                this.Controls.Add(pictureBoxesGear[i]);
                pictureBoxesGear[i].Visible = true;
                pictureBoxesGear[i].Location = new Point(12 + x, 12 + y);
                pictureBoxesGear[i].Size = new Size(70, 70);
                x += 82;

                if (x > 740)
                {
                    x = 0;
                    y += 82;
                }

                if (SQLSelections.AvailableGear[i].GetEquipedStatus() == true)
                {
                    toolTipsGear[i].SetToolTip(pictureBoxesGear[i], $"{SQLSelections.AvailableGear[i].GetName()} Lvl: {SQLSelections.AvailableGear[i].GetLvlReq()}\r\n\r\nHp: {SQLSelections.AvailableGear[i].GetHp()}   Atk: {SQLSelections.AvailableGear[i].GetAtk()}   Matk: {SQLSelections.AvailableGear[i].GetMatk()}\r\nAcc: {SQLSelections.AvailableGear[i].GetAcc()}   Crit: {SQLSelections.AvailableGear[i].GetCrit()}\r\nDef: {SQLSelections.AvailableGear[i].GetDef()}   Mdef: {SQLSelections.AvailableGear[i].GetMdef()}\r\n\r\nEquiped by {SQLSelections.CurrentHiredHeroes[SQLSelections.AvailableGear[i].GetHeroID()].GetName()} Lvl: {SQLSelections.CurrentHiredHeroes[SQLSelections.AvailableGear[i].GetHeroID()].GetLvl()}");
                }
                else
                {
                    toolTipsGear[i].SetToolTip(pictureBoxesGear[i], $"{SQLSelections.AvailableGear[i].GetName()} Lvl: {SQLSelections.AvailableGear[i].GetLvlReq()}\r\n\r\nHp: {SQLSelections.AvailableGear[i].GetHp()}   Atk: {SQLSelections.AvailableGear[i].GetAtk()}   Matk: {SQLSelections.AvailableGear[i].GetMatk()}\r\nAcc: {SQLSelections.AvailableGear[i].GetAcc()}   Crit: {SQLSelections.AvailableGear[i].GetCrit()}\r\nDef: {SQLSelections.AvailableGear[i].GetDef()}   Mdef: {SQLSelections.AvailableGear[i].GetMdef()}");
                }

                pictureBoxesGear[i].Image = Image.FromFile($@"C:\Programy\RPGv2\Pics\{SQLSelections.AvailableGear[i].GetGearType()}.png");
            }

            for (int i = 0; i < SQLSelections.PlayersItems.Count; i++)
            {
                if (SQLSelections.PlayersItems[i].GetCount() != 0)
                {
                    pictureBoxesItems.Add(new PictureBox());
                    toolTipsItems.Add(new ToolTip());

                    if (x > 740)
                    {
                        x = 0;
                        y += 82;
                    }

                    this.Controls.Add(pictureBoxesItems[j]);
                    pictureBoxesItems[j].Visible = true;
                    pictureBoxesItems[j].Location = new Point(12 + x, 12 + y);
                    pictureBoxesItems[j].Size = new Size(70, 70);
                    toolTipsItems[j].SetToolTip(pictureBoxesItems[j], $"{SQLSelections.PlayersItems[i].GetName()} {SQLSelections.PlayersItems[i].GetCount()}x");
                    x += 82;

                    pictureBoxesItems[j].Image = Image.FromFile($@"C:\Programy\RPGv2\Pics\Drops\{SQLSelections.PlayersItems[i].GetID()}.png");
                    j++;
                }
            }
        }

        private void Inventory_Shown(object sender, EventArgs e)
        {
            InitializeInventory();
        }
    }
}
