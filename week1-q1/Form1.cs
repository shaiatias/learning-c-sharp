using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace week1
{
    public partial class Form1 : Form
    {
        List<int> nums = new List<int>(16);
        Dictionary<String, Button> tagToButton = new Dictionary<string, Button>();

        public Form1()
        {
            InitializeComponent();

            for (int i = 1; i < 16; i++)
            {
                nums.Add(i);
            }

            foreach (Button b in getAllButtons())
            {
                tagToButton.Add(b.Tag.ToString(), b);
            }
        }

        public void newGame()
        {
            Shuffle(nums);

            var numsIt = nums.GetEnumerator();

            foreach (Button b in getAllButtons())
            {
                if (b.Tag != null && b.Tag.ToString() == "")
                {
                    b.Text = "";
                    b.Visible = false;
                }

                else
                {
                    numsIt.MoveNext();

                    b.Text = numsIt.Current.ToString();
                    b.Visible = true;
                    b.BackColor = getRandomBackgroundColor(b);
                }
            }
        }

        private static Color getRandomBackgroundColor(Object seed)
        {
            Random rnd = new Random(seed.GetHashCode() + DateTime.Now.Millisecond);

            int r = rnd.Next(255);
            int g = rnd.Next(255);
            int b = rnd.Next(255);

            return Color.FromArgb(r,g,b);
        }

        private IEnumerable<Button> getAllButtons()
        {
            List<Button> elements = new List<Button>();

            foreach (Control c in this.Controls)
            {
                Button b = c as Button;

                if (b != null)
                {
                    elements.Add(b);
                }
            }

            return elements;
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Start new game?", "New Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                newGame();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            newGame();
        }

        public void Shuffle<T>(IList<T> list)
        {
            Random rng = new Random();

            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        private bool didWin()
        {
            foreach (Button b in getAllButtons())
            {
                if (b.Tag.ToString() != b.Text.ToString())
                {
                    return false;
                }
            }

            return true;
        }

        private bool didLose()
        {
            return false;
        }

        private void afterTurn()
        {

            if (didWin())
            {
                MessageBox.Show("Victory! :)", "Win", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var result = MessageBox.Show("Start new game?", "New Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    newGame();
                }
            }

            else if (didLose())
            {
                MessageBox.Show("Arrrr! you lost", "Lose", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                var result = MessageBox.Show("Start new game?", "New Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    newGame();
                }
            }
        }

        private void doClick(object sender, EventArgs e)
        {
            Button b = sender as Button;

            if (b == null)
            {
                Console.WriteLine("sender is not a button");
                return;
            }

            if (b.Text.ToString() == "")
            {
                Console.WriteLine("ignore click on empty cell");
                return;
            }

            Button neighbor = getEmptyCellNear(b);

            if (neighbor == null) {
                Console.WriteLine("button has no empty neighbors, skip this click");
                return;
            }

            swapButtons(b, neighbor);

            afterTurn();
        }

        private Button getEmptyCellNear(Button b)
        {
            switch (b.Tag.ToString())
            {
                case "1":
                    if (tagToButton["2"].Text.ToString() == "") return tagToButton["2"];
                    if (tagToButton["5"].Text.ToString() == "") return tagToButton["5"];
                    break;

                case "2":
                    if (tagToButton["1"].Text.ToString() == "") return tagToButton["1"];
                    if (tagToButton["3"].Text.ToString() == "") return tagToButton["3"];
                    if (tagToButton["6"].Text.ToString() == "") return tagToButton["6"];
                    break;

                case "3":
                    if (tagToButton["2"].Text.ToString() == "") return tagToButton["2"];
                    if (tagToButton["4"].Text.ToString() == "") return tagToButton["4"];
                    if (tagToButton["7"].Text.ToString() == "") return tagToButton["7"];
                    break;

                case "4":
                    if (tagToButton["3"].Text.ToString() == "") return tagToButton["3"];
                    if (tagToButton["8"].Text.ToString() == "") return tagToButton["8"];
                    break;

                case "5":
                    if (tagToButton["1"].Text.ToString() == "") return tagToButton["1"];
                    if (tagToButton["6"].Text.ToString() == "") return tagToButton["6"];
                    if (tagToButton["9"].Text.ToString() == "") return tagToButton["9"];
                    break;

                case "6":
                    if (tagToButton["2"].Text.ToString() == "") return tagToButton["2"];
                    if (tagToButton["5"].Text.ToString() == "") return tagToButton["5"];
                    if (tagToButton["7"].Text.ToString() == "") return tagToButton["7"];
                    if (tagToButton["10"].Text.ToString() == "") return tagToButton["10"];
                    break;

                case "7":
                    if (tagToButton["3"].Text.ToString() == "") return tagToButton["3"];
                    if (tagToButton["6"].Text.ToString() == "") return tagToButton["6"];
                    if (tagToButton["8"].Text.ToString() == "") return tagToButton["8"];
                    if (tagToButton["11"].Text.ToString() == "") return tagToButton["11"];
                    break;

                case "8":
                    if (tagToButton["4"].Text.ToString() == "") return tagToButton["4"];
                    if (tagToButton["7"].Text.ToString() == "") return tagToButton["7"];
                    if (tagToButton["12"].Text.ToString() == "") return tagToButton["12"];
                    break;

                case "9":
                    if (tagToButton["5"].Text.ToString() == "") return tagToButton["5"];
                    if (tagToButton["10"].Text.ToString() == "") return tagToButton["10"];
                    if (tagToButton["13"].Text.ToString() == "") return tagToButton["13"];
                    break;

                case "10":
                    if (tagToButton["6"].Text.ToString() == "") return tagToButton["6"];
                    if (tagToButton["9"].Text.ToString() == "") return tagToButton["9"];
                    if (tagToButton["11"].Text.ToString() == "") return tagToButton["11"];
                    if (tagToButton["14"].Text.ToString() == "") return tagToButton["14"];
                    break;

                case "11":
                    if (tagToButton["7"].Text.ToString() == "") return tagToButton["7"];
                    if (tagToButton["10"].Text.ToString() == "") return tagToButton["10"];
                    if (tagToButton["12"].Text.ToString() == "") return tagToButton["12"];
                    if (tagToButton["15"].Text.ToString() == "") return tagToButton["15"];
                    break;

                case "12":
                    if (tagToButton[""].Text.ToString() == "") return tagToButton[""];
                    if (tagToButton["8"].Text.ToString() == "") return tagToButton["8"];
                    if (tagToButton["11"].Text.ToString() == "") return tagToButton["11"];
                    break;


                case "13":
                    if (tagToButton["9"].Text.ToString() == "") return tagToButton["9"];
                    if (tagToButton["14"].Text.ToString() == "") return tagToButton["14"];
                    break;

                case "14":
                    if (tagToButton["10"].Text.ToString() == "") return tagToButton["10"];
                    if (tagToButton["13"].Text.ToString() == "") return tagToButton["13"];
                    if (tagToButton["15"].Text.ToString() == "") return tagToButton["15"];
                    break;

                case "15":
                    if (tagToButton[""].Text.ToString() == "") return tagToButton[""];
                    if (tagToButton["11"].Text.ToString() == "") return tagToButton["11"];
                    if (tagToButton["14"].Text.ToString() == "") return tagToButton["14"];
                    break;

                case "":
                    if (tagToButton["12"].Text.ToString() == "") return tagToButton["12"];
                    if (tagToButton["15"].Text.ToString() == "") return tagToButton["15"];
                    break;
            }

            return null;
        }

        private void swapButtons(Button original, Button empty)
        {
            original.Visible = false;
            empty.Visible = true;

            empty.Text = original.Text;
            original.Text = "";

            empty.BackColor = original.BackColor;
        }
    }
}
