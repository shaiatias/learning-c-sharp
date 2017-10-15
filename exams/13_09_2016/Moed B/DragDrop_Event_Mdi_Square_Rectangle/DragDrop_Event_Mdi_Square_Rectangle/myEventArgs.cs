using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragDrop_Event_Mdi_Square_Rectangle
{
    public class myEventArgs : EventArgs
    {
        public UserControl1 EventArgs_UC_1, EventArgs_UC_2;
        public Child EventArgs_Child_1;
    }
}
