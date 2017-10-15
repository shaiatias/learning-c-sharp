using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Color_White_ManagerForms_Event
{
    public partial class UserControl_Large : UserControl
    {
        public event OnRowClickEvent rowClickEvent;
        public delegate void OnRowClickEvent(UserControl_Large userControl_large, UserControl_Small userControl_Small, String color);

        private UserControl_Small[] arrUC_Small = new UserControl_Small[2];

        public UserControl_Large()
        {
            InitializeComponent();
            for (int i = 0; i < 2; i++)
            {
                arrUC_Small[i] = new UserControl_Small();
                arrUC_Small[i].Location = new Point(63, 2 + 49 * i);
                this.Controls.Add(arrUC_Small[i]);

                arrUC_Small[i].Click += new EventHandler((sender, e) =>
                {
                        rowClickEvent?.Invoke(this, (UserControl_Small) sender, this.radioButtonWhite.Checked ? "White" : "Color");
                });
            }
        }


    }
}
