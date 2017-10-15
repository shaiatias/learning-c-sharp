using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RGB_Transports_Button_Label
{
    public partial class From : Form
    {
        public Control[] arrControls_From;

        public From(int n, int r)
        {
            InitializeComponent();
            arrControls_From = new Control[n * r];

            Random myRand = new Random();
            Control temp;
            for (int j = 0; j < r; j++)
            for (int i = 0; i < n; i++)
            {
                if (myRand.Next(2) == 0)
                    temp = new Button();
                else
                    temp = new Label();
                temp.Size = new Size(30, 30);
                switch (myRand.Next(3))
                {
                    case 0: temp.BackColor = Color.Red; break;                    
                    case 1: temp.BackColor = Color.Green; break;
                    case 2: temp.BackColor = Color.Blue; break;
                }
                temp.Location = new Point(3 + 31 * i, 3 + 31 * j);
                this.arrControls_From[i + j * n] = temp;
                this.Controls.Add(temp);
            }
        }
    }
}
