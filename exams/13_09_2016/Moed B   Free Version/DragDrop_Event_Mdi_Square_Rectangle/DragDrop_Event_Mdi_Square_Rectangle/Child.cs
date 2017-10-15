using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace DragDrop_Event_Mdi_Square_Rectangle
{
    public partial class Child : Form
    {
        public UserControl1[] arrUC = new UserControl1[2];

        public Control Max_RectangleSquare_control = null;
        static Random myRand = new Random();

        public Child()
        {
            InitializeComponent();
            for (int i = 0; i < 2; i++)
            {
                arrUC[i] = new UserControl1(myRand);
                arrUC[i].Location = new Point(100, 27 + 85 * i);
                this.Controls.Add(arrUC[i]);
            }
            if (myRand.Next(2) == 0)
                Max_RectangleSquare.Text += "Rectangle";
            else
                Max_RectangleSquare.Text += "Square";
        }
    }
}
