using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RGB_Transports_Button_Label
{
    public partial class To : Form
    {
        public Control[] arrControls_To;
        public To(int size)
        {
            InitializeComponent();
            arrControls_To = new Control[size];
        }
    }
}
