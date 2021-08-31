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
    public partial class CraftingDialog : Form
    {
        string Slot1;
        string Slot2;
        string Slot3;
        string Slot4;
        int Slot1ID;
        int Slot1Amount;
        int Slot2ID;
        int Slot2Amount;
        int Slot3ID;
        int Slot3Amount;
        int Slot4ID;
        int Slot4Amount;
        int count = 0;
        int x = 0;
        bool Slot1Flag = false;
        bool Slot2Flag = false;
        bool Slot3Flag = false;
        bool Slot4Flag = false;
        string SelectedName;


        List<PictureBox> pictureBoxes = new List<PictureBox>();
        List<ToolTip> toolTips = new List<ToolTip>();

        public CraftingDialog(int index)
        {
            InitializeComponent();
            for(int i =0; i < SQLSelections.CraftingItems.Count; i++)
            {
                if(SQLSelections.CraftingItems[i].GetCrafterType() == index)
                {
                    comboBox1.Items.Add($"{SQLSelections.CraftingItems[i].GetName()}");
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DeletePics();
            pictureBoxes.Clear();
            count = 0;
            x = 0;
            SelectedName = comboBox1.SelectedItem.ToString();
            SlotsInit();

            for(int i = 0; i < SQLSelections.CraftingItems.Count; i++)
            {
                if(comboBox1.SelectedItem.ToString() == SQLSelections.CraftingItems[i].GetName())
                {
                    Slot1 = SQLSelections.CraftingItems[i].GetSlot1Req();
                    Slot2 = SQLSelections.CraftingItems[i].GetSlot2Req();
                    Slot3 = SQLSelections.CraftingItems[i].GetSlot3Req();
                    Slot4 = SQLSelections.CraftingItems[i].GetSlot4Req();
                }
            }

            if(Slot1 != "0")
            {
                string[] slot1Parse = Slot1.Split('/');
                Slot1ID = Int32.Parse(slot1Parse[0]);
                Slot1Amount = Int32.Parse(slot1Parse[1]);
                toolTips.Add(new ToolTip());
                pictureBoxes.Add(new PictureBox());
                this.Controls.Add(pictureBoxes[count]);
                pictureBoxes[count].Location = new Point(12 + x, 50);
                pictureBoxes[count].Size = new Size(70, 70);
                pictureBoxes[count].Visible = true;
                pictureBoxes[count].Image = Image.FromFile($@"C:\Programy\RPGv2\Pics\Drops\{Slot1ID}.png");

                toolTips[count].SetToolTip(pictureBoxes[count], $"{Slot1Amount}x");
                x = x + 82;
                count = count + 1;

                
                         
            }

            if (Slot2 != "0")
            {
                string[] slot2Parse = Slot2.Split('/');
                Slot2ID = Int32.Parse(slot2Parse[0]);
                Slot2Amount = Int32.Parse(slot2Parse[1]);
                pictureBoxes.Add(new PictureBox());
                toolTips.Add(new ToolTip());

                this.Controls.Add(pictureBoxes[count]);
                pictureBoxes[count].Location = new Point(12 + x, 50);
                pictureBoxes[count].Size = new Size(70, 70);
                pictureBoxes[count].Image = Image.FromFile($@"C:\Programy\RPGv2\Pics\Drops\{Slot2ID}.png");
                toolTips[count].SetToolTip(pictureBoxes[count], $"{Slot2Amount}x");


                x = x + 82;
                count = count + 1;

            }

            if (Slot3 != "0")
            {
                string[] slot3Parse = Slot3.Split('/');
                Slot3ID = Int32.Parse(slot3Parse[0]);
                Slot3Amount = Int32.Parse(slot3Parse[1]);
                pictureBoxes.Add(new PictureBox());
                toolTips.Add(new ToolTip());

                this.Controls.Add(pictureBoxes[count]);
                pictureBoxes[count].Location = new Point(12 + x, 50);
                pictureBoxes[count].Size = new Size(70, 70);
                pictureBoxes[count].Image = Image.FromFile($@"C:\Programy\RPGv2\Pics\Drops\{Slot3ID}.png");
                toolTips[count].SetToolTip(pictureBoxes[count], $"{Slot3Amount}x");

                x = x + 82;
                count = count + 1;

            }

            if (Slot4 != "0")
            {
                string[] slot4Parse = Slot4.Split('/');
                Slot4ID = Int32.Parse(slot4Parse[0]);
                Slot4Amount = Int32.Parse(slot4Parse[1]);
                pictureBoxes.Add(new PictureBox());
                toolTips.Add(new ToolTip());

                this.Controls.Add(pictureBoxes[count]);
                pictureBoxes[count].Location = new Point(12 + x, 50);
                pictureBoxes[count].Size = new Size(70, 70);
                pictureBoxes[count].Image = Image.FromFile($@"C:\Programy\RPGv2\Pics\Drops\{Slot4ID}.png");
                toolTips[count].SetToolTip(pictureBoxes[count], $"{Slot4Amount}x");

                x = x + 82;
                count = count + 1;

            }

            


        }

        public void DeletePics()
        {
            for (int i = 0; i < count; i++)
            {
                this.Controls.Remove(pictureBoxes[i]);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex > -1)
            {
                if(Slot1 != "0")
                {
                    for(int i = 0; i < SQLSelections.PlayersItems.Count; i++)
                    {
                        if(SQLSelections.PlayersItems[i].GetID() == Slot1ID && SQLSelections.PlayersItems[Slot1ID-1].GetCount() >= Slot1Amount)
                        {
                            Slot1Flag = true;
                            break;
                        }
                        else
                        {
                            Slot1Flag = false;
                        }
                    }
                }
                else
                {
                    Slot1Flag = true;
                }

                if (Slot2 != "0")
                {
                    for (int i = 0; i < SQLSelections.PlayersItems.Count; i++)
                    {
                        if (SQLSelections.PlayersItems[i].GetID() == Slot2ID && SQLSelections.PlayersItems[Slot2ID-1].GetCount() >= Slot2Amount)
                        {
                            Slot2Flag = true;
                            break;
                        }
                        else
                        {
                            Slot2Flag = false;
                        }
                    }
                }
                else
                {
                    Slot2Flag = true;
                }

                if (Slot3 != "0")
                {
                    for (int i = 0; i < SQLSelections.PlayersItems.Count; i++)
                    {
                        if (SQLSelections.PlayersItems[i].GetID() == Slot3ID && SQLSelections.PlayersItems[Slot3ID-1].GetCount() >= Slot3Amount)
                        {
                            Slot3Flag = true;
                            break;
                        }
                        else
                        {
                            Slot3Flag = false;
                        }
                    }
                }
                else
                {
                    Slot3Flag = true;
                }

                if (Slot4 != "0")
                {
                    for (int i = 0; i < SQLSelections.PlayersItems.Count; i++)
                    {
                        if (SQLSelections.PlayersItems[i].GetID() == Slot4ID && SQLSelections.PlayersItems[Slot4ID-1].GetCount() >= Slot4Amount)
                        {
                            Slot4Flag = true;
                            break;
                        }
                        else
                        {
                            Slot4Flag = false;
                        }
                    }
                }
                else
                {
                    Slot4Flag = true;
                }

                if(Slot1Flag == true && Slot2Flag == true && Slot3Flag == true && Slot4Flag == true)
                {
                    // CRAFT ITEM HERE
                    SQLSelections.UpdateItems(SQLSelections.LoadedPlayers[SQLSelections.CurrentPlayerID-1].GetName(), Slot1ID, Slot1Amount * -1);
                    SQLSelections.UpdateItems(SQLSelections.LoadedPlayers[SQLSelections.CurrentPlayerID-1].GetName(), Slot2ID, Slot2Amount * -1);
                    SQLSelections.UpdateItems(SQLSelections.LoadedPlayers[SQLSelections.CurrentPlayerID-1].GetName(), Slot3ID, Slot3Amount * -1);
                    SQLSelections.UpdateItems(SQLSelections.LoadedPlayers[SQLSelections.CurrentPlayerID-1].GetName(), Slot4ID, Slot4Amount * -1);

                    for(int i = 0; i < SQLSelections.CraftingItems.Count; i++)
                    {
                        if(SQLSelections.CraftingItems[i].GetName() == SelectedName)
                        {
                            SQLSelections.CraftItem(SQLSelections.LoadedPlayers[SQLSelections.CurrentPlayerID-1].GetName(), SQLSelections.CraftingItems[i].GetID());
                        }
                    }
                   
                    SQLSelections.LoadAvailableGear();
                    SQLSelections.LoadPlayersItems(SQLSelections.LoadedPlayers[SQLSelections.CurrentPlayerID-1].GetName());
                    SQLSelections.GetAvailableGearMaxID();
                    MessageBox.Show($"{SelectedName} was crafted!", "Item crafted successfuly");
                    this.Close();




                }
                else
                {
                    MessageBox.Show("Not enough materials to craft this item", "Insuficient Materials");
                }


            }
            else
            {
                MessageBox.Show("Please select an item to craft", "Nothing selected");
            }
        }

        private void SlotsInit()
        {
            Slot1Amount = 0;
            Slot2Amount = 0;
            Slot3Amount = 0;
            Slot4Amount = 0;
        }
    }
}
