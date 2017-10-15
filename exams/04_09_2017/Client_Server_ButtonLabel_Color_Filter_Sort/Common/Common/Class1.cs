using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;

namespace Common
{
    public interface ICommon
    {
        ServerState selectControl(MControl control);
    }

    public interface ICommonFactory
    {
        ICommon getNewInstance();
    }

    [Serializable]
    public class ServerState
    {
        public MControl[] labels;
        public MControl[] buttons;
    }

    [Serializable]
    public class MControl
    {
        public Size size;
        public Color color;
        public Type controlClass;
        public int indexInClient;
    }
}

