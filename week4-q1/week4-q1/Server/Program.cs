using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Channels.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Remoting.Channels;
using System.Collections;

namespace Server
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            IDictionary props = new Hashtable();
            props["port"] = 1234;

            SoapServerFormatterSinkProvider provider = new SoapServerFormatterSinkProvider();
            provider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;

            HttpChannel chnl = new HttpChannel(props, null, provider);
            ChannelServices.RegisterChannel(chnl, false);

            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(ServerPart),
                "_Server_",
                WellKnownObjectMode.Singleton);

            Form a = new Form();
            Application.Run(a);
        }
    }

    class ServerPart : MarshalByRefObject, IGameServer
    {
        private GameState gameStateOnServer;
        public event delegateFromServer_StateUpdate fromServer_StateUpdateEvent;

        public ServerPart()
        {
            startNewGame();
        }        

        [OneWay]
        public void connectToServer()
        {
            switch (gameStateOnServer.connection)
            {
                case ConnectionState.BLUE_CONNECTED:
                    Console.WriteLine("already connected, will ignore this");
                    break;
                case ConnectionState.RED_CONNECTED:
                    gameStateOnServer.connection = ConnectionState.BLUE_CONNECTED;
                    fromServer_StateUpdateEvent?.Invoke(gameStateOnServer);
                    break;
                case ConnectionState.NOT_CONNECTED:
                    gameStateOnServer.connection = ConnectionState.RED_CONNECTED;
                    fromServer_StateUpdateEvent?.Invoke(gameStateOnServer);
                    break;
            }
        }

        public void makeMove(int columnId, int selected)
        {
            throw new NotImplementedException();
        }

        public void simulateNextMove()
        {
            throw new NotImplementedException();
        }

        [OneWay]
        public void startNewGame()
        {
            List<PencilColumn> columns = getRandomPencilColumns();
            gameStateOnServer = new GameState(columns, Player.BLUE, false, ConnectionState.NOT_CONNECTED);
            fromServer_StateUpdateEvent?.Invoke(this.gameStateOnServer);
        }

        Random random = new Random();

        private List<PencilColumn> getRandomPencilColumns()
        {
            List<PencilColumn> result = new List<PencilColumn>();

            for (int i = 0; i < 4; i++)
            {
                int value = random.Next(11) + 1;
                result.Add(new PencilColumn(value));
            }

            return result;
        }
    }
}
