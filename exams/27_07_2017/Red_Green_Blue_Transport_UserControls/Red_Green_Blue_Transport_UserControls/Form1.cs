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

namespace Red_Green_Blue_Transport_UserControls
{
    public partial class Form1 : Form
    {
        private UserControl1[] arrUC_From = new UserControl1[3],
            arrUC_To = new UserControl1[3], arrUC_Transport = new UserControl1[3];
        private const int N = 52;
        private Color[] arrColors = new Color[] { Color.Red, Color.Green, Color.Blue };
        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < 3; i++)
            {
                arrUC_From[i] = new UserControl1(N, "Full", i);
                arrUC_From[i].Location = new Point(2, 40 + 55 * i);
                this.Controls.Add(arrUC_From[i]);

                arrUC_Transport[i] = new UserControl1(5, "Empty", 0);
                arrUC_Transport[i].Location = new Point(2 + 135 * i, 210);
                this.Controls.Add(arrUC_Transport[i]);

                arrUC_To[i] = new UserControl1(N, "Empty", 0);
                arrUC_To[i].Location = new Point(2, 270 + 55 * i);
                this.Controls.Add(arrUC_To[i]);
            }
        }

        private Thread[]
            arr_toTransport = new Thread[3],
            arr_fromTransport = new Thread[3];

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

        public delegate void addItemFromUC(UserControl1 toUc, int toIndex, Color color);
        public delegate void removeItemFromUC(UserControl1 uc, int index);

        private AutoResetEvent[] arrAutoResetEvent_1 = new AutoResetEvent[] { new AutoResetEvent(false), new AutoResetEvent(false), new AutoResetEvent(false) };
        private AutoResetEvent[] arrAutoResetEvent_2 = new AutoResetEvent[] { new AutoResetEvent(false), new AutoResetEvent(false), new AutoResetEvent(false) };

        private bool[] didFinish = new bool[] { false, false, false };

        private int[] arrCounter_To = new int[3] { 0, 0, 0 };
        private int[] arrCounter_Transport = new int[3] { 0, 0, 0 };

        private void moveFromTransport(object id)
        {
            int colorId = (int)id;
            int TRANSPORT_CAPACITY = 5;

            var list1 = arrUC_From[(colorId + 1) % 3];
            var list2 = arrUC_From[(colorId + 2) % 3];

            var arrLabels1 = ((UserControl1) list1).arrLabels; 
            var arrLabels2 = ((UserControl1) list2).arrLabels;

            var combined = arrLabels1
                .Select((value, i) => new { value, i, parent = (UserControl1) list1 })
                .Concat(arrLabels2.Select((value, i) => new { value, i, parent = (UserControl1) list2 }));

            foreach (var item in combined)
            {
                // ignore in null
                if (item.value == null) continue;

                // ignore white
                if (item.value.BackColor == Color.White) continue;

                // ignore if not the same color
                if (!isSameColorAsThread(colorId, item.value)) continue;

                this.Invoke(new addItemFromUC(addItem), arrUC_Transport[colorId], arrCounter_Transport[colorId], item.value.BackColor);
                this.Invoke(new removeItemFromUC(removeItem), item.parent, item.i);

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

                for (int i = 0; i < arrUC_Transport[colorId].arrLabels.Length; i++)
                {
                    var item = arrUC_Transport[colorId].arrLabels[i];
                    
                    // skip nulls
                    if (item == null) continue;

                    // skip whites
                    if (item.BackColor == Color.White) continue;

                    this.Invoke(new addItemFromUC(addItem), arrUC_To[colorId], arrCounter_To[colorId], item.BackColor);
                    arrCounter_To[colorId]++;

                    this.Invoke(new removeItemFromUC(removeItem), arrUC_Transport[colorId], i);
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

        private void addItem(UserControl1 toUc, int toIndex, Color color)
        {
            toUc.arrLabels[toIndex].BackColor = color;
        }

        private void removeItem(UserControl1 uc, int index)
        {
            uc.arrLabels[index].BackColor = Color.White;
        }
    }
}
