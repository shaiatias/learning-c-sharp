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

namespace Color_White_ManagerForms_Event
{
    public partial class ManagerForms : Form
    {
        private int counterForms = 2;
        public Form1[] arrForm1;

        private int counterEvents = 0;
        private List<Control> button_List = new List<Control>(), label_List = new List<Control>();
        private Form1 first_Form, second_Form;
        private  myEventArgs first_EventArgs, second_EventArgs;

        public ManagerForms()
        {
            InitializeComponent();
            arrForm1 = new Form1[counterForms];
            for (int i = 0; i < counterForms; i++)
            {
                arrForm1[i] = new Form1();
                arrForm1[i].event_From_Form += new delegate_MyEventHadler(Manager_event_From_Form);

                arrForm1[i].Show();
            }

            arrForm1[0].Text = "Button";
            arrForm1[1].Text = "Label";

            this.FormBorderStyle = FormBorderStyle.None;
            this.TransparencyKey = SystemColors.Control;
            this.ShowInTaskbar = false;
        }
        private void Manager_event_From_Form(object sender, myEventArgs e)
        {
            counterEvents++;
            if (counterEvents == 1)
            {
                first_Form = (Form1)sender;
                first_EventArgs = e;
            }
            if (counterEvents == 2)
            {
                second_Form = (Form1)sender;
                second_EventArgs = e;
                MinMax_ButtonLabel();
            }

            if (counterEvents == 4)
                Sorting();
        }

        private void MinMax_ButtonLabel()
        {
            for (int i = 0; i < first_EventArgs.EventArg_UC_Small.arrControls.Length; i++)
            {
                Control temp = first_EventArgs.EventArg_UC_Small.arrControls[i];
                if (temp.GetType().Name == "Button")
                    button_List.Add(temp);
                else
                    label_List.Add(temp);
            }
            for (int i = 0; i < second_EventArgs.EventArg_UC_Small.arrControls.Length; i++)
            {
                Control temp = second_EventArgs.EventArg_UC_Small.arrControls[i];
                if (temp.GetType().Name == "Button")
                    button_List.Add(temp);
                else
                    label_List.Add(temp);
            }

            Control result_Control = null;

            if (first_EventArgs.ButtonLabel_str == "Button")
                result_Control = MinMax_Control(button_List, first_EventArgs.ColorWhite_str, first_EventArgs.MinMax_str);
            else
                result_Control = MinMax_Control(label_List, first_EventArgs.ColorWhite_str, first_EventArgs.MinMax_str);

            first_Form.MinMax_LabelButton.BackColor = result_Control.BackColor;
            first_Form.MinMax_LabelButton.Size = result_Control.Size;

            if (second_EventArgs.ButtonLabel_str == "Button")
                result_Control = MinMax_Control(button_List, second_EventArgs.ColorWhite_str, second_EventArgs.MinMax_str);
            else
                result_Control = MinMax_Control(label_List, second_EventArgs.ColorWhite_str, second_EventArgs.MinMax_str);

            second_Form.MinMax_LabelButton.BackColor = result_Control.BackColor;
            second_Form.MinMax_LabelButton.Size = result_Control.Size;
        }

        Control MinMax_Control(List<Control> tempList, string ColorWhite_str, string MinMax_str)
        {
            int minIndex = 0;
            for (int i = 1; i < tempList.Count; i++)
            {
                if ((ColorWhite_str == "White" && tempList[i].BackColor == Color.White
                    ||
                    ColorWhite_str != "White" && tempList[i].BackColor != Color.White)
                    &&
                    (MinMax_str == "Min" 
                    &&
                    tempList[i].Width * tempList[i].Height < tempList[minIndex].Width * tempList[minIndex].Height
                    ||
                    MinMax_str == "Max" 
                    &&
                    tempList[i].Width * tempList[i].Height > tempList[minIndex].Width * tempList[minIndex].Height))
                        minIndex = i;
            }
            return tempList[minIndex];
        }

        private void Sorting()
        {
            first_EventArgs.EventArg_UC_Small.Controls.Clear();
            second_EventArgs.EventArg_UC_Small.Controls.Clear();
            int[] buttonArrIndexes, labelArrIndexes;
            if (first_EventArgs.ButtonLabel_str == "Button")
            {
                buttonArrIndexes = arrIndex_newSequence(button_List, first_EventArgs.ColorWhite_str);
                Arrange(first_EventArgs.EventArg_UC_Small, button_List, buttonArrIndexes);

                labelArrIndexes = arrIndex_newSequence(label_List, second_EventArgs.ColorWhite_str);
                Arrange(second_EventArgs.EventArg_UC_Small, label_List, labelArrIndexes);
            }
            else
            {
                buttonArrIndexes = arrIndex_newSequence(button_List, second_EventArgs.ColorWhite_str);
                Arrange(second_EventArgs.EventArg_UC_Small, button_List, buttonArrIndexes);

                labelArrIndexes = arrIndex_newSequence(label_List, first_EventArgs.ColorWhite_str);
                Arrange(first_EventArgs.EventArg_UC_Small, label_List, labelArrIndexes);
            }
        }

        private int[] arrIndex_newSequence(List<Control> tempList, string ColorWhite_str)
        {
            Random myRand = new Random();
            SortedList mySortedList = new SortedList();
            for (int i = 0; i < tempList.Count; i++)
            {
                if (ColorWhite_str == "White" && tempList[i].BackColor == Color.White
                    ||
                    ColorWhite_str != "White" && tempList[i].BackColor != Color.White)
                    mySortedList.Add(tempList[i].Width + tempList[i].Height + myRand.Next(1000) * 0.00001, i);
            }

            int SortedList_Length = mySortedList.Count;
            int[] returnArr = new int[SortedList_Length];
            for (int i = 0; i < SortedList_Length; i++)
                returnArr[i] = (int)(mySortedList.GetByIndex(i));
            return returnArr;
        }

        void Arrange(UserControl_Small UC_Small, List<Control> myList, int[] arrIndexes)
        {
            int currPosition = 2;
            for (int i = 0; i < arrIndexes.Length; i++)
            {
                Control tempControl = myList[arrIndexes[i]];
                tempControl.Location = new Point(currPosition, 2);
                UC_Small.Controls.Add(tempControl);
                currPosition += tempControl.Width + 2;
            }
        }
    }
}
