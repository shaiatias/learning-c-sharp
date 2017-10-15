using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace DragDrop_Event_Mdi_Square_Rectangle
{
    public partial class Child : Form
    {
        public UserControl1[] arrUC = new UserControl1[2];

        public Control Max_RectangleSquare_control = null;
        static Random myRand = new Random();

        private UserControl1 UC_1, UC_2;
        private string ButtonLabel_1, ButtonLabel_2;
        private string RectangleSquare_1, RectangleSquare_2;
        private string Color_1, Color_2;
        private Control Max_RectangleSquare_control_1, Max_RectangleSquare_control_2;

        private List<Control> button_List = new List<Control>(), label_List = new List<Control>();
        private int DragDropCounter = 0;

        public Child()
        {
            InitializeComponent();
            for (int i = 0; i < 2; i++)
            {
                arrUC[i] = new UserControl1(myRand);
                arrUC[i].Location = new Point(100, 27 + 85 * i);
                arrUC[i].event_FromUC += new delegate_MyEventHadler(Child_event_FromUC);
                this.Controls.Add(arrUC[i]);
            }
            if (myRand.Next(2) == 0)
                Max_RectangleSquare.Text += "Rectangle";
            else
                Max_RectangleSquare.Text += "Square";
        }
        private void Child_event_FromUC(object sender, myEventArgs e)
        {
            if (e.EventArgs_UC_2 == null)
            {
                dragClass myDragClass = new dragClass();
                myDragClass.Drag_UC_1 = e.EventArgs_UC_1;
                myDragClass.Drag_Child_1 = this;

                this.DoDragDrop(myDragClass, DragDropEffects.All);
            }
            else
            {
                DragDropCounter++;

                if (DragDropCounter == 1)
                {
                    UC_1 = e.EventArgs_UC_1;
                    ButtonLabel_1 = e.EventArgs_Child_1.Text;
                    RectangleSquare_1 = e.EventArgs_Child_1.Max_RectangleSquare.Text;
                    if (e.EventArgs_Child_1.radioButtonRed.Checked)
                        Color_1 = "Red";
                    if (e.EventArgs_Child_1.radioButtonGreen.Checked)
                        Color_1 = "Green";
                    if (e.EventArgs_Child_1.radioButtonBlue.Checked)
                        Color_1 = "Blue";
                    Max_RectangleSquare_control_1 = e.EventArgs_Child_1.Max_RectangleSquare_control;

                    UC_2 = e.EventArgs_UC_2;
                    ButtonLabel_2 = this.Text;
                    RectangleSquare_2 = this.Max_RectangleSquare.Text;
                    if (this.radioButtonRed.Checked)
                        Color_2 = "Red";
                    if (this.radioButtonGreen.Checked)
                        Color_2 = "Green";
                    if (this.radioButtonBlue.Checked)
                        Color_2 = "Blue";
                    Max_RectangleSquare_control_2 = this.Max_RectangleSquare_control;

                    Action_Max_RectangleSquare();
                }
                else
                    ActionSort();
            }
        }

        void Action_Max_RectangleSquare()
        {
            for (int i = 0; i < UC_1.arrControls.Length; i++)
            {
                Control temp = UC_1.arrControls[i];
                if (temp.GetType().Name == "Button")
                    button_List.Add(temp);
                else
                    label_List.Add(temp);
            }
            for (int i = 0; i < UC_2.arrControls.Length; i++)
            {
                Control temp = UC_2.arrControls[i];
                if (temp.GetType().Name == "Button")
                    button_List.Add(temp);
                else
                    label_List.Add(temp);
            }
            Control maxControl;
            if( ButtonLabel_1 == "Button")
            {
                button_List = Filter_RectangleSquare_Color(button_List, RectangleSquare_1, Color_1);
                maxControl = Max_Size_Control(button_List);
                Max_RectangleSquare_control_1.BackColor = maxControl.BackColor;
                Max_RectangleSquare_control_1.Size = maxControl.Size;

                label_List = Filter_RectangleSquare_Color(label_List, RectangleSquare_2, Color_2);
                maxControl = Max_Size_Control(label_List);
                Max_RectangleSquare_control_2.BackColor = maxControl.BackColor;
                Max_RectangleSquare_control_2.Size = maxControl.Size;
            }
            else
            {
                button_List = Filter_RectangleSquare_Color(button_List, RectangleSquare_2, Color_2);
                maxControl = Max_Size_Control(button_List);
                Max_RectangleSquare_control_2.BackColor = maxControl.BackColor;
                Max_RectangleSquare_control_2.Size = maxControl.Size;

                label_List = Filter_RectangleSquare_Color(label_List, RectangleSquare_1, Color_1);
                maxControl = Max_Size_Control(label_List);
                Max_RectangleSquare_control_1.BackColor = maxControl.BackColor;
                Max_RectangleSquare_control_1.Size = maxControl.Size;
            }
        }

        List<Control> Filter_RectangleSquare_Color(List<Control> tempList, string RectangleSquare_str, string Color_str)
        {
            List<Control> return_List = new List<Control>();
            for (int i = 1; i < tempList.Count; i++)
            {
                if (tempList[i].BackColor.Name == Color_str
                    &&
                    (RectangleSquare_str == "Max Rectangle" && tempList[i].Width != tempList[i].Height
                    ||
                    RectangleSquare_str == "Max Square" && tempList[i].Width == tempList[i].Height ))
                return_List.Add(tempList[i]);
            }
            return return_List;
        }

        Control Max_Size_Control(List<Control> tempList)
        {
            int maxIndex = 0;
            for (int i = 1; i < tempList.Count; i++)
                if (tempList[i].Width * tempList[i].Height > tempList[maxIndex].Width * tempList[maxIndex].Height)
                    maxIndex = i;

            return tempList[maxIndex];
        }

        private void ActionSort()
        {
            UC_1.Controls.Clear();
            UC_2.Controls.Clear();

            int[] buttonArrIndexes, labelArrIndexes;
            if (ButtonLabel_1 == "Button")
            {
                buttonArrIndexes = arrIndex_newSequence(button_List);
                Arrange(UC_1, button_List, buttonArrIndexes);

                labelArrIndexes = arrIndex_newSequence(label_List);
                Arrange(UC_2, label_List, labelArrIndexes);
            }
            else
            {
                buttonArrIndexes = arrIndex_newSequence(button_List);
                Arrange(UC_2, button_List, buttonArrIndexes);

                labelArrIndexes = arrIndex_newSequence(label_List);
                Arrange(UC_1, label_List, labelArrIndexes);
            }
        }

        private int[] arrIndex_newSequence(List<Control> tempList)
        {
            Random myRand = new Random();
            SortedList mySortedList = new SortedList();
            for (int i = 0; i < tempList.Count; i++)
                mySortedList.Add(tempList[i].Width + tempList[i].Height + myRand.Next(1000) * 0.00001, i);

            int SortedList_Length = mySortedList.Count;
            int[] returnArr = new int[SortedList_Length];
            for (int i = 0; i < SortedList_Length; i++)
                returnArr[i] = (int)(mySortedList.GetByIndex(i));
            return returnArr;
        }

        void Arrange(UserControl1 tempUC, List<Control> myList, int[] arrIndexes)
        {
            int currPosition = 2;
            for (int i = 0; i < arrIndexes.Length; i++)
            {
                Control tempControl = myList[arrIndexes[i]];
                tempControl.Location = new Point(currPosition, 2);
                tempUC.Controls.Add(tempControl);
                currPosition += tempControl.Width + 2;
            }
        }
    }
}
