using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsCars
{
    public class Ship
    {
        private float _startPosX;
        private float _startPosY;
        private int _pictureWidth;
        private int _pictureHeight;
        private const int shipWidth = 100;
        private const int shipHeight = 60;
        public int MaxSpeed { private set; get; }
        public float Weight { private set; get; }
        public Color MainColor { private set; get; }
        public Color DopColor { private set; get; }
        public Ship(int maxSpeed, float weight, Color mainColor, Color dopColor)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
            DopColor = dopColor;
        }
        public void SetPosition(int x, int y, int width, int height)
        {
            _startPosX = x;
            _startPosY = y;
            _pictureWidth = width;
            _pictureHeight = height;
        }
        public void MoveTransport(Direction direction)
        {
            float step = MaxSpeed * 100 / Weight;
            switch (direction)
            {
                case Direction.Right:
                    if(_startPosX + step < _pictureWidth - shipWidth)
                    {
                        _startPosX += step;
                    }
                    break;
                case Direction.Left:
                    if (_startPosX - step > 0)
                    {
                        _startPosX -= step;
                    }
                    break;
                case Direction.Up:
                    if (_startPosY - step - 10 > 0)
                    {
                        _startPosY -= step;
                    }
                    break;
                case Direction.Down:
                    if (_startPosY + step < _pictureHeight - shipHeight)
                    {
                        _startPosY += step;
                    }
                    break;
            }
        }
        public void DrawShip(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            Brush br = new SolidBrush(MainColor);
            Point point1 = new Point((int)_startPosX, (int)_startPosY+20);
            Point point2 = new Point((int)_startPosX + 90, (int)_startPosY+20);
            Point point3 = new Point((int)_startPosX + 75, (int)_startPosY + 50);
            Point point4 = new Point((int)_startPosX + 20, (int)_startPosY + 50);
            Point[] curvePoints = { point1, point2, point3, point4 };
            g.FillPolygon(br, curvePoints);
            g.DrawPolygon(pen, curvePoints);

            Brush spoiler = new SolidBrush(DopColor);
            g.FillRectangle(spoiler, _startPosX + 70, _startPosY - 10 , 15, 30);
            g.DrawRectangle(pen, _startPosX + 70, _startPosY - 10, 15, 30);

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
        }
    }
}
