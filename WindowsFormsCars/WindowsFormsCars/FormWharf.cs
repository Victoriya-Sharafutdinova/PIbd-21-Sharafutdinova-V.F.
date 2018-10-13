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
    public partial class FormWharf : Form
    {
        Wharf<ITransport> wharf;

        public FormWharf()
        {
            InitializeComponent();
            wharf = new Wharf<ITransport>(20, pictureBoxWharf.Width, pictureBoxWharf.Height);
            Draw();
        }

        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxWharf.Width, pictureBoxWharf.Height);
            Graphics gr = Graphics.FromImage(bmp);
            wharf.Draw(gr);
            pictureBoxWharf.Image = bmp;
        }

        private void buttonSetShip_Click_1(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ColorDialog dialogDop = new ColorDialog();
                if (dialogDop.ShowDialog() == DialogResult.OK)
                {
                    var ship = new Ship(100, 1000, dialog.Color, dialogDop.Color);
                    int place = wharf + ship;
                    Draw();
                }
            }
        }

        private void buttonSetSimpleShip_Click_1(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var ship = new SimpleShip(100, 1000, dialog.Color);
                int place = wharf + ship;
                Draw();
            }
        }
        private void buttonTakeShip_Click_1(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text != "")
            {
                var ship = wharf - Convert.ToInt32(maskedTextBox1.Text);
                if (ship != null)
                {
                    Bitmap bmp = new Bitmap(pictureBoxTakeShip.Width, pictureBoxTakeShip.Height);
                    Graphics gr = Graphics.FromImage(bmp);
                    ship.SetPosition(5, 15, pictureBoxTakeShip.Width, pictureBoxTakeShip.Height);
                    ship.DrawShip(gr);
                    pictureBoxTakeShip.Image = bmp;
                }
                else
                {
                    Bitmap bmp = new Bitmap(pictureBoxTakeShip.Width, pictureBoxTakeShip.Height);
                    pictureBoxTakeShip.Image = bmp;
                }
                Draw();
            }
        }
    }
}
