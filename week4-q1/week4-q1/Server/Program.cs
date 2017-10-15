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

        public ServerPart()
        {
            startNewGame(7);
        }

        [OneWay]
        public GameState connectToServer()
        {
            switch (gameStateOnServer.connection)
            {
                case ConnectionState.BLUE_CONNECTED:
                    Console.WriteLine("already connected, will ignore this");
                    break;
                case ConnectionState.RED_CONNECTED:
                    gameStateOnServer.connection = ConnectionState.BLUE_CONNECTED;
                    break;
                case ConnectionState.NOT_CONNECTED:
                    gameStateOnServer.connection = ConnectionState.RED_CONNECTED;
                    break;
            }

            return gameStateOnServer;
        }

        [OneWay]
        public GameState simulateNextMove()
        {
            Random rand = new Random();

            int index = -1;

            do {

                var columnIndex = rand.Next(0, gameStateOnServer.columns.Length - 1);
                if (gameStateOnServer.columns[columnIndex].getAvailable() > 0) index = columnIndex;

            } while (index == -1);

            int amount = rand.Next(0, gameStateOnServer.columns[index].getAvailable());

            return makeMove(index, amount, Player.RED);
        }

        [OneWay]
        public GameState startNewGame(int columnsCount)
        {
            List<PencilColumn> columns = getRandomPencilColumns(columnsCount);
            gameStateOnServer = new GameState(columns.ToArray(), Player.BLUE, false, ConnectionState.NOT_CONNECTED);

            return gameStateOnServer;
        }

        Random random = new Random();

        private List<PencilColumn> getRandomPencilColumns(int columnsCount)
        {
            List<PencilColumn> result = new List<PencilColumn>();

            for (int i = 0; i < columnsCount; i++)
            {
                int value = random.Next(11) + 1;
                result.Add(new PencilColumn(value));
            }

            return result;
        }

        [OneWay]
        public GameState makeMove(int columnId, int selected, Player currentPlayer)
        {

            for (int i = 0, j = 0; j < selected; i++)
            {
                if (gameStateOnServer.columns[columnId].pencils[i] == PencilColor.GREY)
                {
                    gameStateOnServer.columns[columnId].pencils[i] = currentPlayer == Player.BLUE ? PencilColor.BLUE : PencilColor.RED;
                    j++;
                }
            }

            return gameStateOnServer;
        }
    }
}
