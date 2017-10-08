using Common;
using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        private IGameServer server;
        private GameState currentState;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HttpChannel channel = new HttpChannel();
            ChannelServices.RegisterChannel(channel, false);

            server = (IGameServer)Activator.GetObject(typeof(IGameServer), "http://localhost:1234/_Server_");
            server.connectToServer();

            new Thread(() => {
                Thread.Sleep(1000 * 5);
                server.fromServer_StateUpdateEvent += new delegateFromServer_StateUpdate(onStateChanged);
            }).Start();
        }

        private void onStateChanged(GameState state)
        {
            currentState = state;
            paintNewState(currentState);
        }

        void paintNewState(GameState newState)
        {
            // clear state

            foreach (PencilColumn column in newState.columns)
            {
                // add column
                
                foreach (PencilColor color in column.pencils)
                {
                    // add pencil
                }

                // update combo list
                int valueInCombo = column.getAvailable();
            }

            if (newState.finish)
            {
                // show pop up
            }
        }
    }
}
