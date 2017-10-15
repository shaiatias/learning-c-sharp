using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels;
using Common;

namespace Client
{
    public partial class Form1 : Form
    {
        private  ICommon myICommon;
        private Random myRand = new Random();

        private Label[] arrLabels = null, arrLabelsResult = null;
        private int counter = 0;
        public Form1()
        {
            InitializeComponent();

            HttpChannel channel = new HttpChannel();
            ChannelServices.RegisterChannel(channel, false);

            ICommonFactory myICommonFactory = (ICommonFactory)Activator.GetObject(
                typeof(ICommonFactory),
                "http://localhost:1234/_Server_");

            myICommon = myICommonFactory.getNewInstance(); 
        }

        private void ButtonNew_Click(object sender, EventArgs e)
        {
            counter++;
            labelCounter.Text = counter.ToString();

            if( arrLabels != null)
                for (int i = 0; i < arrLabels.Length; i++)
                    this.Controls.Remove(arrLabels[i]);
                
            arrLabels = new Label[myRand.Next(10, 21)];
            int currPosition = 3;
            for (int i = 0; i < arrLabels.Length; i++)
            {
                arrLabels[i] = new Label();
                arrLabels[i].BackColor = Color.FromArgb(myRand.Next(120, 256), myRand.Next(120, 256), myRand.Next(120, 256));
                int tempXY = myRand.Next(25, 46);
                switch (myRand.Next(4))
                {
                    case 0:
                    case 1: arrLabels[i].Size = new Size(tempXY, tempXY); break;
                    case 2: arrLabels[i].Size = new Size(tempXY * 2, tempXY); break;
                    case 3: arrLabels[i].Size = new Size(tempXY, tempXY * 2); break;
                }

                arrLabels[i].Location = new Point(currPosition, 3);
                currPosition += arrLabels[i].Size.Width + 2;
                arrLabels[i].Click += new EventHandler(allLabels_Click);
                this.Controls.Add(arrLabels[i]);
            }
        }

        private void allLabels_Click(object sender, EventArgs e)
        {
        }

        private void buttonRectangleSquare_Click(object sender, EventArgs e)
        {
        }
    }
}

