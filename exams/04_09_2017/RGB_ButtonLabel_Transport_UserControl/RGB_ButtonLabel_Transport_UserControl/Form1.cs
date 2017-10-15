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
    public partial class Form1 : Form
    {
        private UserControl1[] 
            arrUC_From = new UserControl1[2],
            arrUC_To = new UserControl1[3], 
            arrUC_Transport = new UserControl1[3];

        private const int N = 55;

        private Color[] arrColors = new Color[] { Color.Red, Color.Green, Color.Blue };

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
            }

            itemsInControl.Add(arrUC_From[0], N);
            itemsInControl.Add(arrUC_From[1], N);
            itemsInControl.Add(arrUC_Transport[0], 0);
            itemsInControl.Add(arrUC_Transport[1], 0);
            itemsInControl.Add(arrUC_Transport[2], 0);
            itemsInControl.Add(arrUC_To[0], 0);
            itemsInControl.Add(arrUC_To[1], 0);
            itemsInControl.Add(arrUC_To[2], 0);
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

        private AutoResetEvent[] arrAutoResetEvent_1 = new AutoResetEvent[] { new AutoResetEvent(false) , new AutoResetEvent(false) , new AutoResetEvent(false)};
        private AutoResetEvent[] arrAutoResetEvent_2 = new AutoResetEvent[] { new AutoResetEvent(false), new AutoResetEvent(false), new AutoResetEvent(false) };

        private bool[] didFinish = new bool[] { false, false, false };

        private void moveFromTransport(object id)
        {
            int colorId = (int)id;

            int added = 0;
            int TRANSPORT_CAPACITY = 5;

            var combined = arrUC_From[0].arrControls.Select((value, i) => new { value, i, from = arrUC_From[0] });
            combined = combined.Concat(arrUC_From[1].arrControls.Select((value, i) => new { value, i, from = arrUC_From[1] }));

            foreach (var item in combined)
            {
                // ignore in null
                if (item.value == null) continue;

                // ignore if not the same color
                if (!isSameColorAsThread(colorId, item.value)) continue;

                this.Invoke(new addItemFromUC(addItem) , arrUC_Transport[colorId], 1, item.from, item.i);
                this.Invoke(new removeItemFromUC(removeItem), item.from, item.i);
                added++;

                Thread.Sleep(100);

                if (added > TRANSPORT_CAPACITY)
                {
                    arrAutoResetEvent_1[colorId].Set();
                    arrAutoResetEvent_2[colorId].WaitOne();

                    // reset after empty
                    added = 0;
                }
            }

            didFinish[colorId] = true;
        }

        private void moveToTransport(object id) 
        {
            int colorId = (int)id;

            while (true)
            {
                arrAutoResetEvent_1[colorId].WaitOne();

                foreach (var item in arrUC_Transport[colorId].arrControls.Select((value, i) => new { value, i }))
                {
                    if (item.value == null) continue;

                    this.Invoke(new addItemFromUC(addItem), arrUC_To[colorId], 1, arrUC_Transport[colorId], item.i);
                    this.Invoke(new removeItemFromUC(removeItem), arrUC_Transport[colorId], item.i);

                    Thread.Sleep(500);
                }

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
            if (threadId == 0) return c.BackColor.R != 0;

            // green
            if (threadId == 1) return c.BackColor.G != 0;

            // blue
            if (threadId == 2) return c.BackColor.B != 0;

            return false;
        }

        private void addItem(UserControl1 toUc, int toIndex, UserControl1 fromUc, int fromIndex)
        {
            toUc.arrControls[toIndex] = fromUc.arrControls[fromIndex];
            toUc.Controls.Add(toUc.arrControls[toIndex]);

            toUc.arrControls[toIndex].Location = new Point(2 + 29 * itemsInControl[toUc], 3);

            itemsInControl[toUc]++;
        }

        private void removeItem(UserControl1 uc, int index)
        {
            uc.Controls.Remove(uc.arrControls[index]);
            uc.arrControls[index] = null;
            itemsInControl[uc]--;
        }
    }
}
