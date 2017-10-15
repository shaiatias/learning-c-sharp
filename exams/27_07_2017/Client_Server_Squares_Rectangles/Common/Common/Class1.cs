using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting.Messaging;
using System.Drawing;
using System.Collections;

namespace Common
{
    public interface ICommon
    {
        void addControls(MControl[] control);
        SortedList refresh(bool returnSquare, int itemCount);
    }

    [Serializable]
    public class MControl
    {
        public string className;
        public Size size;
        public Color backColor;

        public MControl(string className, Size size, Color backColor)
        {
            this.backColor = backColor;
            this.className = className;
            this.size = size;
        }
    }
}
