using System;
using System.Windows.Forms;

namespace DragDrop_Event_ManagerForms_Square_Rectangle
{
    public class DragStartedEventArgs : EventArgs
    {
        public UserControl ucSender;
        public Form formSender;
    }
}