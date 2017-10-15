using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels;
using System.Collections;
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
                typeof(ServerPart),
                "_Server_",
                WellKnownObjectMode.Singleton);
        }
    }

    class ServerPart : MarshalByRefObject, ICommon
    {
        private SortedList mySL_Red = new SortedList(), mySL_Blue = new SortedList(), mySL_Green = new SortedList(); 
        private Random myRand = new Random();

        public void add_Client(TypeColor[] arrTypeColor)
        {
            for (int i = 0; i < arrTypeColor.Length; i++)
            {
                if (arrTypeColor[i].mColor.R != 0)
                    mySL_Red.Add(arrTypeColor[i].mColor.R + myRand.Next(1000) * 0.00001, arrTypeColor[i]);
                if (arrTypeColor[i].mColor.G != 0)
                    mySL_Green.Add(arrTypeColor[i].mColor.G + myRand.Next(1000) * 0.00001, arrTypeColor[i]);
                if (arrTypeColor[i].mColor.B != 0)
                    mySL_Blue.Add(arrTypeColor[i].mColor.B + myRand.Next(1000) * 0.00001, arrTypeColor[i]);
            }
        }
        public TypeColor[] getData(string ColorName, int prevCounter)
        {
            SortedList tempSL = null;
            switch(ColorName)
            {
                case "Red": tempSL = mySL_Red; break;
                case "Green": tempSL = mySL_Green; break;
                case "Blue": tempSL = mySL_Blue; break;
            }

            if( prevCounter == tempSL.Count)
                return null;

            TypeColor[] returnArr = new TypeColor[tempSL.Count];
            for (int i = 0; i < tempSL.Count; i++)
                returnArr[i] = (TypeColor)(tempSL.GetByIndex(i));
            return returnArr;
        }
     }
}