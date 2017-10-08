using System;
using System.Collections.Generic;

namespace Common
{
    public delegate void delegateFromServer_StateUpdate(GameState state);

    public enum ConnectionState
    {
        BLUE_CONNECTED,
        RED_CONNECTED,
        NOT_CONNECTED
    }

    public interface IGameServer
    {
        event delegateFromServer_StateUpdate fromServer_StateUpdateEvent;

        void connectToServer();
        void startNewGame();
        void makeMove(int columnId, int selected);
        void simulateNextMove();
    }

    [Serializable]
    public class GameState
    {
        public ConnectionState connection;

        public List<PencilColumn> columns;
        public Player currentPlayer;
        public bool finish;

        public GameState (List<PencilColumn> columns, Player currentPlayer, bool finish, ConnectionState connection)
        {
            this.columns = columns;
            this.currentPlayer = currentPlayer;
            this.finish = finish;
            this.connection = connection;
        }
    }

    public enum Player
    {
        BLUE,
        RED
    }

    public enum PencilColor
    {
        BLUE,
        RED,
        GREY
    }

    public class PencilColumn {

        public List<PencilColor> pencils;

        public int getAvailable()
        {
            return pencils == null ? 0 : pencils.FindAll(p => p == PencilColor.GREY).Count;
        }

        public PencilColumn(int count)
        {
            List<PencilColor> pencils = new List<PencilColor>();

            for (int i = 0; i < count; i++)
            {
                pencils.Add(PencilColor.GREY);
            }

            this.pencils = pencils;
        }
    }
}
