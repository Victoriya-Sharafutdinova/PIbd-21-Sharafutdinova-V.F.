using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsCars
{
    class SimpleShip : Boat
    {
        protected const int shipWidth = 100;
        protected const int shipHeight = 60;
        public SimpleShip(int maxSpeed, float weight, Color mainColor)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
        }

        public override void MoveTransport(Direction direction)
        {
            float step = MaxSpeed * 100 / Weight;
            switch (direction)
            {
                case Direction.Right:
                    if (_startPosX + step < _pictureWidth - shipWidth)
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
        public override void DrawShip(Graphics g)
        {
            Pen pen = new Pen(Color.Black);
            Brush br = new SolidBrush(MainColor);
            Point point1 = new Point((int)_startPosX, (int)_startPosY + 20);
            Point point2 = new Point((int)_startPosX + 90, (int)_startPosY + 20);
            Point point3 = new Point((int)_startPosX + 75, (int)_startPosY + 50);
            Point point4 = new Point((int)_startPosX + 20, (int)_startPosY + 50);
            Point[] curvePoints = { point1, point2, point3, point4 };
            g.FillPolygon(br, curvePoints);
            g.DrawPolygon(pen, curvePoints);

            Brush br2 = new SolidBrush(Color.WhiteSmoke);
            g.FillRectangle(br2, _startPosX + 70, _startPosY - 10, 15, 30);
            g.DrawRectangle(pen, _startPosX + 70, _startPosY - 10, 15, 30);
        }
    }
 }
