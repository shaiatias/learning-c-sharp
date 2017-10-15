using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;

namespace Client
{
    public partial class UserControl1 : UserControl
    {
        public delegate void MyEventHandler(int columnId, int selected);
        public event MyEventHandler onColumnSelected;

        public IGameServer server;
        private PencilColor[] pencils;
        private int columnId;
        private Player currentPlayer;
        
        public UserControl1(PencilColor[] pencils, IGameServer server, int columnId, Player currentPlayer)
        {
            InitializeComponent();

            this.pencils = pencils;
            this.server = server;
            this.columnId = columnId;
            this.currentPlayer = currentPlayer;

            int available = 0;

            for (int i = 0; i < pencils.Length; i++)
            {
                PictureBox pic = new PictureBox()
                {
                    Image = getPic(pencils[i]),
                    Location = new Point(0, i * 30 + 50),
                    Size = new Size(100, 20)
                };

                this.Controls.Add(pic);

                if (pencils[i] == PencilColor.GREY)
                    comboBox1.Items.Add(++available);
            }

            comboBox1.SelectedItem = pencils.Length;
        }

        private Image getPic(PencilColor item)
        {
            switch (item)
            {
                case PencilColor.BLUE:
                    return Properties.Resources.BluePen;
                case PencilColor.RED:
                    return Properties.Resources.RedPen;
                default:
                    return Properties.Resources.GrayPen;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.onColumnSelected?.Invoke(columnId, int.Parse(this.comboBox1.SelectedItem.ToString()));
        }
    }
}
