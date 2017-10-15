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
    public delegate void delegate_MyEventHadler(object sender, myEventArgs e);

    public partial class UserControl_Small : UserControl
    {
        static private Random myRand = new Random();
        public Control[] arrControls;
       public event delegate_MyEventHadler event_From_UC_Small;
        public UserControl_Small()
        {
            InitializeComponent();

            int arrSize = myRand.Next(10, 18);
            arrControls = new Control[arrSize];
            int position = 2;
            for (int i = 0; i < arrSize; i++)
            {
                if (myRand.Next(2) == 0)
                    arrControls[i] = new Label();
                else
                    arrControls[i] = new Button();

                arrControls[i].Size = new Size(myRand.Next(20, 100), 40);

                if (myRand.Next(2) == 0)
                    arrControls[i].BackColor = Color.FromArgb(myRand.Next(120, 256), myRand.Next(120, 256), myRand.Next(120, 256));
                else
                    arrControls[i].BackColor = Color.White;

                arrControls[i].Location = new Point(position, 2);
                position += arrControls[i].Width + 2; 
                this.Controls.Add(arrControls[i]);
            }

        }
        private void UserControl_Small_Click(object sender, EventArgs e)
        {
            myEventArgs myEventArgs_temp = new myEventArgs();
            myEventArgs_temp.EventArg_UC_Small = this;

            if (event_From_UC_Small != null)
                event_From_UC_Small(this, myEventArgs_temp);
        }
    }
}
