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
        char[] chars = new char[] { 'a', 'b', 'c', 'd', 'e','f','g','h' };

        Desk _desk = new Desk();

        FigureColor currentPlayer = FigureColor.White;

        public MainForm()
        {
            InitializeComponent();
            _desk.ClearDesk();

        }

        int GetPositionInDesk(int i)
        {
            if (currentPlayer == FigureColor.White)
                return i + 1;
            else
                return 8 - i;
        }

        void RefreshDesk()
        {
            for (int i=0;i<8;i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (_desk[i, j] != null)
                    {
                        var control = tableLayoutPanel1.GetControlFromPosition(GetPositionInDesk(j), GetPositionInDesk(i)) as PictureBox;
                        if (control != null)
                        {
                            try
                            {
                                var image = Image.FromStream(new MemoryStream(_desk[i, j].GetImage()));
                                control.Image = image;
                                //var c= new Cursor() 
                                control.Refresh();
                                
                            }
                            catch
                            {

                            }

                        }
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
            lb.Text = ""+chars[i-1];
            lb.AutoSize = false;
            lb.TextAlign = ContentAlignment.MiddleCenter;
            tableLayoutPanel1.Controls.Add(lb);
            tableLayoutPanel1.SetCellPosition(lb, new TableLayoutPanelCellPosition(i, 0));
            lb.Dock = DockStyle.Fill;

        }

        void AddCell(int i, int j)
        {
            var f = new PictureBox();
            if ((i+j) % 2 == 0)
            {
                f.BackColor = Color.White;
                //f.Cursor = new Cursor();
            }
            else
            {
                f.BackColor = Color.Gray;
            }
            tableLayoutPanel1.Controls.Add(f);
            tableLayoutPanel1.SetCellPosition(f, new TableLayoutPanelCellPosition(i, j));
            f.Dock = DockStyle.Fill;
            f.SizeMode = PictureBoxSizeMode.StretchImage;

         }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            this.Height = 650;
            this.Width = 600;
            for (int i = 1; i < 9; i++)
            {
                SetRowLabel(i);
                SetColumnLabel(i);
                for (int j=1;j<9;j++)
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (currentPlayer == FigureColor.White)
            {
                currentPlayer = FigureColor.Black;
                playerName.Text = "Player2";
            }
            else
            {
                currentPlayer = FigureColor.White;
                playerName.Text = "Player1";

            }
 
            RefreshDesk();
        }
    }
}
