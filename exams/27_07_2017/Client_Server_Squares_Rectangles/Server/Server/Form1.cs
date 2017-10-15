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
        private SortedList rects = new SortedList();
        private SortedList squares = new SortedList();

        private Random rand = new Random();

        public void addControls(MControl[] controls)
        {
            foreach (var c in controls)
            {
                if (isSquare(c.size))
                    squares.Add((c.size.Height * c.size.Width) + rand.Next(1000) * 0.00001, c);

                else
                    rects.Add((c.size.Height * c.size.Width) + rand.Next(1000) * 0.00001, c);
            }
        }

        public SortedList refresh(bool returnSquare, int itemCount)
        {
            if (returnSquare)
                return squares.Count == itemCount ? null : squares;

            else
                return rects.Count == itemCount ? null : rects;
        }

        private bool isSquare(Size size) { return size.Height == size.Width; }
    }
}