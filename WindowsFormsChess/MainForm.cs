using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsChess
{

    public partial class MainForm : Form
    {
        char[] chars = new char[] { 'a', 'b', 'c', 'd', 'e','f','g','h' };

        public MainForm()
        {
            InitializeComponent();

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
            }
            else
            {
                f.BackColor = Color.Gray;
            }
            tableLayoutPanel1.Controls.Add(f);
            tableLayoutPanel1.SetCellPosition(f, new TableLayoutPanelCellPosition(i, j));
            f.Dock = DockStyle.Fill;


        }


        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 9; i++)
            {
                SetRowLabel(i);
                SetColumnLabel(i);
                for (int j=1;j<9;j++)
                {
                    AddCell(i, j);

                }
            }
            Refresh();


        }
    }
}
