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

        public ManagerForms()
        {
            InitializeComponent();
            arrForm1 = new Form1[counterForms];
            for (int i = 0; i < counterForms; i++)
            {
                arrForm1[i] = new Form1();
                arrForm1[i].Show();
                arrForm1[i].rowClickEvent += new Form1.OnRowClickEvent(onRowClick);
            }

            arrForm1[0].Text = "Button";
            arrForm1[1].Text = "Label";

            this.FormBorderStyle = FormBorderStyle.None;
            this.TransparencyKey = SystemColors.Control;
            this.ShowInTaskbar = false;
        }

        enum State { NONE, ONCE };

        private UserControl_Small small1, small2;
        private UserControl_Large large1, large2;
        private string color1, color2;
        private Form1 form1, form2;

        private State state = State.NONE;

        private void onRowClick(UserControl_Small small, UserControl_Large large, string color, Form1 form)
        {
            if (state == State.NONE)
            {
                small1 = small;
                large1 = large;
                color1 = color;
                form1 = form;
                state = State.ONCE;
            }

            else
            {
                // ignore clicks on the same control
                if (small1 == small) return;

                small2 = small;
                large2 = large;
                color2 = color;
                form2 = form;

                doLogic();

                small2 = null;
                large2 = null;
                color2 = null;
                form2 = null;
                small1 = null;
                large1 = null;
                color1 = null;
                form1 = null;
                state = State.NONE;
            }
        }

        private void doLogic()
        {
            var combined = small1.arrControls.Concat(small2.arrControls).ToList();
            
            Control preferred1 = getPreferredControl(combined, form1, large1, color1);
            Control preferred2 = getPreferredControl(combined, form2, large2, color2);

            applyNewControl(form1, preferred1);
            applyNewControl(form2, preferred2);
        }

        private Control getPreferredControl(List<Control> combined, Form1 form1, UserControl_Large large1, string color)
        {
            var result = combined
                .OrderBy(control => control.Size.Height * control.Size.Width)
                .Where(control => // color
                {
                    return color == "White" ? isWhite(control.BackColor) : !isWhite(control.BackColor);
                })
                .Where(control => // type
                {
                    return control.GetType() == form1.MinMax_LabelButton.GetType();
                });

            return form1.getMinMax() == "Min" ?
                result.First() :
                result.Last();
        }

        private bool isWhite(Color backColor)
        {
            return backColor == Color.White;
        }

        private void applyNewControl(Form1 form1, Control preferred1)
        {
            form1.setSelectedControl(preferred1);
        }
    }
}
