using Chess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsChess
{

    public partial class MainForm : Form
    {
        char[] chars = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h' };

        Desk _desk = new Desk();

        public MainForm()
        {
            InitializeComponent();
            _desk.ClearDesk();
            _desk.RepaintCell += PaintCell;

        }
        void PaintCell(int i, int j)
        {
            //var control = tableLayoutPanel1.GetControlFromPosition(8 - j, 8 - i) as PictureBox;
            var control = tableLayoutPanel1.GetControlFromPosition(j + 1, i + 1) as PictureBox;
            control.BackColor = Color.Green;
            control.Refresh();
        }
        void RefreshDesk()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    var control = tableLayoutPanel1.GetControlFromPosition(j + 1, i + 1) as PictureBox;
                    if (control != null)
                    {
                        if (_desk[i, j] != null)
                        {
                            try
                            {
                                var image = Image.FromStream(new MemoryStream(_desk[i, j].GetImage()));
                                control.Image = image;
                            }
                            catch (Exception)
                            {

                            }
                        }

                        if ((i + j) % 2 == 0)
                        {
                            control.BackColor = Color.White;
                        }
                        else
                        {
                            control.BackColor = Color.Gray;
                        }
                        control.Refresh();
                    }
                }
            }

        }
        
        void SetRowLabel(int i)
        {
            var lb = new Label();

            tableLayoutPanel1.Controls.Add(lb);
            tableLayoutPanel1.SetCellPosition(lb, new TableLayoutPanelCellPosition(0, i));
            lb.Text = (9 - i).ToString();
            lb.AutoSize = false;
            lb.Margin = new Padding(0);
            //lb.TextAlign = ContentAlignment.MiddleCenter;
            lb.Dock = DockStyle.Fill;

        }
        void SetColumnLabel(int i)
        {
            var lb = new Label();
            lb.Text = "" + chars[i - 1];
            lb.AutoSize = false;
            lb.TextAlign = ContentAlignment.MiddleCenter;
            tableLayoutPanel1.Controls.Add(lb);
            tableLayoutPanel1.SetCellPosition(lb, new TableLayoutPanelCellPosition(i, 0));
            lb.Dock = DockStyle.Fill;
        }
        void AddCell(int i, int j)
        {
            var f = new PictureBox();
            if ((i + j) % 2 == 0)
            {
                f.BackColor = Color.White;
                //f.Cursor = new Cursor();
            }
            else
            {
                f.BackColor = Color.Gray;
            }

            f.Click += Image_Click;

            tableLayoutPanel1.Controls.Add(f);
            tableLayoutPanel1.SetCellPosition(f, new TableLayoutPanelCellPosition(i, j));
            f.Dock = DockStyle.Fill;
            f.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void Image_Click(object sender, EventArgs e)
        {
            RefreshDesk();
            var pos = tableLayoutPanel1.GetCellPosition(sender as PictureBox);

            (sender as PictureBox).BackColor = Color.Bisque;
            _desk.ChoseAction(pos.Row - 1, pos.Column - 1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Location = new Point(80, 80);
            this.Height = 650;
            this.Width = 660;
            for (int i = 1; i < 9; i++)
            {
                SetRowLabel(i);
                SetColumnLabel(i);
                for (int j = 1; j < 9; j++)
                {
                    AddCell(i, j);
                }
            }
            RefreshDesk();
            Refresh();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
