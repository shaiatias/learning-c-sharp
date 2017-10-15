using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RGB_ButtonLabel_Transport_UserControl
{
    public partial class UserControl1 : UserControl
    {
        static Random myRand = new Random();
        public Control[] arrControls;
        public UserControl1(int counter, string fullEmpty, string ButtonLabel)
        {
            InitializeComponent();
            arrControls = new Control[counter];
            this.Width = counter * 21 + 7;

            if (fullEmpty == "Full")
            {
                for (int i = 0; i < counter; i++)
                {
                    if (ButtonLabel == "Button")
                        arrControls[i] = new Button();
                    else
                        arrControls[i] = new Label();
                    arrControls[i].Size = new Size(20, 30);
                    switch (myRand.Next(3))
                    {
                        case 0: arrControls[i].BackColor = Color.FromArgb(myRand.Next(130, 256), 0, 0); break;
                        case 1: arrControls[i].BackColor = Color.FromArgb(0, myRand.Next(130, 256), 0); break;
                        case 2: arrControls[i].BackColor = Color.FromArgb(0, 0, myRand.Next(130, 256)); break;
                    }
 
                    arrControls[i].Location = new Point(2 + 21 * i, 3);
                    this.Controls.Add(arrControls[i]);
                }
            }
        }
    }
}
