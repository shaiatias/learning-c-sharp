using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace week3_q1
{
    public partial class Form1 : Form
    {
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
            
        }

        private void afterStep()
        {
            if (didWin())
            {
                // print message
                printCompleteMessage();

                // stop getting new actions
                button1.Enabled = false;
                button1.BackColor = Color.Gray;

                flowLayoutPanel1.Controls.OfType<Control>().ToList().ForEach((item) => {
                    
                    if (item is PencilColumn)
                    {
                    }
                });
            }

            else
            {
                flowLayoutPanel1.Controls.OfType<Control>().ToList().ForEach((item) =>
                {
                    if (item is PencilColumn)
                    {
                    }
                });

                setNextPlayer(getNextPlayer());
            }
        }

        private void printCompleteMessage()
        {
            
            if (currentPlayer == Player.BLUE)
            {
                MessageBox.Show("Blue Player Won", "Yehh! The blue player won!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                MessageBox.Show("You Lost", "The computer won!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

                PencilColumn pencil = new PencilColumn(value);
                flowLayoutPanel1.Controls.Add(pencil);
            }
        }

        private bool didWin()
        {
            int left = 0;

            flowLayoutPanel1.Controls.OfType<Control>().ToList().ForEach((item) =>
            {
                if (item is PencilColumn) {
                    left = left + ((PencilColumn)item).getAvailablePencils();
                }
            });

            return left == 0;
        }

        private void gameLoop()
        {
            while (!didWin())
            {
                PencilColumn nextColumn = getNextStep();

                doNextStep(nextColumn);
            }

            finishGame();
        }

        private void doNextStep(PencilColumn nextColumn)
        {
            int pencilsToPaint = nextColumn.getXorResult();

            if (pencilsToPaint == -1)
            {
                pencilsToPaint;// = // random on get avaliable
            }

            nextColumn.paintPencils(pencilsToPaint);
        }

        private PencilColumn getNextStep()
        {
            foreach (PencilColumn p in getPencilColumns())
            {

                if (currentPlayer == Player.BLUE)
                {
                    p.redReset.WaitOne();
                    p.blueReset.Set();
                }
                else
                {
                    p.blueReset.WaitOne();
                    p.redReset.Set();
                }
            }

            Thread.Sleep(250);

            PencilColumn preferred = getPreferredColumn();

            if (preferred == null)
            {
                preferred = getRandomColumn();
            }

            return preferred;
        }
    }
}
