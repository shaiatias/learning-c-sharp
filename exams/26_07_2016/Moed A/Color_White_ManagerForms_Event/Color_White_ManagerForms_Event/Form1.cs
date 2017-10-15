using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Color_White_ManagerForms_Event
{
    public partial class Form1 : Form
    {
        private UserControl_Large[] arrUC_Large = new UserControl_Large[2];
        public Control MinMax_LabelButton;

        public event delegate_MyEventHadler event_From_Form;

        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 2; i++)
            {
                arrUC_Large[i] = new UserControl_Large();
                arrUC_Large[i].Location = new Point(2, 48 + 105 * i);
                arrUC_Large[i].event_From_UC_Large += new delegate_MyEventHadler(Form_event_From_UC_Large);
                this.Controls.Add(arrUC_Large[i]);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void radioButtonMinMax_CheckedChanged(object sender, EventArgs e)
        {
            label_ButtonLabelMinMax.Text = this.Text + " " + ((RadioButton)sender).Text;
            if (this.Text == "Button")
                MinMax_LabelButton = new Button();
            else
                MinMax_LabelButton = new Label();
            MinMax_LabelButton.Size = new Size(30, 30);
            MinMax_LabelButton.BackColor = Color.LightGray;

            MinMax_LabelButton.Location = new Point(150, 2);
            this.Controls.Add(MinMax_LabelButton);
        }

        private void Form_event_From_UC_Large(object sender, myEventArgs e)
        {
            if (radioButtonMin.Checked)
                e.MinMax_str = "Min";
            if (radioButtonMax.Checked)
                e.MinMax_str = "Max";

            e.ButtonLabel_str = this.Text;

            if (event_From_Form != null)
                event_From_Form(this, e);
        }
    }
}
