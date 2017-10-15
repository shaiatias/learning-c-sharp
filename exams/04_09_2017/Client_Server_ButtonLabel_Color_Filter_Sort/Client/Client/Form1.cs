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
            MControl control = new MControl();

            control.color = ((Control)sender).BackColor;
            control.controlClass = sender is Button ? typeof(Button) : typeof(Label);
            control.indexInClient = ((Control)sender).TabIndex;
            control.size = ((Control)sender).Size;

            ServerState state = myICommon.selectControl(control);

            paintNewState(state);
        }

        private void paintNewState(ServerState state)
        {
            foreach (MControl control in state.buttons.Concat(state.labels))
            {
                var found = Controls.OfType<Control>().Where(c => c.TabIndex == control.indexInClient);

                if (found.Count() > 0)
                {
                    this.Controls.Remove(found.First());
                }
            }

            flowLayoutPanel1.Controls.Clear();

            List<MControl> buttons = new List<MControl>(state.buttons);
            buttons.Sort((x, y) => x.indexInClient - y.indexInClient);

            List<MControl> labels = new List<MControl>(state.labels);
            labels.Sort((x, y) => x.indexInClient - y.indexInClient);

            foreach (MControl c in buttons)
            {
                Button b = new Button();
                b.Size = c.size;
                b.TabIndex = c.indexInClient;
                b.BackColor = c.color;

                flowLayoutPanel1.Controls.Add(b);
            }

            foreach (MControl c in labels)
            {
                Label b = new Label();
                b.Size = c.size;
                b.TabIndex = c.indexInClient;
                b.BackColor = c.color;

                flowLayoutPanel1.Controls.Add(b);
            }
        }
    }
}

