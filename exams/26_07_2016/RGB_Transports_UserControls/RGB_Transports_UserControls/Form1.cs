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
    public partial class Form1 : Form
    {
        UserControl1 UC_From;
        UserControl1[] arrUC_Transport = new UserControl1[3], arrUC_To = new UserControl1[3];
        private const int N = 80, row = 2;
        private Color[] arrColors = new Color[] { Color.Red, Color.Green, Color.Blue };

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

            }
        }

        private Thread[]
            arr_toTransport = new Thread[3],
            arr_fromTransport = new Thread[3];

        private Dictionary<UserControl1, int> itemsInControl = new Dictionary<UserControl1, int>();

        private bool started = false;

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (started) return;
            started = true;

            arr_toTransport[0] = new Thread(moveToTransport);
            arr_fromTransport[0] = new Thread(moveFromTransport);

            arr_toTransport[1] = new Thread(moveToTransport);
            arr_fromTransport[1] = new Thread(moveFromTransport);

            arr_toTransport[2] = new Thread(moveToTransport);
            arr_fromTransport[2] = new Thread(moveFromTransport);

            arr_toTransport[0].Start(0);
            arr_fromTransport[0].Start(0);

            arr_toTransport[1].Start(1);
            arr_fromTransport[1].Start(1);

            arr_toTransport[2].Start(2);
            arr_fromTransport[2].Start(2);
        }

        public delegate void addItemFromUC(UserControl1 toUc, int toIndex, UserControl1 fromUc, int fromIndex);
        public delegate void removeItemFromUC(UserControl1 uc, int index);

        private AutoResetEvent[] arrAutoResetEvent_1 = new AutoResetEvent[] { new AutoResetEvent(false), new AutoResetEvent(false), new AutoResetEvent(false) };
        private AutoResetEvent[] arrAutoResetEvent_2 = new AutoResetEvent[] { new AutoResetEvent(false), new AutoResetEvent(false), new AutoResetEvent(false) };

        private bool[] didFinish = new bool[] { false, false, false };

        private int[] arrCounter_To = new int[3] { 0, 0, 0 };
        private int[] arrCounter_Transport = new int[3] { 0, 0, 0 };

        private void moveFromTransport(object id)
        {
            int colorId = (int)id;

            int TRANSPORT_CAPACITY = 4;

            var combined = UC_From.arrLabels.Select((value, i) => new { value, i });
            combined = combined.OrderBy(item => item.value.BackColor.GetBrightness());

            foreach (var item in combined)
            {
                // ignore in null
                if (item.value == null) continue;

                // ignore if not the same color
                if (!isSameColorAsThread(colorId, item.value)) continue;

                this.Invoke(new addItemFromUC(addItem), arrUC_Transport[colorId], arrCounter_Transport[colorId], UC_From, item.i);
                this.Invoke(new removeItemFromUC(removeItem), UC_From, item.i);

                arrCounter_Transport[colorId]++;

                Thread.Sleep(100);

                if (arrCounter_Transport[colorId] == TRANSPORT_CAPACITY)
                {
                    arrAutoResetEvent_1[colorId].Set();
                    arrAutoResetEvent_2[colorId].WaitOne();
                }
            }

            arrAutoResetEvent_1[colorId].Set();
            arrAutoResetEvent_2[colorId].WaitOne();

            didFinish[colorId] = true;
        }

        private void moveToTransport(object id)
        {
            int colorId = (int)id;

            while (true)
            {
                arrAutoResetEvent_1[colorId].WaitOne();

                var count = arrCounter_Transport[colorId];

                //for (int i = 0; i < 4; i++)
                //{

                foreach (var item in arrUC_Transport[colorId].arrLabels)
                {
                    // skip nulls
                    if (item == null) continue;

                    // skip whites
                    if (item.BackColor == Color.White) continue;

                    this.Invoke(new addItemFromUC(addItem), arrUC_To[colorId], arrCounter_To[colorId], arrUC_Transport[colorId], arrCounter_Transport[colorId]);
                    arrCounter_To[colorId]++;

                    this.Invoke(new removeItemFromUC(removeItem), arrUC_Transport[colorId], arrCounter_Transport[colorId]);
                    arrCounter_Transport[colorId]--;


                    Thread.Sleep(100);
                }

                arrCounter_Transport[colorId] = 0;

                if (didFinish[colorId])
                {
                    break;
                }

                arrAutoResetEvent_2[colorId].Set();
            }
        }

        static private bool isSameColorAsThread(int threadId, Control c)
        {
            // red
            if (threadId == 0) return c.BackColor.R > 0;

            // green
            if (threadId == 1) return c.BackColor.G > 0;

            // blue
            if (threadId == 2) return c.BackColor.B > 0;

            return false;
        }

        private void addItem(UserControl1 toUc, int toIndex, UserControl1 fromUc, int fromIndex)
        {
            toUc.arrLabels[toIndex].BackColor = fromUc.arrLabels[fromIndex].BackColor;
        }

        private void removeItem(UserControl1 uc, int index)
        {
            uc.arrLabels[index].BackColor = Color.White;
        }
    }
}