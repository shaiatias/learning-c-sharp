using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Red_Green_Blue_Transport_UserControls
{
    public partial class UserControl1 : UserControl
    {
        static Random myRand = new Random();
        public Label[] arrLabels;
        public UserControl1(int counter, string fullEmpty, int index)
        {
            InitializeComponent();
            arrLabels = new Label[counter];
            this.Width = counter * 21 + 7;

            if (fullEmpty == "Empty")
            {
                for (int i = 0; i < counter; i++)
                {
                    arrLabels[i] = new Label();
                    arrLabels[i].Size = new Size(20, 30);
                    arrLabels[i].BackColor = Color.White;
                    arrLabels[i].Location = new Point(2 + 21 * i, 3);
                    this.Controls.Add(arrLabels[i]);
                }
            }
            else
            {
                for (int i = 0; i < counter; i++)
                {
                    arrLabels[i] = new Label();
                    arrLabels[i].Size = new Size(20, 30);
                    if (i < counter * 4/5)
                    {
                        int[] tempArr = new int [2];
                        int tempCount = 0;
                        for (int j = 0; j < 3; j++)
                        {
                            if( j == index)
                                continue;
                            tempArr[tempCount] = j;
                            tempCount ++;
                        }

                        switch (tempArr[myRand.Next(2)])
                        {
                            case 0: arrLabels[i].BackColor = Color.Red; break;
                            case 1: arrLabels[i].BackColor = Color.Green; break;
                            case 2: arrLabels[i].BackColor = Color.Blue; break;
                        }
                    }
                    else
                        arrLabels[i].BackColor = Color.White;

                    arrLabels[i].Location = new Point(2 + 21 * i, 3);
                    this.Controls.Add(arrLabels[i]);
                }
            }
        }
    }
}
