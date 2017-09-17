using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace week3_q1
{
    public partial class PencilColumn : UserControl
    {
        public AutoResetEvent blueReset = new AutoResetEvent(true);
        public AutoResetEvent redReset = new AutoResetEvent(false);
        Thread turns;

        public PencilColumn(int columns)
        {
            InitializeComponent();

            turns = new Thread(StartThread);
            turns.Start();
        }

        public void resetColumns(int numOfPencils)
        {

        }

        public void paintPencils(int pencilsToPaint)
        {

        }

        public int getAvailablePencils()
        {
            return 0;
        }

        public int getXorResult()
        {
            return -1;
        }

        public void StartThread()
        {

            while (getAvailablePencils() > 0)
            {
                blueReset.WaitOne();

                // do blue step
                // calc xor value
                //this.xorResult = value;

                redReset.WaitOne();

                // do red step
                // calc xor value
                //this.xorResult = value -1 / > 0;
            }
        }

        static int calcXorValues(List<int> nums) {

            int initial = -1;
            bool temp = true;

            for (int i = 1; i < nums.Count; i++)
            {
                temp = nums[i - 1] == nums[i];

                if (!temp)
                {
                    if (nums[i] == -1) initial = nums[i - 1];
                    else initial = nums[i];

                    break;
                }
            }

            return initial;
        }
    }

    enum PencilColor
    {
        GREY,
        BLUE,
        RED
    }
}
