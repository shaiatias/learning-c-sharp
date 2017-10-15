using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;

namespace RGB_Transports_Button_Label
{
    public partial class MDI : Form
    {
        private const int N = 40, row = 2, N_transport = 7;
        private From _From = new From(N, row);
        private Transport[] arrTransport = new Transport[3];
        private To[] arrTo = new To[3];
 
        private Color[] arrColors = new Color[] { Color.Red, Color.Green, Color.Blue };

        public MDI()
        {
            InitializeComponent();
            _From.StartPosition = FormStartPosition.Manual;
            _From.Location = new Point(0, 0);
            _From.Show();
            _From.MdiParent = this;

            for (int i = 0; i < 3; i++)
            {
                arrTransport[i] = new Transport(N_transport);
                arrTransport[i].Text += " " + arrColors[i].Name;
                arrTransport[i].StartPosition = FormStartPosition.Manual;
                arrTransport[i].Location = new Point(266 * i, 107);
                arrTransport[i].Show();
                arrTransport[i].MdiParent = this;

                arrTo[i] = new To(N);
                arrTo[i].Text += " " + arrColors[i].Name;
                arrTo[i].StartPosition = FormStartPosition.Manual;
                arrTo[i].Location = new Point(0, 180 + 74 * i);
                arrTo[i].Show();
                arrTo[i].MdiParent = this;
            }
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
    }
}
