using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Color_White_ManagerForms_Event
{
    public class myEventArgs : EventArgs
    {
        public UserControl_Small EventArg_UC_Small;
        public string ColorWhite_str;
        public string MinMax_str;
        public string ButtonLabel_str;
    }
}