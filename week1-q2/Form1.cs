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

namespace week1_q2
{
    public partial class Form1 : Form
    {
        List<Point> points = new List<Point>(16);
        Dictionary<Point, Button> tagToButton = new Dictionary<Point, Button>();
        Dictionary<string, Button> textToButton = new Dictionary<string, Button>();
        Dictionary<Point, List<Point>> pointToNeighbors = new Dictionary<Point, List<Point>>();

        public Form1()
        {
            InitializeComponent();

            foreach (Button b in getAllButtons())
            {
                points.Add(b.Location);
                b.Tag = b.Location;
                tagToButton.Add(b.Location, b);
                textToButton.Add(b.Text, b);
            }

            LoadPointToNeighbors();
        }

        private void LoadPointToNeighbors()
        {
            foreach (Button b in getAllButtons())
            {
                List<Point> neighbors = new List<Point>();

                switch (b.Text.ToString())
                {
                    case "1":
                        neighbors.Add(textToButton["2"].Location);
                        neighbors.Add(textToButton["5"].Location);
                        break;

                    case "2":
                        neighbors.Add(textToButton["1"].Location);
                        neighbors.Add(textToButton["3"].Location);
                        neighbors.Add(textToButton["6"].Location);
                        break;

                    case "3":
                        neighbors.Add(textToButton["2"].Location);
                        neighbors.Add(textToButton["4"].Location);
                        neighbors.Add(textToButton["7"].Location);
                        break;

                    case "4":
                        neighbors.Add(textToButton["3"].Location);
                        neighbors.Add(textToButton["8"].Location);
                        break;

                    case "5":
                        neighbors.Add(textToButton["1"].Location);
                        neighbors.Add(textToButton["6"].Location);
                        neighbors.Add(textToButton["9"].Location);
                        break;

                    case "6":
                        neighbors.Add(textToButton["2"].Location);
                        neighbors.Add(textToButton["5"].Location);
                        neighbors.Add(textToButton["7"].Location);
                        neighbors.Add(textToButton["10"].Location);
                        break;

                    case "7":
                        neighbors.Add(textToButton["3"].Location);
                        neighbors.Add(textToButton["6"].Location);
                        neighbors.Add(textToButton["8"].Location);
                        neighbors.Add(textToButton["11"].Location);
                        break;

                    case "8":
                        neighbors.Add(textToButton["4"].Location);
                        neighbors.Add(textToButton["7"].Location);
                        neighbors.Add(textToButton["12"].Location);
                        break;

                    case "9":
                        neighbors.Add(textToButton["5"].Location);
                        neighbors.Add(textToButton["10"].Location);
                        neighbors.Add(textToButton["13"].Location);
                        break;

                    case "10":
                        neighbors.Add(textToButton["6"].Location);
                        neighbors.Add(textToButton["9"].Location);
                        neighbors.Add(textToButton["11"].Location);
                        neighbors.Add(textToButton["14"].Location);
                        break;

                    case "11":
                        neighbors.Add(textToButton["7"].Location);
                        neighbors.Add(textToButton["10"].Location);
                        neighbors.Add(textToButton["12"].Location);
                        neighbors.Add(textToButton["15"].Location);
                        break;

                    case "12":
                        neighbors.Add(textToButton[""].Location);
                        neighbors.Add(textToButton["8"].Location);
                        neighbors.Add(textToButton["11"].Location);
                        break;


                    case "13":
                        neighbors.Add(textToButton["9"].Location);
                        neighbors.Add(textToButton["14"].Location);
                        break;

                    case "14":
                        neighbors.Add(textToButton["10"].Location);
                        neighbors.Add(textToButton["13"].Location);
                        neighbors.Add(textToButton["15"].Location);
                        break;

                    case "15":
                        neighbors.Add(textToButton[""].Location);
                        neighbors.Add(textToButton["11"].Location);
                        neighbors.Add(textToButton["14"].Location);
                        break;

                    case "":
                        neighbors.Add(textToButton["12"].Location);
                        neighbors.Add(textToButton["15"].Location);
                        break;
                }

                pointToNeighbors.Add(b.Location, neighbors);
            }
        }

        public void newGame()
        {
            foreach (Button b in getAllButtons())
            {
                b.Location = (Point) b.Tag;
            }

            points.Remove(textToButton[""].Location);

            Shuffle(points);

            points.Add(textToButton[""].Location);

            var pointsIt = points.GetEnumerator();

            foreach (Button b in getAllButtons())
            {
                if (b.Name != null && b.Name.ToString() == "empty")
                {
                    b.Text = "";
                    b.Visible = false;
                }

                else
                {
                    pointsIt.MoveNext();

                    b.Location = pointsIt.Current;

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

            return Color.FromArgb(r, g, b);
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
                if (b.Tag.ToString() != b.Location.ToString())
                {
                    return false;
                }
            }

            return true;
        }

        private bool didLose()
        {
            if (textToButton["15"].Location.ToString() ==   // 15 in 14
                textToButton["14"].Tag.ToString() &&        // and
                textToButton["14"].Location.ToString() ==   // 14 in 15
                textToButton["15"].Tag.ToString())
            {
                return true;
            }
            else
            {
                return false;
            }
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
            if (isDuringAnimation)
            {
                return;
            }

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

            if (neighbor == null)
            {
                Console.WriteLine("button has no empty neighbors, skip this click");
                return;
            }

            moveButton(b, neighbor);

            afterTurn();
        }

        private Button getEmptyCellNear(Button b)
        {

            foreach (Point p in pointToNeighbors[b.Location])
            {
                Button nButton = getButtonInPoint(p);

                if (nButton != null && nButton.Name.ToString() == "empty")
                {
                    return nButton;
                }
            }

            return null;
        }

        private Button getButtonInPoint(Point p)
        {
            foreach (Button b in getAllButtons())
            {
                if (b.Location.ToString() == p.ToString())
                {
                    return b;
                }
            }

            return null;
        }

        private void moveButton(Button original, Button empty)
        {
            animateToPoint = empty.Location;
            buttonToAnimate = original;

            isDuringAnimation = true;
            timer1.Enabled = true;

            empty.Location = original.Location;
        }

        bool isDuringAnimation = false;
        Point animateToPoint;
        Button buttonToAnimate;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!isDuringAnimation)
            {
                return;
            }

            Point p = buttonToAnimate.Location;

            if (buttonToAnimate.Location.X != animateToPoint.X)
            {
                int x = (buttonToAnimate.Location.X < animateToPoint.X) ?
                        buttonToAnimate.Location.X + 1 :
                        buttonToAnimate.Location.X - 1 ;

                p.X = x;
            }
            else if (buttonToAnimate.Location.Y != animateToPoint.Y)
            {
                int y = (buttonToAnimate.Location.Y < animateToPoint.Y) ?
                        buttonToAnimate.Location.Y + 1 :
                        buttonToAnimate.Location.Y - 1;

                p.Y = y;
            }
            else
            {
                isDuringAnimation = false;
                this.timer1.Enabled = false;
            }

            buttonToAnimate.Location = p;
        }
    }
}
