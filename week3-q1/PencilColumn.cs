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
        public AutoResetEvent blueReset = new AutoResetEvent(false);
        public AutoResetEvent redReset = new AutoResetEvent(false);
        Thread turns;

        List<PencilColor> pencils;
        int availablePencils;
        int lastXorResult;

        public PencilColumn(int pencils)
        {
            InitializeComponent();

            resetColumns(pencils);

            turns = new Thread(StartThread);
            turns.Start();
        }

        public void resetColumns(int numOfPencils)
        {
            availablePencils = numOfPencils;
            pencils = new List<PencilColor>(numOfPencils);

            for (int i = 0; i < numOfPencils; i++)
            {
                pencils.Add(PencilColor.GREY);
            }

            repaintPencils();
        }

        private void repaintPencils()
        {
            flowLayoutPanel1.Controls.Clear();

            foreach (PencilColor color in pencils)
            {
                PictureBox picture = new PictureBox()
                {
                    BackgroundImage = Properties.Resources.GrayPen
                };

                if (color == PencilColor.BLUE)
                {
                    picture.BackgroundImage = Properties.Resources.BluePen;
                }
                else if (color == PencilColor.RED)
                {
                    picture.BackgroundImage = Properties.Resources.RedPen;
                }

                flowLayoutPanel1.Controls.Add(picture);
            }
        }

        public void paintPencils(int pencilsToPaint, Player player)
        {
            int i = 0;

            for (i = 0; i < pencils.Count; i++)
            {
                if (pencils[i] == PencilColor.GREY)
                {
                    break;
                }
            }

            for (int j = 0; j < pencilsToPaint; j++)
            {
                pencils[i + j] = player == Player.BLUE ? PencilColor.BLUE : PencilColor.RED;
            }

            availablePencils = availablePencils - pencilsToPaint;
        }

        public int getAvailablePencils()
        {
            return availablePencils;
        }

        public int getXorResult()
        {
            return lastXorResult;
        }

        public void StartThread()
        {
            while (getAvailablePencils() > 0)
            {
                blueReset.WaitOne();

                // do blue step
                lastXorResult = calcXorValues();

                //Thread.Sleep(1000);

                //blueReset.Set();

                //Thread.Sleep(1000);

                //redReset.WaitOne();

                //// do red step
                //lastXorResult = calcXorValues();

                //Thread.Sleep(1000);

                redReset.Set();
            }
        }

        int calcXorValues()
        {
            return -1;
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

    public enum PencilColor
    {
        GREY,
        BLUE,
        RED
    }
}
