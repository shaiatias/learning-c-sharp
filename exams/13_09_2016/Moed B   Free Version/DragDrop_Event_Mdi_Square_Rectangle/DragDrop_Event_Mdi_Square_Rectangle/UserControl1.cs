using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DragDrop_Event_Mdi_Square_Rectangle
{
    public partial class UserControl1 : UserControl
    {
        public Control[] arrControls;
        private Random tempRand;

        public UserControl1(Random tRand)
        {
            InitializeComponent();
            tempRand = tRand;
            int arrSize = tempRand.Next(15, 24);
            arrControls = new Control[arrSize];

            int currPosition = 2;

            for (int i = 0; i < arrSize; i++)
            {
                if (tempRand.Next(2) == 0)
                    arrControls[i] = new Label();
                else
                    arrControls[i] = new Button();

                arrControls[i].Location = new Point(currPosition, 3);
                int temp = tempRand.Next(15, 40);
                switch (tempRand.Next(4))
                {
                    case 0: arrControls[i].Size = new Size(temp, temp); break;
                    case 1: arrControls[i].Size = new Size(2 * temp, 2 * temp); break;
                    case 2: arrControls[i].Size = new Size(2 * temp, temp); break;
                    case 3: arrControls[i].Size = new Size(temp, 2 * temp); break;
                }

                switch (tempRand.Next(3))
                {
                    case 0: arrControls[i].BackColor = Color.Red; break;
                    case 1: arrControls[i].BackColor = Color.Green; break;
                    case 2: arrControls[i].BackColor = Color.Blue; break;
                }

                currPosition += arrControls[i].Size.Width + 2;
                this.Controls.Add(arrControls[i]);
            }
        }

        private void UserControl1_MouseDown(object sender, MouseEventArgs e)
        {
        }
        private void UserControl1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        private void UserControl1_DragDrop(object sender, DragEventArgs e)
        {
        }

    }
}
