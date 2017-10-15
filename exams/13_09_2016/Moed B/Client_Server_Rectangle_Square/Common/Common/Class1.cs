using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;

namespace Common
{
    [Serializable]
    public class SizeColorText
    {
        public Size mSize;
        public Color mColor;
        public string mText;
    }
    public interface ICommon
    {
        void Add(SizeColorText tempSizeColorText);
        SizeColorText[] allRectanles_Squares(string strRectangleSquare);
    }
    public interface ICommonFactory
    {
        ICommon getNewInstance();
    }
}

