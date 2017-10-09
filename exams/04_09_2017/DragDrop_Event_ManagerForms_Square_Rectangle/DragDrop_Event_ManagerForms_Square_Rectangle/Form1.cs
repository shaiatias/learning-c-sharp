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
  
        private Control resultControl = null;

        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 2; i++)
            {
                arrUC[i] = new UserControl1(myRand);
                arrUC[i].Location = new Point(100, 27 + 85 * i);
                this.Controls.Add(arrUC[i]);

                arrUC[i].onDragDropEvent += new UserControl1.DragDropEvent(this.onUserControlDragDrop);
            }
        }

        private void onUserControlDragDrop(EventArgs args)
        {
            if (args is DragStartedEventArgs)
            {
                var arguments = (DragStartedEventArgs) args;
                arguments.formSender = this;
                this.DoDragDrop(arguments, DragDropEffects.All);
            }
            
            else if (args is DragCompletedEventArgs)
            {
                var arguments = (DragCompletedEventArgs)args;

                if (arguments.toForm == null)
                {
                    // happend to me
                    arguments.toForm = this;

                    if (arguments.toForm.Text == arguments.fromForm.Text)
                    {
                        Console.WriteLine("same form, will ignore");
                        return;
                    }

                    Control found = getPreferredControl((UserControl1)arguments.fromUc, (UserControl1)arguments.toUc, resultControl, label_MinMax, label_RedGreenBlue);

                    resultControl.Size = found.Size;
                    resultControl.BackColor = found.BackColor;

                    ((Form1) arguments.fromForm).onUserControlDragDrop(arguments);
                }

                else
                {
                    // redirected from the first form to the second
                    // i am the second
                    Control found = getPreferredControl((UserControl1)arguments.fromUc, (UserControl1)arguments.toUc, resultControl, label_MinMax, label_RedGreenBlue);

                    resultControl.Size = found.Size;
                    resultControl.BackColor = found.BackColor;
                }
            }
        }

        private Control getPreferredControl(UserControl1 fromUc, UserControl1 toUc, Control resultControl, Label label_MinMax, Label label_RedGreenBlue)
        {
            var combinedList = new List<Control>(fromUc.arrControls.Concat(toUc.arrControls));

            Control result = null;

            if (label_MinMax.Text == "Min")
            {
                result = combinedList
                    .Where(control =>
                        control.BackColor == Color.FromName(label_RedGreenBlue.Text) &&
                        control.GetType().Equals(resultControl.GetType()))
                    .OrderBy((c1) => c1.Width * c1.Height)
                    .First();
            }
            else
            {
                result = combinedList
                    .Where(control =>
                        control.BackColor == Color.FromName(label_RedGreenBlue.Text) &&
                        control.GetType().Equals(resultControl.GetType()))
                    .OrderByDescending((c1) => c1.Width * c1.Height)
                    .First();
            }

            return result;
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
