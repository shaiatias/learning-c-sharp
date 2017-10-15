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

namespace DragDrop_Event_ManagerForms_Square_Rectangle
{
    public partial class Form1 : Form
    {
        public UserControl1[] arrUC = new UserControl1[2];

        public Control Max_RectangleSquare_control = null;
        static Random myRand = new Random();

        private UserControl1 UC_1, UC_2;
        private string RectangleSquare_1, RectangleSquare_2;
        private string ButtonLabel_1, ButtonLabel_2;
        private string RedGreenBlue_1, RedGreenBlue_2;
        private string MinMax_1, MinMax_2;
   
        private Control resultControl = null;
        private Control resultControl_1, resultControl_2;


        private List<Control> Rectangle_List = new List<Control>(), Square_List = new List<Control>();
        private int DragDropCounter = 0;

        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 2; i++)
            {
                arrUC[i] = new UserControl1(myRand);
                arrUC[i].Location = new Point(100, 27 + 85 * i);
                arrUC[i].event_FromUC += new delegate_MyEventHadler(Form_event_FromUC);
                this.Controls.Add(arrUC[i]);
            }
        }
        private void Form_event_FromUC(object sender, myEventArgs e)
        {
            if (e.EventArgs_UC_2 == null)
            {
                dragClass myDragClass = new dragClass();
                myDragClass.Drag_UC_1 = e.EventArgs_UC_1;
                myDragClass.Drag_Form_1 = this;

                this.DoDragDrop(myDragClass, DragDropEffects.All);
            }
            else
            {
                DragDropCounter++;

                if (DragDropCounter == 1)
                {
                    UC_1 = e.EventArgs_UC_1;
                    RectangleSquare_1 = e.EventArgs_Form_1.Text;
                    MinMax_1 = e.EventArgs_Form_1.label_MinMax.Text;
                    RedGreenBlue_1 = e.EventArgs_Form_1.label_RedGreenBlue.Text;
                    if (e.EventArgs_Form_1.radioButton_Label.Checked)
                        ButtonLabel_1 = "Label";
                    if (e.EventArgs_Form_1.radioButton_Button.Checked)
                        ButtonLabel_1 = "Button";

                    resultControl_1 = e.EventArgs_Form_1.resultControl;

                    UC_2 = e.EventArgs_UC_2;
                    RectangleSquare_2 = this.Text;
                    MinMax_2 = this.label_MinMax.Text;
                    RedGreenBlue_2 = this.label_RedGreenBlue.Text;
                    if (this.radioButton_Label.Checked)
                        ButtonLabel_2 = "Label";
                    if (this.radioButton_Button.Checked)
                        ButtonLabel_2 = "Button";
                    resultControl_2 = this.resultControl;

                    Action_resultControl();
                }
                else
                    ActionSort();
            }
       }

        void Action_resultControl()
        {
            for (int i = 0; i < UC_1.arrControls.Length; i++)
            {
                Control temp = UC_1.arrControls[i];
                if (temp.Width != temp.Height)
                    Rectangle_List.Add(temp);
                else
                    Square_List.Add(temp);
            }
            for (int i = 0; i < UC_2.arrControls.Length; i++)
            {
                Control temp = UC_2.arrControls[i];
                if (temp.Width != temp.Height)
                    Rectangle_List.Add(temp);
                else
                    Square_List.Add(temp);
            }

            Control tempControl = null;
            if( RectangleSquare_1 == "Rectangle")
            {
                Rectangle_List = Filter_ButtonLabel_RedGreenBlue(Rectangle_List, ButtonLabel_1, RedGreenBlue_1);
                if(MinMax_1 =="Max")
                    tempControl = Max_Control(Rectangle_List);
                else
                    tempControl = Min_Control(Rectangle_List);

                resultControl_1.BackColor = tempControl.BackColor;
                resultControl_1.Size = tempControl.Size;

                Square_List = Filter_ButtonLabel_RedGreenBlue(Square_List, ButtonLabel_2, RedGreenBlue_2);
                if(MinMax_2 =="Max")
                    tempControl = Max_Control(Square_List);
                else
                    tempControl = Min_Control(Square_List);
                resultControl_2.BackColor = tempControl.BackColor;
                resultControl_2.Size = tempControl.Size;
            }
            else
            {
                Square_List = Filter_ButtonLabel_RedGreenBlue(Square_List, ButtonLabel_1, RedGreenBlue_1);
                if(MinMax_1 =="Max")
                    tempControl = Max_Control(Square_List);
                else
                    tempControl = Min_Control(Square_List);
                resultControl_1.BackColor = tempControl.BackColor;
                resultControl_1.Size = tempControl.Size;

                Rectangle_List = Filter_ButtonLabel_RedGreenBlue(Rectangle_List, ButtonLabel_2, RedGreenBlue_2);
                if(MinMax_2 =="Max")
                    tempControl = Max_Control(Rectangle_List);
                else
                    tempControl = Min_Control(Rectangle_List);

                resultControl_2.BackColor = tempControl.BackColor;
                resultControl_2.Size = tempControl.Size;
            }
        }

        List<Control> Filter_ButtonLabel_RedGreenBlue(List<Control> tempList, string ButtonLabel_str, string RedGreenBlue_str)
        {
            List<Control> return_List = new List<Control>();
            for (int i = 1; i < tempList.Count; i++)
            {
                if (tempList[i].BackColor.Name == RedGreenBlue_str
                    &&
                    tempList[i].GetType().Name == ButtonLabel_str)
                return_List.Add(tempList[i]);
            }
            return return_List;
        }

        Control Max_Control(List<Control> tempList)
        {
            int maxIndex = 0;
            for (int i = 1; i < tempList.Count; i++)
                if (tempList[i].Width * tempList[i].Height > tempList[maxIndex].Width * tempList[maxIndex].Height)
                    maxIndex = i;
            return tempList[maxIndex];
        }
        Control Min_Control(List<Control> tempList)
        {
            int minIndex = 0;
            for (int i = 1; i < tempList.Count; i++)
                if (tempList[i].Width * tempList[i].Height < tempList[minIndex].Width * tempList[minIndex].Height)
                    minIndex = i;
            return tempList[minIndex];
        }

        private void ActionSort()
        {
            Rectangle_List.Sort((x, y) => x.Width * x.Height - y.Width * y.Height);
            Square_List.Sort((x, y) => x.Width * x.Height - y.Width * y.Height);

            if (RectangleSquare_1 == "Rectangle")
            {
                Arrange(UC_1, Rectangle_List);
                Arrange(UC_2, Square_List);
            }
            else
            {
                Arrange(UC_1, Square_List);
                Arrange(UC_2, Rectangle_List);
            }
        }

        void Arrange(UserControl1 UC, List<Control> tempList)
        {
            UC.Controls.Clear();
            int currPosition = 2;
            for (int i = 0; i < tempList.Count; i++)
            {
                Control tempControl = tempList[i];
                tempControl.Location = new Point(currPosition, 2);
                UC.Controls.Add(tempControl);
                currPosition += tempControl.Width + 2;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(resultControl != null)
                this.Controls.Remove(resultControl);
            if( ((Control)sender).Text == "Button")
                resultControl = new Button();
            else
                resultControl = new Label();

            resultControl.BackColor = Color.White;
            resultControl.Location = new Point(2, 62);
            resultControl.Size = new Size(30, 30);
            this.Controls.Add(resultControl);
        }
    }
}
