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

        FigureColor currentPlayer = FigureColor.White;

        public MainForm()
        {
            InitializeComponent();
            _desk.ClearDesk();
            _desk.RepaintCell += PaintCell;
            _desk.Refresh += RefreshDesk;
        }

        int GetPositionInDesk(int i)
        {
            if (currentPlayer == FigureColor.White)
                return i + 1;
            else
                return 8 - i;
        }

        void PaintCell(int i, int j)
        {
            var coords = GetCoordiantes(i, j);
            var control = tableLayoutPanel1.GetControlFromPosition(coords.Y + 1, coords.X + 1) as PictureBox;
            control.BackColor = Color.Green;
            control.Refresh();
        }
        SFigurePosition GetCoordiantes(int i, int j)
        {
            if (_desk.ActivePlayerColor == FigureColor.White)
            {
                return new SFigurePosition(i, j);
            }
            return new SFigurePosition(7 - i, 7 - j);
        }
        void RefreshDesk()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    var coords = GetCoordiantes(i, j);
                    var control = tableLayoutPanel1.GetControlFromPosition(j + 1, i + 1) as PictureBox;
                    if (control != null)
                    {
                        if (_desk[coords.X, coords.Y] != null)
                        {
                            try
                            {
                                var image = Image.FromStream(new MemoryStream(_desk[coords.X, coords.Y].GetImage()));
                                control.Image = image;
                                //var c= new Cursor() 
                                control.Refresh();

                            }
                            catch (Exception)
                            {

                            }
                        }
                        else
                        {
                            control.Image = null;
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

            for (int i = 1; i < 9; i++)
            {
                var control2 = tableLayoutPanel1.GetControlFromPosition(i, 0) as Label;
                var control1 = tableLayoutPanel1.GetControlFromPosition(0, i) as Label;

                if (_desk.ActivePlayerColor == FigureColor.Black)
                {
                    control1.Text = i.ToString();
                    control2.Text = "" + chars[8 - i];
                }
                else
                {
                    control1.Text = (9 - i).ToString();
                    control2.Text = "" + chars[i - 1];
                }
            }
        }
        void SetRowLabel(int i)
        {
            var lb = new Label
            {
                Text = (9 - i).ToString(),
                AutoSize = false,
                Margin = new Padding(0),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            tableLayoutPanel1.Controls.Add(lb);
            tableLayoutPanel1.SetCellPosition(lb, new TableLayoutPanelCellPosition(0, i));
        }
        void SetColumnLabel(int i)
        {
            var lb = new Label
            {
                Text = "" + chars[i - 1],
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            tableLayoutPanel1.Controls.Add(lb);
            tableLayoutPanel1.SetCellPosition(lb, new TableLayoutPanelCellPosition(i, 0));
        }
        void AddCell(int i, int j)
        {
            var f = new PictureBox
            {
                BackColor = (i + j) % 2 == 0 ? Color.White : Color.Gray,
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.StretchImage,
            };
            f.Click += Image_Click;

            tableLayoutPanel1.Controls.Add(f);
            tableLayoutPanel1.SetCellPosition(f, new TableLayoutPanelCellPosition(i, j));
        }

        void AddDeadFigureInfo(TableLayoutPanel obj, FigureColor color)
        {
            for (int i = 0; i < 5; i++)
            {
                var pb = new PictureBox
                {
                    //BackColor = Color.Chartreuse,
                    Dock = DockStyle.Fill,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                };
                obj.Controls.Add(pb);
                obj.SetCellPosition(pb, new TableLayoutPanelCellPosition(0, i));

                var lb = new Label
                {
                    Text = "x" + 0.ToString(),
                    AutoSize = false,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                };
                obj.Controls.Add(lb);
                obj.SetCellPosition(lb, new TableLayoutPanelCellPosition(1, i));
            }

            if (color == FigureColor.White)
            {
                (obj.GetControlFromPosition(0, 0) as PictureBox).Image =
                    Image.FromStream(new MemoryStream(ResourceImages.QueenWhite));
                (obj.GetControlFromPosition(0, 1) as PictureBox).Image =
                    Image.FromStream(new MemoryStream(ResourceImages.BishopWhite));
                (obj.GetControlFromPosition(0, 2) as PictureBox).Image =
                    Image.FromStream(new MemoryStream(ResourceImages.HourseWhite));
                (obj.GetControlFromPosition(0, 3) as PictureBox).Image =
                    Image.FromStream(new MemoryStream(ResourceImages.RockWhite));
                (obj.GetControlFromPosition(0, 4) as PictureBox).Image =
                    Image.FromStream(new MemoryStream(ResourceImages.PawnWhite));
            }
            else
            {
                (obj.GetControlFromPosition(0, 0) as PictureBox).Image =
                    Image.FromStream(new MemoryStream(ResourceImages.QueenBlack));
                (obj.GetControlFromPosition(0, 1) as PictureBox).Image =
                    Image.FromStream(new MemoryStream(ResourceImages.BishopBlack));
                (obj.GetControlFromPosition(0, 2) as PictureBox).Image =
                    Image.FromStream(new MemoryStream(ResourceImages.HourseBlack));
                (obj.GetControlFromPosition(0, 3) as PictureBox).Image =
                    Image.FromStream(new MemoryStream(ResourceImages.RockBlack));
                (obj.GetControlFromPosition(0, 4) as PictureBox).Image =
                    Image.FromStream(new MemoryStream(ResourceImages.PawnBlack));
            }
            //tableLayoutPanel1.Controls.Add(f);
            //tableLayoutPanel1.SetCellPosition(f, new TableLayoutPanelCellPosition(i, j));
            //f.Dock = DockStyle.Fill;
            //f.SizeMode = PictureBoxSizeMode.StretchImage;

         }

        private void Image_Click(object sender, EventArgs e)
        {
            RefreshDesk();
            var pos = tableLayoutPanel1.GetCellPosition(sender as PictureBox);
            var a = GetCoordiantes(pos.Row - 1, pos.Column - 1);

            (sender as PictureBox).BackColor = Color.Bisque;
            _desk.ChoseAction(a.X, a.Y);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Location = new Point(80, 80);
            //this.Height = 650;
            //this.Width = 660;
            for (int i = 1; i < 9; i++)
            {
                SetRowLabel(i);
                SetColumnLabel(i);
                for (int j = 1; j < 9; j++)
                {
                    AddCell(i, j);
                }
            }
            AddDeadFigureInfo(tableLayoutPanel2, FigureColor.White);
            AddDeadFigureInfo(tableLayoutPanel3, FigureColor.Black);
            RefreshDesk();
            Refresh();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (currentPlayer == FigureColor.White)
            {
                currentPlayer = FigureColor.Black;
                //playerName.Text = "Player2";
            }
            else
            {
                currentPlayer = FigureColor.White;
                //playerName.Text = "Player1";

            }
 
            RefreshDesk();
        }
    }
}
