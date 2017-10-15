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
            onStateChanged(server.connectToServer());
        }

        private void onStateChanged(GameState state)
        {
            currentState = state;
            paintNewState(currentState);
        }

        void paintNewState(GameState newState)
        {
            // clear state
            foreach (Control item in Controls)
            {
                if (item.GetType().Equals(typeof(UserControl1))) {
                    Controls.Remove(item);
                }
            }

            int columnId = 0;

            foreach (PencilColumn column in newState.columns)
            {
                var uc = new UserControl1(column.pencils, server, columnId, Player.BLUE);
                uc.Location = new System.Drawing.Point(columnId * 170 + 3, 20);
                uc.Size = new System.Drawing.Size(170, 400);

                uc.onColumnSelected += onColumnSelected;

                // add column
                Controls.Add(uc);

                columnId++;
            }

            if (newState.finish)
            {
                // show pop up
                MessageBox.Show("finished", "Game Ended", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void onColumnSelected(int columnId, int selected)
        {
            onStateChanged(this.server.makeMove(columnId, selected, Player.BLUE));

            Thread.Sleep(1000);

            onStateChanged(this.server.simulateNextMove());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //onStateChanged(server.connectToServer());
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            onStateChanged(server.startNewGame(Int32.Parse(item.Text)));
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            onStateChanged(server.startNewGame(7));
        }
    }
}
