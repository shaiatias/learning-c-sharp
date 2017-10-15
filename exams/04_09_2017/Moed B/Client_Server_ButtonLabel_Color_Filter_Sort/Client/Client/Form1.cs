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
        private ICommon myICommon;
        private Random myRand = new Random();

        private Control[] arrControls;
        public Form1()
        {
            InitializeComponent();

            HttpChannel channel = new HttpChannel();
            ChannelServices.RegisterChannel(channel, false);

            ICommonFactory myICommonFactory = (ICommonFactory)Activator.GetObject(
                typeof(ICommonFactory),
                "http://localhost:1234/_Server_");

            myICommon = myICommonFactory.getNewInstance();

            arrControls = new Control[25];
            int currPosition = 3;
            for (int i = 0; i < arrControls.Length; i++)
            {
                if( myRand.Next(2) == 0)
                    arrControls[i] = new Button();
                else
                    arrControls[i] = new Label();
                switch (myRand.Next(3))
                {
                    case 0: arrControls[i].BackColor = Color.FromArgb(myRand.Next(130, 256), 0, 0); break;
                    case 1: arrControls[i].BackColor = Color.FromArgb(0, myRand.Next(130, 256), 0); break;
                    case 2: arrControls[i].BackColor = Color.FromArgb(0, 0, myRand.Next(130, 256)); break;
                }
                arrControls[i].TabIndex = i;
                arrControls[i].Size = new Size(40, 40);
                arrControls[i].Location = new Point(currPosition, 3);
                currPosition += arrControls[i].Size.Width + 2;
                arrControls[i].Click += new EventHandler(allControls_Click);
                this.Controls.Add(arrControls[i]);
            }
        }

        private void allControls_Click(object sender, EventArgs e)
        {
            Control tempControl = (Control)sender;
            IndexColorType tempIndexColorType = new IndexColorType();
            tempIndexColorType.mIndex = tempControl.TabIndex;
            tempIndexColorType.mColor = tempControl.BackColor; 
            tempIndexColorType.mType = tempControl.GetType().Name;
            int[] resultArr = myICommon.CallToServer(tempIndexColorType);
            if (resultArr == null)
                return;
            int currPosition = 3;
            for (int i = 0; i < resultArr.Length; i++)
            {             
                arrControls[resultArr[i]].Location = new Point(currPosition, 50);
                currPosition += 42;
            }
        }
    }
}

