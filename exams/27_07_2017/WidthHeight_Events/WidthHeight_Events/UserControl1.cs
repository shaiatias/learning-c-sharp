using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WidthHeight_Events
{
    public partial class UserControl1 : UserControl
    {
        public Control[] arrControls;
        public int arrControls_size;
        private static Random myRand = new Random();

        public UserControl1()
        {
            InitializeComponent();
            arrControls_size = myRand.Next(8, 14);

            arrControls = new Control[arrControls_size];
            int currPosition = 2;
            for (int i = 0; i < arrControls_size; i++)
            {
                if (myRand.Next(0, 2) == 0)
                    arrControls[i] = new Button();
                else
                {
                    arrControls[i] = new Label();
                    ((Label)arrControls[i]).TextAlign = ContentAlignment.MiddleCenter;
                }

                int W = myRand.Next(43, 120);
                int H = myRand.Next(50, 120);

                arrControls[i].Size = new Size(W, H);
                arrControls[i].Text = W.ToString() + "\n" + H.ToString();
                arrControls[i].ForeColor = Color.White;

                switch (myRand.Next(3))
                {
                    case 0: arrControls[i].BackColor = Color.Red; break;
                    case 1: arrControls[i].BackColor = Color.Green; break;
                    case 2: arrControls[i].BackColor = Color.Blue; break;
                }

                arrControls[i].Location = new Point(currPosition, 2);
                currPosition += arrControls[i].Width + 2;
                arrControls[i].Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
                this.Controls.Add(arrControls[i]);
            }
        }

        public event MyEventHandler eventFromUc;

        private void UserControl1_Click(object sender, EventArgs e)
        {
            if (eventFromUc != null)
                eventFromUc.Invoke(this, new MyEventArgs(this, null));
        }

        public void paintNewControls(List<Control> buttonsList)
        {
            // remove all
            arrControls.ToList().ForEach(item => Controls.Remove(item));
            arrControls = null;

            // repaint all
            arrControls = new Control[buttonsList.Count];

            int currPosition = 2;

            for (int i = 0; i < buttonsList.Count; i++)
            {
                if (buttonsList[i].GetType().Equals(typeof(Button)))
                {
                    arrControls[i] = new Button() {
                        Size = buttonsList[i].Size,
                        BackColor = buttonsList[i].BackColor,
                        Text = buttonsList[i].Text,
                        TextAlign = ContentAlignment.MiddleCenter,
                        ForeColor = Color.White,
                        Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold)
                };
                }

                else
                {
                    arrControls[i] = new Label()
                    {
                        Size = buttonsList[i].Size,
                        BackColor = buttonsList[i].BackColor,
                        Text = buttonsList[i].Text,
                        TextAlign = ContentAlignment.MiddleCenter,
                        ForeColor = Color.White,
                        Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold)
                    };
                }

                arrControls[i].Location = new Point(currPosition, 2);

                currPosition += arrControls[i].Width + 2;
                this.Controls.Add(arrControls[i]);
            }
        }
    }
}
