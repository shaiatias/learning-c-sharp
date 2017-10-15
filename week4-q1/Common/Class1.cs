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
        GameState connectToServer();
        GameState startNewGame(int columns);
        GameState makeMove(int columnId, int selected, Player currentPlayer);
        GameState simulateNextMove();
    }

    [Serializable]
    public class GameState
    {
        public ConnectionState connection;

        public PencilColumn[] columns;
        public Player currentPlayer;
        public bool finish;

        public GameState (PencilColumn[] columns, Player currentPlayer, bool finish, ConnectionState connection)
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

    [Serializable]
    public class PencilColumn {

        public PencilColor[] pencils;

        public int getAvailable()
        {
            return pencils == null ? 0 : new System.Collections.Generic.List<PencilColor>(pencils).FindAll(p => p == PencilColor.GREY).Count;
        }

        public PencilColumn(int count)
        {
            List<PencilColor> pencils = new List<PencilColor>();

            for (int i = 0; i < count; i++)
            {
                pencils.Add(PencilColor.GREY);
            }

            this.pencils = pencils.ToArray();
        }
    }
}
