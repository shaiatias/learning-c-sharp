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
        public static Random ServerRand = new Random();
        public static Color ServerColor = new Color();

        public Form1()
        {
            InitializeComponent();
            HttpChannel chnl = new HttpChannel(1234);
            ChannelServices.RegisterChannel(chnl, false);

            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(ServerPartFactory),
                "_Server_",
                WellKnownObjectMode.Singleton);

            switch (ServerRand.Next(3))
            {
                case 0: ServerColor = this.BackColor = Color.Red; return;
                case 1: ServerColor = this.BackColor = Color.Green; return;
                case 2: ServerColor = this.BackColor = Color.Blue; return;
            }
        }
    }

    class ServerPart : MarshalByRefObject, ICommon
    {
        SortedList ButtonSortedList = new SortedList(), LabelSortedList = new SortedList();

        public int[] CallToServer(IndexColorType tempIndexColorType)
        {
            int[] returnArr = null;
            if (tempIndexColorType.mColor.R != 0 && Form1.ServerColor.Name == "Red"
                ||
                tempIndexColorType.mColor.G != 0 && Form1.ServerColor.Name == "Green"
                ||
                tempIndexColorType.mColor.B != 0 && Form1.ServerColor.Name == "Blue")
            {
                if( tempIndexColorType.mType == "Button")
                    ButtonSortedList.Add(tempIndexColorType.mColor.R + tempIndexColorType.mColor.G + tempIndexColorType.mColor.B + Form1.ServerRand.Next(1000) * 0.00001, tempIndexColorType.mIndex);
                else
                    LabelSortedList.Add(tempIndexColorType.mColor.R + tempIndexColorType.mColor.G + tempIndexColorType.mColor.B + Form1.ServerRand.Next(1000) * 0.00001, tempIndexColorType.mIndex);

                returnArr = new int[ButtonSortedList.Count + LabelSortedList.Count];
                int k = 0;
                for (int i = 0; i < ButtonSortedList.Count; i++)
                    returnArr[k++] = (int)(ButtonSortedList.GetByIndex(i));
                 for (int i = 0; i < LabelSortedList.Count; i++)
                    returnArr[k++] = (int)(LabelSortedList.GetByIndex(i));     
            }
            return returnArr;
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