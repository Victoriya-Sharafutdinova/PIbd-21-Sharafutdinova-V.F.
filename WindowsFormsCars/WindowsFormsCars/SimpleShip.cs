using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCars
{
    class SimpleShip : Boat, IComparable<SimpleShip>, IEquatable<SimpleShip>
    {       
        protected const int shipWidth = 100;
        protected const int shipHeight = 60;
        public SimpleShip(int maxSpeed, float weight, Color mainColor)
        {
            MaxSpeed = maxSpeed;
            Weight = weight;
            MainColor = mainColor;
        }

        public SimpleShip(string info)
        {
            string[] strs = info.Split(';');
            if (strs.Length == 3)
            {
                MaxSpeed = Convert.ToInt32(strs[0]);
                Weight = Convert.ToInt32(strs[1]);
                MainColor = Color.FromName(strs[2]);
            }
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
        public override string ToString()
        {
            return MaxSpeed + ";" + Weight + ";" + MainColor.Name;
        }
        public int CompareTo(SimpleShip other)
        {
            if (other == null)
            {
                return 1;
            }
            if (MaxSpeed != other.MaxSpeed)
            {
                return MaxSpeed.CompareTo(other.MaxSpeed);
            }
            if (Weight != other.Weight)
            {
                return Weight.CompareTo(other.Weight);
            }
            if (MainColor != other.MainColor)
            {
                MainColor.Name.CompareTo(other.MainColor.Name);
            }
            return 0;
        }

        public bool Equals(SimpleShip other)
        {
            if (other == null)
            {
                return false;
            }
            if (GetType().Name != other.GetType().Name)
            {
                return false;
            }
            if (MaxSpeed != other.MaxSpeed)
            {
                return false;
            }
            if (Weight != other.Weight)
            {
                return false;
            }
            if (MainColor != other.MainColor)
            {
                return false;
            }
            return true;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            SimpleShip shipObj = obj as SimpleShip;
            if (shipObj == null)
            {
                return false;
            }
            else
            {
                return Equals(shipObj);
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
