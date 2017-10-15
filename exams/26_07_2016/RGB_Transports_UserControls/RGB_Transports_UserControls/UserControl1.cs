using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RGB_Transports_UserControls
{
    public partial class UserControl1 : UserControl
    {
        public Label[] arrLabels;
        private  static Random myRand = new Random();
        public UserControl1(int n, int r, string fullEmpty)
        {
            InitializeComponent();
            arrLabels = new Label[n * r];
            this.Width = n * 31 + 7;
            this.Height = r * 31 + 7;
            for (int j = 0; j < r; j++)
            for (int i = 0; i < n ; i++)
            {
                Label temp = new Label();
                temp.Size = new Size(30, 30);
                if (fullEmpty == "Empty")
                    temp.BackColor = Color.White;
                else
                {
                    switch (myRand.Next(3))
                    {
                        case 0: temp.BackColor = Color.FromArgb(myRand.Next(150, 256), 0, 0); break;
                        case 1: temp.BackColor = Color.FromArgb(0, myRand.Next(150, 256), 0); break;
                        case 2: temp.BackColor = Color.FromArgb( 0, 0, myRand.Next(150, 256)); break;
                    }
                }
                temp.Location = new Point(3 + 31 * i, 4 + 31 * j);
                temp.BorderStyle = BorderStyle.FixedSingle;
                this.arrLabels[i + j * n] = temp;
                this.Controls.Add(temp);
            }
        }
    }
}