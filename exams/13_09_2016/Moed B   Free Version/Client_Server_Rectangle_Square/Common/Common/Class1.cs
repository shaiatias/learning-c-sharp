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
    }
    public interface ICommonFactory
    {
        ICommon getNewInstance();
    }
}

