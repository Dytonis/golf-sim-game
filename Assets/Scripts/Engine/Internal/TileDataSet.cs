using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Engine.Internal
{
    public class TileDataSet : IEnumerable
    {
        private TileData[][] _set;

        public TileDataSet(int width, int length, BGObject b)
        {
            _set = new TileData[width][];
            for (int i = 0; i < width; i++)
            {
                _set[i] = new TileData[length];
            }

            for (int y = 0; y < GetLength(); y++)
            {
                for (int x = 0; x < GetLengthOfSubArray(y); x++)
                {
                    _set[x][y] = new TileData(b)
                    {
                        Type = 0,
                        Position = new Vector2(x, y)
                    };
                }
            }
        }

        public TileData this[int x, int y]
        {
            get
            {
                return _set[x][y];
            }
            set
            {
                _set[x][y] = value;
            }
        }

        public TileData this[Vector2 p]
        {
            get
            {
                return _set[(int)p.x][(int)p.y];
            }
            set
            {
                _set[(int)p.x][(int)p.y] = value;
            }
        }

        public int GetLength()
        {
            return _set.GetLength(0);
        }
        public int GetLengthOfSubArray(int v)
        {
            return _set[v].GetLength(0);
        }

        public IEnumerator GetEnumerator()
        {
            return _set.GetEnumerator();
        }
    }
}
