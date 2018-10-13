using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsCars
{
    class Wharf<T> where T : class, ITransport
    {
        private T[] _places;
        private int PictureWidth { get; set; }
        private int PictureHeight { get; set; }
        private int _placeSizeWidth = 210;
        private int _placeSizeHeight = 80;
        public Wharf(int sizes, int pictureWidth, int pictureHeight)
        {
            _places = new T[sizes];
            PictureWidth = pictureWidth;
            PictureHeight = pictureHeight;
            for (int i = 0; i < _places.Length; i++)
            {
                _places[i] = null;
            }
        }
        public static int operator +(Wharf<T> p, T ship)
        {
            for (int i = 0; i < p._places.Length; i++)
            {
                if (p.CheckFreePlace(i))
                {
                    p._places[i] = ship;
                    p._places[i].SetPosition(10 + i / 5 * p._placeSizeWidth + 5, i % 5 * p._placeSizeHeight + 20, p.PictureWidth, p.PictureHeight);
                    return i;
                }
            }
            return -1;
        }

        public static T operator -(Wharf<T> p, int index)
        {
            if (index < 0 || index > p._places.Length)
            {
                return null;
            }
            if (!p.CheckFreePlace(index))
            {
                T ship = p._places[index];
                p._places[index] = null;
                return ship;
            }
            return null;
        }

        private bool CheckFreePlace(int index)
        {
            return _places[index] == null;
        }
        public void Draw(Graphics g)
        {
            DrawMarking(g);
            for (int i = 0; i < _places.Length; i++)
            {
                if (!CheckFreePlace(i))
                {//если место не пустое      
                    _places[i].DrawShip(g);
                }
            }
        }
        private void DrawMarking(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 3);
            //границы праковки             
            g.DrawRectangle(pen, 0, 0, (_places.Length / 5) * _placeSizeWidth, 480);
            for (int i = 0; i < _places.Length / 5; i++)
            {//отрисовываем, по 5 мест на линии   
                for (int j = 0; j < 6; ++j)
                {//линия рамзетки места     
                    g.DrawRectangle(pen, i * _placeSizeWidth, j * _placeSizeHeight, 110, 5);
                    Brush brGray = new SolidBrush(Color.Gray);
                    g.FillRectangle(brGray, i * _placeSizeWidth, j * _placeSizeHeight, 110, 5);
                    //g.DrawLine(pen, i * _placeSizeWidth, j * _placeSizeHeight, i * _placeSizeWidth + 110, j * _placeSizeHeight);
                }
                g.DrawLine(pen, i * _placeSizeWidth, 0, i * _placeSizeWidth, 400);
            }
        }
    }
}
