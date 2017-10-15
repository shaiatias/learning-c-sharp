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
        private Control[] myArrControls;
        private ICommon myICommon;

        private Control[] resultArrControls = null;
        private int resultArrControls_Size = 0;

        public Form1()
        {
            InitializeComponent();

            Random myRand = new Random();
            int arrSize = myRand.Next(5, 10);

            myArrControls = new Control[arrSize];

            for (int i = 0; i < arrSize; i++)
            {
                if(  myRand.Next(2) == 0)
                    myArrControls[i] = new Label();
                else
                    myArrControls[i] = new Button();
                myArrControls[i].Size = new Size(40, 40);
                switch (myRand.Next(3))
                {
                    case 0:
                        this.Text = "Red";
                        myArrControls[i].BackColor = Color.FromArgb(myRand.Next(120, 256), 0, 0); break;
                    case 1: 
                        this.Text = "Green";
                        myArrControls[i].BackColor = Color.FromArgb(0, myRand.Next(120, 256), 0); break;
                    case 2: this.Text = "Blue";
                        myArrControls[i].BackColor = Color.FromArgb( 0, 0, myRand.Next(120, 256)); break;
                }
                myArrControls[i].Location = new Point(2 + 41 * i, 3);
                this.Controls.Add(myArrControls[i]);
            }

            HttpChannel channel = new HttpChannel();
            ChannelServices.RegisterChannel(channel, false);

            myICommon = (ICommon)Activator.GetObject(
                typeof(ICommon),
                "http://localhost:1234/_Server_");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TypeColor[] arrTypeColor = new TypeColor[myArrControls.Length];
            for (int i = 0; i < myArrControls.Length; i++)
            {
                arrTypeColor[i] = new TypeColor();
                arrTypeColor[i].mType = myArrControls[i].GetType().Name;
                arrTypeColor[i].mColor = myArrControls[i].BackColor;
            }
            myICommon.add_Client(arrTypeColor);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TypeColor[] arrTypeColor = myICommon.getData(this.Text, resultArrControls_Size);
            if (arrTypeColor == null)
                return;

            if (resultArrControls_Size != 0)
                for (int i = 0; i < resultArrControls_Size; i++)
                    this.Controls.Remove(resultArrControls[i]);

            resultArrControls = new Control[arrTypeColor.Length];
            resultArrControls_Size = arrTypeColor.Length;
            for (int i = 0; i < arrTypeColor.Length; i++)
            {
                if(arrTypeColor[i].mType == "Button")
                    resultArrControls[i] = new Button();
                else
                    resultArrControls[i] = new Label();

                resultArrControls[i].Size = new Size(40, 40);
                resultArrControls[i].BackColor = arrTypeColor[i].mColor;
                resultArrControls[i].Location = new Point(2 + 41 * i, 53);
                this.Controls.Add(resultArrControls[i]);
            }
        }
    }
}

