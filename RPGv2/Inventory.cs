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
            int Count = 0;
            int x = 0;
            int y = 0;
            List<PictureBox> pictureBoxes = new List<PictureBox>();
            List<ToolTip> toolTips = new List<ToolTip>();
            
            for(int i = 0; i < SQLSelections.AvailableGear.Count; i++)
            {
                if(SQLSelections.AvailableGear[i].GetPlayerID() == SQLSelections.CurrentPlayerID)
                {
                    Count++;
                }
            }

            for(int i = 0; i < Count; i++)
            {
                pictureBoxes.Add(new PictureBox());
                toolTips.Add(new ToolTip());
                
                this.Controls.Add(pictureBoxes[i]);
                pictureBoxes[i].Visible = true;
                pictureBoxes[i].Location = new Point(12 + x, 12 + y);
                pictureBoxes[i].Size = new Size(50, 50);                               
                x += 62;

                toolTips[i].SetToolTip(pictureBoxes[i], i.ToString());
                pictureBoxes[i].Image = Image.FromFile($@"C:\Programy\RPGv2\Pics\{SQLSelections.AvailableGear[i].GetGearType()}.png");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {

        }
    }
}
