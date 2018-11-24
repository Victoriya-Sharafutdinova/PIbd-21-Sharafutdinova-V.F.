using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsCars
{
    class Ship : SimpleShip
    {
        public Color DopColor { private set; get; }

        public Ship(int maxSpeed, float weight, Color mainColor, Color dopColor) : base(maxSpeed, weight, mainColor)
        {
            DopColor = dopColor;
        }

        public override void DrawShip(Graphics g)
        {
            base.DrawShip(g);
            Brush brGray = new SolidBrush(Color.Gray);
            Brush brRed = new SolidBrush(Color.Red);
            Brush brBlack = new SolidBrush(Color.Black);
            g.FillRectangle(brGray, _startPosX, _startPosY + 10, 10, 10);
            g.FillRectangle(brRed, _startPosX + 10, _startPosY + 10, 10, 10);
            g.FillRectangle(brBlack, _startPosX + 20, _startPosY + 10, 10, 10);
            g.FillRectangle(brRed, _startPosX + 30, _startPosY + 10, 10, 10);
            g.FillRectangle(brGray, _startPosX + 40, _startPosY + 10, 10, 10);
            g.FillRectangle(brRed, _startPosX + 50, _startPosY + 10, 10, 10);
            g.FillRectangle(brGray, _startPosX + 60, _startPosY + 10, 10, 10);
            g.FillRectangle(brRed, _startPosX, _startPosY, 10, 10);
            g.FillRectangle(brGray, _startPosX + 10, _startPosY, 10, 10);
            g.FillRectangle(brBlack, _startPosX + 20, _startPosY, 10, 10);
            g.FillRectangle(brGray, _startPosX + 30, _startPosY, 10, 10);
            g.FillRectangle(brRed, _startPosX + 40, _startPosY, 10, 10);
            g.FillRectangle(brBlack, _startPosX + 50, _startPosY, 10, 10);
            g.FillRectangle(brRed, _startPosX + 60, _startPosY, 10, 10);
            g.FillRectangle(brBlack, _startPosX + 20, _startPosY - 10, 10, 10);
            g.FillRectangle(brRed, _startPosX + 40, _startPosY - 10, 10, 10);
            g.FillRectangle(brGray, _startPosX + 50, _startPosY - 10, 10, 10);

            Pen pen = new Pen(Color.Black);
            Brush br = new SolidBrush(DopColor);
            Point point1 = new Point((int)_startPosX, (int)_startPosY + 20);
            Point point2 = new Point((int)_startPosX + 90, (int)_startPosY + 20);
            Point point3 = new Point((int)_startPosX + 82, (int)_startPosY + 35);
            Point point4 = new Point((int)_startPosX + 10, (int)_startPosY + 35);
            Point[] curvePoints = { point1, point2, point3, point4 };
            g.FillPolygon(br, curvePoints);
            g.DrawPolygon(pen, curvePoints);
        }
        public void SetDopColor(Color color)
        {
            DopColor = color;
        }
    }
}
