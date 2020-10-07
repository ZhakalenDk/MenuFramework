using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.ConsoleTech
{
    public struct Vector2
    {
        public readonly int x;
        public readonly int y;

        public Vector2 (int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public override string ToString ()
        {
            return $"({x},{y})";
        }
    }
}
