using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels;
using Common;

namespace Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            HttpChannel chnl = new HttpChannel(1234);
            ChannelServices.RegisterChannel(chnl, false);

            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(ServerPartFactory),
                "_Server_",
                WellKnownObjectMode.Singleton);
        }
    }

    class ServerPart : MarshalByRefObject, ICommon
    {
        SortedList SortedList_Rectangle = new SortedList(), SortedList_Square = new SortedList() ;

        Random myRand = new Random();
        public void Add(SizeColorText tempSizeColorText)
        {
            int width = tempSizeColorText.mSize.Width;
            int height = tempSizeColorText.mSize.Height;

            if (width == height)
                SortedList_Square.Add(width * height + myRand.Next(1000) * 0.00001, tempSizeColorText);
            else
                SortedList_Rectangle.Add(width * height + myRand.Next(1000) * 0.00001, tempSizeColorText);
        }
        public SizeColorText[] allRectanles_Squares(string strRectangleSquare)
        {
            SizeColorText[] returnArrSizeColorText = null;
            if( strRectangleSquare == "Rectangle")
            {
                returnArrSizeColorText = new SizeColorText[SortedList_Rectangle.Count];
                for (int i = 0; i < SortedList_Rectangle.Count; i++)
                    returnArrSizeColorText[i] = (SizeColorText)(SortedList_Rectangle.GetByIndex(i));
                return returnArrSizeColorText;
            }

            returnArrSizeColorText = new SizeColorText[SortedList_Square.Count];
            for (int i = 0; i < SortedList_Square.Count; i++)
                returnArrSizeColorText[i] = (SizeColorText)(SortedList_Square.GetByIndex(i));
            return returnArrSizeColorText;
        }
    }
    class ServerPartFactory : MarshalByRefObject, ICommonFactory
    {
        public ServerPartFactory()
        {
        }
        public ICommon getNewInstance()
        {
            return new ServerPart();
        }
    }
}