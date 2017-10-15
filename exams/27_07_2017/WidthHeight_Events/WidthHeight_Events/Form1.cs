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

namespace WidthHeight_Events
{
    public class MyEventArgs : EventArgs
    {
        public UserControl1 uc;
        public Form1 form;

        public MyEventArgs(UserControl1 uc, Form1 form) {
            this.uc = uc;
            this.form = form;
        }
    }

    public delegate void MyEventHandler(object sender, MyEventArgs args);

    public partial class Form1 : Form
    {
        private UserControl1[] arrUserControl;
        private int arrUser_size = 2;

        public Form1(int counter)
        {
            InitializeComponent();
            if (counter == 1)
            {
                this.Text = "Button";
                labelMinMaxSize.Text = "MAX SIZE";
            }
            else
            {
                this.Text = "Label";
                labelMinMaxSize.Text = "MIN SIZE";
            }

            arrUserControl = new UserControl1[arrUser_size];
            for (int i = 0; i < arrUser_size; i++)
            {
                arrUserControl[i] = new UserControl1();
                arrUserControl[i].Location = new Point(58, 35 + 127 * i);

                arrUserControl[i].eventFromUc += new MyEventHandler((sender, args) =>
                {
                    this.Form1_eventFromUc(sender, new MyEventArgs(args.uc, this));
                });


                this.Controls.Add(arrUserControl[i]);
            }

            if (counter > 1)
            {
                Form1 temp = new Form1(counter - 1);
                temp.Show();
            }
        }

        static int counter = 0;
        static MyEventArgs click1, click2;
        static MyEventArgs sort1, sort2;

        private void Form1_eventFromUc(object sender, MyEventArgs args)
        {
            if (counter == 0)
            {
                click1 = args;
                counter++;
            }

            else if (counter == 1)
            {
                // skip if same
                if (click1.uc == args.uc) return;
                click2 = args;
                counter++;

                updateMinMax();
            }

            else if (counter == 2)
            {
                // skip if same
                sort1 = args;
                counter++;
            }

            else if (counter == 3)
            {
                // skip if same
                if (sort1.uc == args.uc) return;
                sort2 = args;
                counter = 0;

                sortObjects();
            }
        }

        static List<Control> buttonsList;
        static List<Control> labelsList;
        
        private void updateMinMax()
        {
            Form1 buttonsForm = click1.form.Text == "Button" ? click1.form : click2.form;
            Form1 labelsForm = click1.form.Text == "Button" ? click2.form : click1.form;

            buttonsList = (from item in click1.uc.arrControls.Concat(click2.uc.arrControls)
                               where item.GetType().Name == "Button"
                               orderby item.Size.Height * item.Size.Width
                               where (
                                (buttonsForm.checkBoxBlue.Checked && item.BackColor.B != 0) ||
                                (buttonsForm.checkBoxRed.Checked && item.BackColor.R != 0) ||
                                (buttonsForm.checkBoxGreen.Checked && item.BackColor.G != 0)
                               )
                               select item)
                              .ToList();

            labelsList = (from item in click1.uc.arrControls.Concat(click2.uc.arrControls)
                              where item.GetType().Name == "Label"
                              where (
                                (labelsForm.checkBoxBlue.Checked && item.BackColor.B != 0) ||
                                (labelsForm.checkBoxRed.Checked && item.BackColor.R != 0) ||
                                (labelsForm.checkBoxGreen.Checked && item.BackColor.G != 0)
                              )
                              orderby item.Size.Height * item.Size.Width
                              select item)
                             .ToList();

            buttonsForm.updateMinMaxUI((buttonsForm.labelMinMaxSize.Text.ToLower().StartsWith("min") ? buttonsList.First() : buttonsList.Last()));
            labelsForm.updateMinMaxUI((labelsForm.labelMinMaxSize.Text.ToLower().StartsWith("min")) ? labelsList.First() : labelsList.Last());
        }

        private void updateMinMaxUI(Control control)
        {
            this.labelHeight.Text = control.Size.Height.ToString();
            this.labelWidth.Text = control.Size.Width.ToString();
        }

        private void sortObjects()
        {
            var buttonsArgs = click1.form.Text == "Button" ? click1 : click2;
            var labelsArgs = click1.form.Text == "Button" ? click2 : click1;

            buttonsArgs.uc.paintNewControls(buttonsList);
            labelsArgs.uc.paintNewControls(labelsList);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
