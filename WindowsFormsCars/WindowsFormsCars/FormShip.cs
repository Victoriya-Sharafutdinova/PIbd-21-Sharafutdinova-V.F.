using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsCars
{
    public partial class FormShip : Form
    {
        private ITransport ship;

        public FormShip()
        {
            InitializeComponent();
        }

        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxShip.Width, pictureBoxShip.Height);
            Graphics gr = Graphics.FromImage(bmp);
            ship.DrawShip(gr);
            pictureBoxShip.Image = bmp;
        }
        private void buttonCreateSimpleShip_Click_1(object sender, EventArgs e)
        {
            Random rnd = new Random();
            ship = new SimpleShip(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Blue);
            ship.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxShip.Width, pictureBoxShip.Height);
            Draw();
        }
        private void buttonCreateShip_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            ship = new Ship(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Blue, Color.White);
            ship.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxShip.Width, pictureBoxShip.Height);
            Draw();
        }
        private void buttonMove_Click(object sender, EventArgs e)
        {
            string name = (sender as Button).Name;
            switch (name)
            {
                case "buttonUp":
                    ship.MoveTransport(Direction.Up);
                    break;
                case "buttonDown":
                    ship.MoveTransport(Direction.Down);
                    break;
                case "buttonLeft":
                    ship.MoveTransport(Direction.Left);
                    break;
                case "buttonRight":
                    ship.MoveTransport(Direction.Right);
                    break;
            }
            Draw();
        }
    }
}
