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
        List<MControl> buttonsList = new List<MControl>();
        List<MControl> labelsList = new List<MControl>();

        public ServerState selectControl(MControl control)
        {
            if (isSameSolidColor(control.color))
            {
                if (control.controlClass == typeof(Button))
                {
                    buttonsList.Add(control);
                }

                else
                {
                    labelsList.Add(control);
                }
            }

            ServerState state = new ServerState();
            state.buttons = buttonsList.ToArray();
            state.labels = labelsList.ToArray();

            return state;
        }

        bool isSameSolidColor(Color c)
        {
            switch (Form1.ServerColor.Name)
            {
                case "Red":
                    return c.R > 0;

                case "Green":
                    return c.G > 0;

                case "Blue":
                    return c.B > 0;
            }

            return false;
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