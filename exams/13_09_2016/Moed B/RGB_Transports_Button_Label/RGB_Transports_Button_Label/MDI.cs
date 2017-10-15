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
    public delegate void addDelegate(int index, Control _control);
    public delegate void remove_Transport_Delegate(int index, Control _control, int i);
    public delegate void remove_From_Delegate(Control _control, int i);

    public partial class MDI : Form
    {
        private const int N = 40, row = 2, N_transport = 7;
        private From _From = new From(N, row);
        private Transport[] arrTransport = new Transport[3];
        private To[] arrTo = new To[3];
 
        private Color[] arrColors = new Color[] { Color.Red, Color.Green, Color.Blue };

        private Thread[] toTransport = new Thread[3], fromTransport = new Thread[3];
        private int[] arrButtonLabel_Flag = new int[3];  // 0 - button, 1 - label,   2, 3, ... - end
        private int[] arrCounter_To = new int[3], arrCounter_Transport = new int[3];

        private bool[] arrIsEnd = new bool[3];
        private AutoResetEvent[] arrAutoResetEvent_1 = new AutoResetEvent[3], arrAutoResetEvent_2 = new AutoResetEvent[3];

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

                arrAutoResetEvent_1[i] = new AutoResetEvent(false);
                arrAutoResetEvent_2[i] = new AutoResetEvent(false);
            }
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                toTransport[i] = new Thread(toTransport_Function);
                fromTransport[i] = new Thread(fromTransport_Function);

                toTransport[i].Start(i);
                fromTransport[i].Start(i);
            }
        }

        void toTransport_Function(object o)
        {
            int index = (int)o;
            while (true)
            {
                int i = 0;
                for (i = 0; i < N * row; i++)
                {
                    Control temp = _From.arrControls_From[i];
                    if (temp == null)
                        continue;
                    if (temp.BackColor == arrColors[index]
                        &&
                        (temp.GetType().Name == "Button" && arrButtonLabel_Flag[index] == 0
                        ||
                         temp.GetType().Name == "Label" && arrButtonLabel_Flag[index] == 1))
                    {
                        this.Invoke(new addDelegate(add_Transport), new object[] { index, temp });
                        this.Invoke(new remove_From_Delegate(remove_From), new object[] { temp, i });
                        arrCounter_Transport[index]++;
                        Thread.Sleep(100);
                        if (arrCounter_Transport[index] == N_transport)
                        {
                            arrAutoResetEvent_1[index].Set();
                            arrAutoResetEvent_2[index].WaitOne();
                        }
                    }
                }
                if( i == N * row)
                {
                    arrButtonLabel_Flag[index]++;
                    if (arrButtonLabel_Flag[index]== 1)
                        continue;
                    else
                    {                   
                        arrAutoResetEvent_1[index].Set();
                        arrIsEnd[index] = true;
                        break;
                    }
                }
            }
        }

        void fromTransport_Function(object o)
        {
            int index = (int)o;
            while (true)
            {
                arrAutoResetEvent_1[index].WaitOne();

                for (int i = 0; i < arrCounter_Transport[index]; i++)
                {
                    Control temp = arrTransport[index].arrControls_Transport[i];
                    this.Invoke(new addDelegate(add_To), new object[] { index, temp });
                    arrCounter_To[index]++;
                    this.Invoke(new remove_Transport_Delegate(remove_Transport), new object[] { index, temp, i });
                    Thread.Sleep(100);
                }
                arrCounter_Transport[index] = 0;

  //              MessageBox.Show(index.ToString());

                if (arrIsEnd[index] == false)
                    arrAutoResetEvent_2[index].Set();
                else
                    break;
            }
        }

        private void add_Transport(int index, Control _control)
        {
            arrTransport[index].arrControls_Transport[arrCounter_Transport[index]] = _control;
            _control.Location = new Point(3 + 31 * arrCounter_Transport[index], 3);
            arrTransport[index].Controls.Add(_control);
        }
        private void add_To(int index, Control _control)
        {
            arrTo[index].arrControls_To[arrCounter_To[index]] = _control;
            _control.Location = new Point(3 + 31 * arrCounter_To[index], 3);
            arrTo[index].Controls.Add(_control);
        }
        private void remove_Transport(int index, Control _control, int i)
        {
            arrTransport[index].arrControls_Transport[i] = null;
            arrTransport[index].Controls.Remove(_control);
        }
        private void remove_From(Control _control, int i)
        {
            _From.arrControls_From[i] = null;
            _From.Controls.Remove(_control);
        }
    }
}
