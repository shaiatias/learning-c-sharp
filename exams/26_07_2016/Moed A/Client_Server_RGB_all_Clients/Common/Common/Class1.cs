using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting.Messaging;
using System.Drawing;
using System.Collections;

namespace Common
{
    [Serializable]
    public class TypeColor
    {
        public string mType;
        public Color mColor;
    }

    public interface ICommon 
    {
        void add_Client(TypeColor[] arrTypeColor);
        TypeColor[] getData(string ColorName, int prevCounter);
    }
}
