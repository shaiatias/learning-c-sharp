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

namespace RGB_Transports_UserControls
{
    public delegate void addDelegate(int index, Color temp);
    public delegate void removeFromDelegate(int i);
    public delegate void remove_TransportDelegat(int index, int i);

    public partial class Form1 : Form
    {
        UserControl1 UC_From;
        UserControl1[] arrUC_Transport = new UserControl1[3], arrUC_To = new UserControl1[3];
        private const int N = 80, row = 2;
        private Color[] arrColors = new Color[] { Color.Red, Color.Green, Color.Blue };


        private Thread[] toTransport = new Thread[3], fromTransport = new Thread[3];
        private int[] arrCounter_To = new int [3], arrCounter_Transport = new int [3];
        private bool[] arrIsEnd = new bool [3];

        private AutoResetEvent[] arrAutoResetEvent_1 = new AutoResetEvent[3], arrAutoResetEvent_2 = new AutoResetEvent[3];

        public Form1()
        {
            InitializeComponent();

            UC_From = new UserControl1(N / 2, 2, "Full");
            UC_From.Location = new Point(2, 45);
            this.Controls.Add(UC_From);

            for (int i = 0; i < 3; i++)
            {
                arrUC_Transport [i]= new UserControl1(5, 1, "Empty");
                arrUC_Transport[i].Location = new Point(2 + 200 * i, 140);
                arrUC_Transport[i].BackColor = arrColors[i];
                this.Controls.Add(arrUC_Transport[i]);

                arrUC_To[i] = new UserControl1(N / 2, 1, "Empty");
                arrUC_To[i].Location = new Point(2, 213 + 40 * i);
                arrUC_To[i].BackColor = arrColors[i];
                this.Controls.Add(arrUC_To[i]);

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
                int minColor = 999;
                int minIndex = -1;
                for (int i = 0; i < N; i++)
                {
                    Label temp = UC_From.arrLabels[i];
                    if( temp.BackColor == Color.White)
                        continue;
                    if (index == 0 && temp.BackColor.R != 0 && temp.BackColor.R < minColor
                            ||
                        index == 1 && temp.BackColor.G != 0 && temp.BackColor.G < minColor
                            ||
                        index == 2 && temp.BackColor.B != 0 && temp.BackColor.B < minColor)
                    {
                        minColor = temp.BackColor.R + temp.BackColor.G  + temp.BackColor.B;
                        minIndex = i;
                    }
                }
                if (minIndex == -1)
                  break; 
                
                this.Invoke(new addDelegate(add_Transport), new object[] { index, UC_From.arrLabels[minIndex].BackColor });
                this.Invoke(new removeFromDelegate(remove_From), new object[] { minIndex });
                arrCounter_Transport[index] ++;
                Thread.Sleep(100);
                if (arrCounter_Transport[index]  == 5)
                {
                    arrAutoResetEvent_1[index].Set();
                    arrAutoResetEvent_2[index].WaitOne();
                }
            } 
            arrAutoResetEvent_1[index].Set();
            arrIsEnd[index] = true;
            
        }

        void fromTransport_Function(object o)
        {
            int index = (int)o;
            while (true)
            {
                arrAutoResetEvent_1[index].WaitOne();

                for (int i = 0; i < arrCounter_Transport[index]; i++)
                {
                    Label temp = arrUC_Transport[index].arrLabels[i];
                    this.Invoke(new addDelegate(add_To), new object[] { index, temp.BackColor });
                    arrCounter_To[index]++;
                    this.Invoke(new remove_TransportDelegat(remove_Transport), new object[] { index, i });
                    Thread.Sleep(100);
                }
                arrCounter_Transport[index] = 0;

                if (arrIsEnd[index] == false)
                    arrAutoResetEvent_2[index].Set();
                else
                    break;
            }
        }

        private void add_Transport(int index, Color temp)
        {
            arrUC_Transport[index].arrLabels[arrCounter_Transport[index]].BackColor = temp;
        }
        private void remove_From(int i)
        {
            UC_From.arrLabels[i].BackColor = Color.White;
        }
        private void add_To(int index, Color temp)
        {
            arrUC_To[index].arrLabels[arrCounter_To[index]].BackColor = temp;
        }
        private void remove_Transport(int index, int i)
        {
            arrUC_Transport[index].arrLabels[i].BackColor = Color.White;
        }
    }
}