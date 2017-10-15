using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DragDrop_Event_ManagerForms_Square_Rectangle
{
    public partial class ManagerForms : Form
    {
        private Form1[] arrForms = new Form1[2];
        private Random rand_ManagerForms = new Random();

        public ManagerForms()
        {
            InitializeComponent();

            for (int i = 0; i < 2; i++)
            {
                arrForms[i] = new Form1();
                arrForms[i].Show();
            }

            if (rand_ManagerForms.Next(2) == 0)
            {
                arrForms[0].Text = "Rectangle";                
                arrForms[1].Text = "Square";
            }
            else
            {
                arrForms[0].Text = "Square";                
                arrForms[1].Text = "Rectangle";
            }

            switch (rand_ManagerForms.Next(6))
            {
                case 0: arrForms[0].label_RedGreenBlue.Text = "Red";
                    arrForms[1].label_RedGreenBlue.Text = "Green"; break;
                case 1: arrForms[0].label_RedGreenBlue.Text = "Red";
                    arrForms[1].label_RedGreenBlue.Text = "Blue"; break;
                case 2: arrForms[0].label_RedGreenBlue.Text = "Green";
                    arrForms[1].label_RedGreenBlue.Text = "Red"; break;
                case 3: arrForms[0].label_RedGreenBlue.Text = "Green";
                    arrForms[1].label_RedGreenBlue.Text = "Blue"; break;
                case 4: arrForms[0].label_RedGreenBlue.Text = "Blue";
                    arrForms[1].label_RedGreenBlue.Text = "Red"; break;
                case 5: arrForms[0].label_RedGreenBlue.Text = "Blue";
                    arrForms[1].label_RedGreenBlue.Text = "Green"; break;
            }

            if (rand_ManagerForms.Next(2) == 0)
            {
                arrForms[0].label_MinMax.Text = "Min";
                arrForms[1].label_MinMax.Text = "Max";
            }
            else
            {
                arrForms[0].label_MinMax.Text = "Max";
                arrForms[1].label_MinMax.Text = "Min";
            }

            this.FormBorderStyle = FormBorderStyle.None;
            this.TransparencyKey = SystemColors.Control;
            this.ShowInTaskbar = false;
        }
    }
}
