using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_3_sem3
{
    public class Matrix<T>
    {
        private Dictionary<string, T> _matrix = new Dictionary<string, T>();
        private int _maxX;
        private int _maxY;
        private int _maxZ;
        private T _nullElement;

        public Matrix(int px, int py, int pz, T nullElementParam)
        {
            _maxX = px;
            _maxY = py;
            _maxZ = pz;
            _nullElement = nullElementParam;
        }

        public T this[int x, int y, int z]
        {
            get
            {
                CheckBounds(x, y, z);
                string key = DictKey(x, y, z);
                if (_matrix.ContainsKey(key))
                {
                    return _matrix[key];
                }
                else
                {
                    return _nullElement;
                }
            }
            set
            {
                CheckBounds(x, y, z);
                string key = DictKey(x, y, z);
                _matrix.Add(key, value);
            }
        }

        void CheckBounds(int x, int y, int z)
        {
            if (x < 0 || x >= _maxX) 
                throw new Exception("x=" + x + " выходит за границы");
            if (y < 0 || y >= _maxY) 
                throw new Exception("y=" + y + " выходит за границы");
            if (z < 0 || z >= _maxZ)
                throw new Exception("z=" + z + " выходит за границы");
        }

        string DictKey(int x, int y, int z)
        {
            return x.ToString() + "_" + y.ToString() + "_" + z.ToString();
        }

        public override string ToString()
        {
            var b = new StringBuilder();
            for (int j = 0; j < _maxY; j++)
            {
                b.Append("[");
                for (int i = 0; i < _maxX; i++)
                {
                    for (int k = 0; k < _maxZ; k++)
                    {
                        var item = this[i, j, k];
                        if (item != null)
                            b.Append($"x:{j};y:{i};z:{k}, item: {item.ToString()}");
                    }
                }
                b.Append("]\n");
            }
            return b.ToString();
        }
    }
}
