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
using System.Collections;

namespace Client
{
    public partial class Form1 : Form
    {
        private Control[] arrControls;
        private ICommon myICommon;
        private Control[] arrControls_result = null;

        public Form1()
        {
            InitializeComponent();

            Random myRand = new Random();
            int arrSize = myRand.Next(5, 10);

            int currPosition = 2;
            arrControls = new Control[arrSize];

            Color myColor = Color.FromArgb(myRand.Next(100, 256), myRand.Next(100, 256), myRand.Next(100, 256));
            for (int i = 0; i < arrSize; i++)
            {
                if(myRand.Next(2) == 0)
                    arrControls[i] = new Button();
                else
                    arrControls[i] = new Label();
                arrControls[i].BackColor = myColor;

                int tempXY = myRand.Next(20, 40);
                switch (myRand.Next(4))
                {
                    case 0:
                    case 1: arrControls[i].Size = new Size(tempXY, tempXY); break;
                    case 2: arrControls[i].Size = new Size(tempXY * 2, tempXY); break;
                    case 3: arrControls[i].Size = new Size(tempXY, tempXY * 2); break;
                }

                arrControls[i].Location = new Point(currPosition, 3);
                currPosition += arrControls[i].Size.Width + 2;
                this.Controls.Add(arrControls[i]);
            }

            HttpChannel channel = new HttpChannel();
            ChannelServices.RegisterChannel(channel, false);

            myICommon = (ICommon)Activator.GetObject(
                typeof(ICommon),
                "http://localhost:1234/_Server_");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MControl[] cons = arrControls
                    .Select(c => new MControl(c.GetType().Name, c.Size, c.BackColor))
                    .ToArray();
                    
            myICommon.addControls(cons);
        }

        private bool isSquares = true;

        private int getItemCount()
        {
            return arrControls_result == null ? 0 : arrControls_result.Length;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            paintSortedList(myICommon.refresh(isSquares, getItemCount()));
        }

        private void paintSortedList(SortedList sortedList)
        {
            // skip if no changes in model
            if (sortedList == null) return;

            // clean
            removeAllItemsInResult();

            // offset for paint
            int paintOffset = 0;

            // repaint state
            int itemsAdded = 0;

            arrControls_result = new Control[sortedList.Count];

            foreach (DictionaryEntry item in sortedList)
            {
                //if (!(item is MControl)) continue;

                MControl control = (MControl) item.Value;

                /////////////////////

                if (control.className.Equals("Button"))
                    arrControls_result[itemsAdded] = new Button();
                else
                    arrControls_result[itemsAdded] = new Label();

                arrControls_result[itemsAdded].BackColor = control.backColor;
                arrControls_result[itemsAdded].Size = control.size;
                arrControls_result[itemsAdded].Location = new Point(paintOffset, 100);

                paintOffset += arrControls_result[itemsAdded].Size.Width + 2;

                this.Controls.Add(arrControls_result[itemsAdded]);

                itemsAdded++;

                /////////////////////
            }
        }

        private void removeAllItemsInResult()
        {
            if (arrControls_result == null) return;

            for (int i = 0; i < arrControls_result.Length; i++)
            {
                if (arrControls_result[i] == null) continue;

                Controls.Remove(arrControls_result[i]);

                arrControls_result[i] = null;
            }

            arrControls_result = null;
        }

        private void radioButtonSquareRectangle_CheckedChanged(object sender, EventArgs e)
        {
            // update model
            this.isSquares = ((Control)sender).Text == "all Squares";

            // repaint ui
            paintSortedList(myICommon.refresh(isSquares, getItemCount()));
        }
    }
}

