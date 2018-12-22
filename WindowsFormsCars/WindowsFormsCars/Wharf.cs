using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;

namespace WindowsFormsCars
{
    class Wharf<T> : IEnumerator<T>, IEnumerable<T>, IComparable<Wharf<T>>
        where T : class, ITransport
    {
        private Dictionary<int,T> _places;
        private int _maxCount;
        private int PictureWidth { get; set; }
        private int PictureHeight { get; set; }
        private int _placeSizeWidth = 210;
        private int _placeSizeHeight = 80;
        private int _currentIndex;

        public int GetKey
        {
            get
            {
                return _places.Keys.ToList()[_currentIndex];
            }
        }

        public Wharf(int sizes, int pictureWidth, int pictureHeight)
        {
            _maxCount = sizes;
            _places = new Dictionary<int, T>();
            _currentIndex = -1;
            PictureWidth = pictureWidth;
            PictureHeight = pictureHeight;
        }
        public static int operator +(Wharf<T> p, T ship)
        {
            if (p._places.Count == p._maxCount)
            {
                throw new WharfOverflowException();
            }
            if (p._places.ContainsValue(ship))
            {
                throw new ParkingAlreadyHaveException();
            }
            for (int i = 0; i < p._maxCount; i++)
            {
                if (p.CheckFreePlace(i))
                {
                    p._places.Add(i,ship);
                    p._places[i].SetPosition(10 + i / 5 * p._placeSizeWidth + 5, i % 5 * p._placeSizeHeight + 20, p.PictureWidth, p.PictureHeight);
                    return i;
                }
            }
            return -1;
        }

        public static T operator -(Wharf<T> p, int index)
        {
            if (!p.CheckFreePlace(index))
            {
                T ship = p._places[index];
                p._places.Remove(index);
                return ship;
            }
            throw new WharfNotFoundException(index);
        }

        private bool CheckFreePlace(int index)
        {
            return !_places.ContainsKey(index);
        }
        public void Draw(Graphics g)
        {
            DrawMarking(g);
            foreach (var ship in _places)
            {
                ship.Value.DrawShip(g);
            }
        }
        private void DrawMarking(Graphics g)
        {
            Pen pen = new Pen(Color.Black, 3);
            g.DrawRectangle(pen, 0, 0, (_maxCount / 5) * _placeSizeWidth, 480);
            for (int i = 0; i < _maxCount / 5; i++)
            {
                for (int j = 0; j < 6; ++j)
                {
                    g.DrawRectangle(pen, i * _placeSizeWidth, j * _placeSizeHeight, 110, 5 );
                    Brush brGray = new SolidBrush(Color.Gray);
                    g.FillRectangle(brGray, i * _placeSizeWidth, j * _placeSizeHeight, 110, 5);
                }
                g.DrawLine(pen, i * _placeSizeWidth, 0, i * _placeSizeWidth, 400);
            }
        }

        public T this[int ind]
        {
            get
            {
                if (_places.ContainsKey(ind))
                {
                    return _places[ind];
                }

                throw new WharfNotFoundException(ind);
                
            }

            set
            {
                if (CheckFreePlace(ind))
                {
                    _places.Add(ind, value);
                    _places[ind].SetPosition(10 + ind / 5 * _placeSizeWidth + 5, ind % 5 * _placeSizeHeight + 20, PictureWidth, PictureHeight);
                }
                else
                {
                    throw new WharfOccupiedPlaceException(ind);
                }
            }
        }
        public T Current
        {
            get
            {
                return _places[_places.Keys.ToList()[_currentIndex]];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public void Dispose()
        {
            _places.Clear();
        }
        
        public bool MoveNext()
        {         
            if (_currentIndex + 1 >= _places.Count)
            {
                Reset();
                return false;
            }
            _currentIndex++;
            return true;
        }

        public void Reset()
        {
            _currentIndex = -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int CompareTo(Wharf<T> other)
        {
            if(_places.Count > other._places.Count)
            {
                return -1;
            }
            else if(_places.Count < other._places.Count)
            {
                return 1;
            }
            else if(_places.Count > 0)
            {
                var thisKeys = _places.Keys.ToList();
                var otherKeys = other._places.Keys.ToList();
                for (int i =0; i < _places.Count ; ++i)
                {
                    if(_places[thisKeys[i]] is SimpleShip && other._places[thisKeys[i]] is Ship)
                    {
                        return 1;
                    }
                    if (_places[thisKeys[i]] is Ship && other._places[thisKeys[i]] is SimpleShip)
                    {
                        return -1;
                    }
                    if (_places[thisKeys[i]] is SimpleShip && other._places[thisKeys[i]] is SimpleShip)
                    {
                        return (_places[thisKeys[i]] is SimpleShip).CompareTo(other._places[thisKeys[i]] is SimpleShip); ;
                    }
                    if (_places[thisKeys[i]] is Ship && other._places[thisKeys[i]] is Ship)
                    {
                        return (_places[thisKeys[i]] is Ship).CompareTo(other._places[thisKeys[i]] is Ship); ;
                    }
                }
            }
            return 0;
        }
    }
}
