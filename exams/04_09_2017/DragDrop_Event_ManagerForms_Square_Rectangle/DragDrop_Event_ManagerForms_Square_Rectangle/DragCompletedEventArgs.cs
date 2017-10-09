using System;
using System.Windows.Forms;

namespace DragDrop_Event_ManagerForms_Square_Rectangle
{
    public class DragCompletedEventArgs : EventArgs
    {
        public UserControl fromUc;
        public Form fromForm;

        public UserControl toUc;
        public Form toForm;
    }
}