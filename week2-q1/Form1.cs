using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace week2_q1
{
    public partial class Form1 : Form
    {
        bool isOpponentHuman = true;
        Player currentPlayer = Player.BLUE;
        int columns = 2;

        public Form1()
        {
            InitializeComponent();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Start new game?", "New Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                startNewGame();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            startNewGame();
        }

        private void computerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            computerToolStripMenuItem.Checked = true;
            humanToolStripMenuItem.Checked = false;

            isOpponentHuman = false;
        }

        private void humanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            computerToolStripMenuItem.Checked = false;
            humanToolStripMenuItem.Checked = true;

            isOpponentHuman = true;
        }

        private void startNewGame()
        {
            resetBoard();

            setNextPlayer(Player.BLUE);
        }        

        private Player getNextPlayer()
        {
            switch (currentPlayer)
            {
                case Player.BLUE:
                    return Player.RED;

                default:
                    return Player.BLUE;
            }
        }

        private void setNextPlayer(Player player)
        {
            currentPlayer = player;

            flowLayoutPanel1.Controls.OfType<Control>().ToList().ForEach((item) =>
            {
                if (item is PencilColumn)
                {
                    ((PencilColumn)item).CurrentPlayer = currentPlayer;
                }
            });
        }

        private void afterStep()
        {
            if (didWin())
            {
                // print message

                // ask user to to reset

                // stop getting new actions
                Controls.OfType<Control>().ToList().ForEach((item) => {
                    
                    if (item is PencilColumn)
                    {
                        ((PencilColumn)item).IsEnabled = false;
                    }
                });
            }

            setNextPlayer(getNextPlayer());

            if (currentPlayer == Player.RED && !isOpponentHuman)
            {
                simulateNextStep();
                afterStep();
            }
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem c = (ToolStripMenuItem) sender;

            columnsToolStripMenuItem.DropDownItems.OfType<ToolStripMenuItem>().ToList().ForEach((item) => { item.Checked = false; });
            c.Checked = true;

            int num = Int32.Parse(c.Text);
            columns = num;

            startNewGame();
        }

        private void resetBoard()
        {
            flowLayoutPanel1.Controls.OfType<Control>().ToList().ForEach((item) => {

                if (item is PencilColumn)
                {
                    item.Dispose();
                    flowLayoutPanel1.Controls.Remove(item);
                }
            });

            Random rand = new Random();

            for (int i = 0; i < columns; i++)
            {
                int value = rand.Next(11) + 1;

                PencilColumn pencil = new PencilColumn()
                {
                    Counter = value,
                    Size = new Size(100, 170)
                };
                
                flowLayoutPanel1.Controls.Add(pencil);
            }

            this.Size = new Size((columns * 106) + 48, this.Size.Height);
        }

        private void simulateNextStep()
        {
            //throw new NotImplementedException();
        }

        private bool didWin()
        {
            int left = 0;

            flowLayoutPanel1.Controls.OfType<Control>().ToList().ForEach((item) =>
            {
                if (item is PencilColumn) {
                    left = left + ((PencilColumn)item).Counter;
                }
            });

            return left == 0;
        }
    }
}
