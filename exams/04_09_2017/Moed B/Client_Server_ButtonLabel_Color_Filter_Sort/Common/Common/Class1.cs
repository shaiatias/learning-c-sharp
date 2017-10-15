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
    public class IndexColorType
    {
        public int mIndex;
        public Color mColor;
        public string mType;
    }
    public interface ICommon
    {
        int[] CallToServer(IndexColorType tempIndexColorType);
    }
    public interface ICommonFactory
    {
        ICommon getNewInstance();
    }
}

