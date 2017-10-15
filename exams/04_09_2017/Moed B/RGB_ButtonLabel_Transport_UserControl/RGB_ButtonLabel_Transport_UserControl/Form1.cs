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

namespace RGB_ButtonLabel_Transport_UserControl
{
    public delegate void myAddDelegate(UserControl1 UC_To, int counter_To, UserControl1 UC_From, int index_From);
    public delegate void myRemoveDelegate(UserControl1 UC, int i);

    public partial class Form1 : Form
    {
        private UserControl1[] arrUC_From = new UserControl1[2],
            arrUC_To = new UserControl1[3], arrUC_Transport = new UserControl1[3];
        private const int N = 55;
        private Color[] arrColors = new Color[] { Color.Red, Color.Green, Color.Blue };
        private Thread[] arr_toTransport = new Thread[3], arr_fromTransport = new Thread[3];
        private int[] arrIndex_From = new int[3];

        private int[] arrFlag_ButtonLabel = new int[3];
        private bool[] arrIsEnd = new bool[3];
        private int[] arrCounter_Transport = new int[3];
        private int[] arrCounter_To = new int[3];

        private AutoResetEvent[] arrAutoResetEvent_1 = new AutoResetEvent[3], arrAutoResetEvent_2 = new AutoResetEvent[3];

        public Form1()
        {
            InitializeComponent();

            arrUC_From[0] = new UserControl1(N, "Full", "Button");
            arrUC_From[1] = new UserControl1(N, "Full", "Label");
            for (int i = 0; i < 2; i++)
            {
                arrUC_From[i].Location = new Point(2, 40 + 55 * i);
                this.Controls.Add(arrUC_From[i]);
            }
            for (int i = 0; i < 3; i++)
            {
                arrUC_Transport[i] = new UserControl1(5, "Empty", "");
                arrUC_Transport[i].Location = new Point(2 + 135 * i, 155);
                this.Controls.Add(arrUC_Transport[i]);

                arrUC_To[i] = new UserControl1(N, "Empty", "");
                arrUC_To[i].Location = new Point(2, 215 + 55 * i);
                this.Controls.Add(arrUC_To[i]);

                arrAutoResetEvent_1[i] = new AutoResetEvent(false);
                arrAutoResetEvent_2[i] = new AutoResetEvent(false);
            }
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                arr_toTransport[i] = new Thread(toTransport_Function);
                arr_fromTransport[i] = new Thread(fromTransport_Function);

                arr_toTransport[i].Start(i);
                arr_fromTransport[i].Start(i);
            }
        }

        void toTransport_Function(object o)
        {
            int indexColor = (int)o;
            for (int k = 0; k < 2; k++)
            {
                for (int i = 0; i < N; i++)
                {
                    Control temp = arrUC_From[k].arrControls[i];
                    if (temp == null)
                        continue;

                    if (indexColor == 0 && temp.BackColor.R != 0
                            ||
                        indexColor == 1 && temp.BackColor.G != 0
                            ||
                        indexColor == 2 && temp.BackColor.B != 0)
                    {
                        this.Invoke(new myAddDelegate(add), arrUC_Transport[indexColor], arrCounter_Transport[indexColor], arrUC_From[k], i);
                        this.Invoke(new myRemoveDelegate(remove), arrUC_From[k], i);
                        arrCounter_Transport[indexColor]++;
                        Thread.Sleep(100);
                        Console.WriteLine(arrCounter_Transport[indexColor]);
                        if (arrCounter_Transport[indexColor] == 5)
                        {
                            arrAutoResetEvent_1[indexColor].Set();
                            arrAutoResetEvent_2[indexColor].WaitOne();
                        }
                    }
                }
                arrFlag_ButtonLabel[indexColor]++;
                if (arrFlag_ButtonLabel[indexColor] == 2)
                    break;
            }

            arrAutoResetEvent_1[indexColor].Set();
            arrIsEnd[indexColor] = true;
        }

        void fromTransport_Function(object o)
        {
            int indexColor = (int)o;
            while (true)
            {
                arrAutoResetEvent_1[indexColor].WaitOne();
                for (int i = 0; i < arrCounter_Transport[indexColor]; i++)
                {
                    this.Invoke(new myAddDelegate(add), arrUC_To[indexColor], arrCounter_To[indexColor], arrUC_Transport[indexColor], i);
                    this.Invoke(new myRemoveDelegate(remove), arrUC_Transport[indexColor], i);
                    Thread.Sleep(100);
                    arrCounter_To[indexColor]++;
                }
                if (arrIsEnd[indexColor] == false)
                {
                    arrCounter_Transport[indexColor] = 0;
                    arrAutoResetEvent_2[indexColor].Set();
                }
                else
                    break;
            }
        }

        private void add(UserControl1 UC_To, int counter_To, UserControl1 UC_From, int index_From)
        {
            UC_To.arrControls[counter_To] = UC_From.arrControls[index_From];
            UC_To.Controls.Add(UC_From.arrControls[index_From]);
            UC_To.arrControls[counter_To].Location = new Point(2 + 21 * counter_To, 3);
        }

        private void remove(UserControl1 UC, int index)
        {
            UC.Controls.Remove(UC.arrControls[index]);
            UC.arrControls[index] = null;
        }
    }
}
