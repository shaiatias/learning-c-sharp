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
        public event OnRowClickEvent rowClickEvent;
        public delegate void OnRowClickEvent(UserControl_Small small, UserControl_Large large, string color, Form1 form);

        private UserControl_Large[] arrUC_Large = new UserControl_Large[2];
        public Control MinMax_LabelButton;

        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 2; i++)
            {
                arrUC_Large[i] = new UserControl_Large();
                arrUC_Large[i].Location = new Point(2, 48 + 105 * i);
                this.Controls.Add(arrUC_Large[i]);

                arrUC_Large[i].rowClickEvent += new UserControl_Large.OnRowClickEvent((large, small, color) =>
                {
                    rowClickEvent?.Invoke(small, large, color, this);
                });
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

        public string getMinMax()
        {
            return label_ButtonLabelMinMax.Text.EndsWith("Min") ? "Min" : "Max";
        }

        public void setSelectedControl(Control preferred1)
        {
            MinMax_LabelButton.Size = preferred1.Size;
            MinMax_LabelButton.BackColor = preferred1.BackColor;
        }
    }
}
