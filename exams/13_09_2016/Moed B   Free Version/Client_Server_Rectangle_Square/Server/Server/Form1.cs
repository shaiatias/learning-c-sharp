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