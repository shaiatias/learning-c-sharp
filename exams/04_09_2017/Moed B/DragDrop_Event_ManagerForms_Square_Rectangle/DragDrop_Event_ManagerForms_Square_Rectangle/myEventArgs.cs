using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragDrop_Event_ManagerForms_Square_Rectangle
{
    public class myEventArgs : EventArgs
    {
        public UserControl1 EventArgs_UC_1, EventArgs_UC_2;
        public Form1 EventArgs_Form_1;
    }
}
