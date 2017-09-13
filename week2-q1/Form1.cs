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
        private int myNextActionCounter;
        private PencilColumn myNextActionControl;

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

            button1.BackColor = currentPlayer == Player.BLUE ? Color.Blue : Color.Red;

            if (currentPlayer == Player.RED && !isOpponentHuman)
            {
                button1.Image = Properties.Resources.Computer.ToBitmap();
            }
            else
            {
                button1.Image = null;
            }

            myNextActionControl = null;
            myNextActionCounter = 0;
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
                        ((PencilColumn)item).IsEnabled = false;
                    }
                });
            }

            else
            {
                flowLayoutPanel1.Controls.OfType<Control>().ToList().ForEach((item) =>
                {
                    if (item is PencilColumn)
                    {
                        ((PencilColumn)item).IsEnabled = true;
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

            else if (isOpponentHuman)
            {
                MessageBox.Show("Red Player Won", "Yehh! The red player won!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                PencilColumn pencil = new PencilColumn()
                {
                    Counter = value
                };

                pencil.OnCounterSelectionChangedEvent += new PencilColumn.CounterSelectionChangedHandler(onCounterChanged);

                flowLayoutPanel1.Controls.Add(pencil);
            }

            button1.Enabled = true;
        }

        private void onCounterChanged(object sender, CounterSelectionArgs e)
        {
            myNextActionCounter = e.Counter;
            myNextActionControl = (PencilColumn)sender;

            flowLayoutPanel1.Controls.OfType<Control>().ToList().ForEach((item) =>
            {
                if (item is PencilColumn)
                {
                    ((PencilColumn)item).IsEnabled = false;
                }
            });
        }

        private void simulateNextStep()
        {
            PencilColumn removeColumn = null;
            int removeCount = 0;

            bool canWin = true;

            flowLayoutPanel1.Controls.OfType<Control>().ToList().ForEach((item) =>
            {
                if (item is PencilColumn)
                {
                    canWin = canWin != (((PencilColumn)item).remaining == 0);
                }
            });

            
                flowLayoutPanel1.Controls.OfType<Control>().ToList().ForEach((item) =>
                {
                    if (item is PencilColumn)
                    {
                        if (((PencilColumn)item).remaining != 0)
                        {
                            removeColumn = (PencilColumn) item;
                            removeCount = ((PencilColumn)item).remaining;
                        }
                    }
                });


            myNextActionControl = removeColumn;
            myNextActionCounter = removeCount;

            doUserStep();
        }

        private bool didWin()
        {
            int left = 0;

            flowLayoutPanel1.Controls.OfType<Control>().ToList().ForEach((item) =>
            {
                if (item is PencilColumn) {
                    left = left + ((PencilColumn)item).remaining;
                }
            });

            return left == 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (currentPlayer == Player.RED && !isOpponentHuman)
            {
                simulateNextStep();
            }

            else
            {
                doUserStep();
            }

            afterStep();
        }

        private void doUserStep()
        {
            if (myNextActionControl == null)
            {
                return;
            }

            myNextActionControl.PencilsToRemove = myNextActionCounter;

            afterStep();
        }
    }
}
