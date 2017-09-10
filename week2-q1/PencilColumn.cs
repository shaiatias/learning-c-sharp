using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace week2_q1
{
    public partial class PencilColumn : UserControl
    {
        #region FIELDS

        private bool _isEnabled = true;
        private int _counter = 0;
        private Player _currentPlayer = Player.BLUE;
        private int _pencilsToRemove = 0;

        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }

            set
            {
                _isEnabled = value;
                onIsEnabledChanged(value);
            }
        }

        public int Counter
        {
            get
            {
                return _counter;
            }

            set
            {
                _counter = value;
                onCounterChanged(value);
            }
        }

        public Player CurrentPlayer
        {

            get
            {
                return _currentPlayer;
            }

            set
            {
                _currentPlayer = value;
                onCurrentPlayerChanged(value);
            }
        }

        public int PencilsToRemove
        {
            get
            {
                return _pencilsToRemove;
            }

            set
            {
                _pencilsToRemove = value;
                onPencilsToRemoveChanged(value);
            }
        }

        #endregion

        public delegate void CounterSelectionChangedHandler(object sender, CounterSelectionArgs e);
        public event CounterSelectionChangedHandler OnCounterSelectionChangedEvent;

        public PencilColumn()
        {
            InitializeComponent();

            CurrentPlayer = Player.BLUE;
            PencilsToRemove = 0;

            IsEnabled = true;
            Counter = 0;
        }

        private void onIsEnabledChanged(bool value)
        {
            comboBox1.Enabled = value;
        }

        List<PencilColor> pencils = new List<PencilColor>();

        private void onCounterChanged(int value)
        {
            countLabel.Text = value.ToString();

            comboBox1.Items.Clear();
            pencils.Clear();

            for (int i = 1; i < Counter + 1; i++)
            {
                comboBox1.Items.Add(i);
                pencils.Add(PencilColor.GREY);
            }

            repaintPencils();
        }

        private void repaintPencils()
        {
            // clear pencils

            pencils.ForEach((pen) =>
            {
                // repaint pencils
            });
        }

        private void onCurrentPlayerChanged(Player value)
        {
            if (value == Player.BLUE)
            {
                comboBox1.ForeColor = Color.Blue;
            }

            else
            {
                comboBox1.ForeColor = Color.Red;
            }
        }

        private void onPencilsToRemoveChanged(int value)
        {
            for (int i = 0, j = 0; j < value; i++)
            {
                if (pencils[i] == PencilColor.GREY)
                {
                    pencils[i] = CurrentPlayer == Player.BLUE ? PencilColor.BLUE : PencilColor.RED;
                    j++;
                }
            }

            repaintPencils();

            _pencilsToRemove = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }

    enum PencilColor
    {
        GREY,
        BLUE,
        RED
    }
}
