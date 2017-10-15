using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DragDrop_Event_Mdi_Square_Rectangle
{
    public partial class Container : Form
    {
        private Child[] arrChild = new Child[2];

        public Container()
        {
            InitializeComponent();
            for (int i = 0; i < 2; i++)
            {
                arrChild[i] = new Child();
                arrChild[i].StartPosition = FormStartPosition.Manual;
                arrChild[i].Location = new Point(0, 238 * i);
                arrChild[i].Show();
                arrChild[i].MdiParent = this;

                if (i == 0)
                {
                    arrChild[i].Text = "Button";
                    arrChild[i].Max_RectangleSquare_control = new Button();
                }
                else
                {
                    arrChild[i].Text = "Label";
                    arrChild[i].Max_RectangleSquare_control = new Label();
                }
                arrChild[i].Max_RectangleSquare_control.BackColor = Color.White;
                arrChild[i].Max_RectangleSquare_control.Location = new Point(2, 60);
                arrChild[i].Max_RectangleSquare_control.Size = new Size(30, 30);
                arrChild[i].Controls.Add(arrChild[i].Max_RectangleSquare_control);
            }
        }
    }
}
