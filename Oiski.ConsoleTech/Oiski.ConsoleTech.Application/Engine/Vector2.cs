using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.ConsoleTech.OiskiEngine
{
    /// <summary>
    /// Defines a two-dimensional Vector with points
    /// </summary>
    public struct Vector2
    {
        public readonly int x;
        public readonly int y;

        /// <summary>
        /// Initializes a new instance of type <see cref="Vector2"/> where X and Y are set.
        /// </summary>
        /// <param name="_x"></param>
        /// <param name="_y"></param>
        public Vector2 (int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public static bool operator == (Vector2 _a, Vector2 _b)
        {
            return ( _a.x == _b.x ) && ( _a.y == _b.y );
        }

        public static bool operator != (Vector2 _a, Vector2 _b)
        {
            return ( _a.x != _b.x ) || ( _a.y != _b.y );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>A string representation of the current <see cref="Vector2"/> as "<i>(<see cref="x"/>,<see cref="y"/>)</i>"</returns>
        public override string ToString ()
        {
            return $"({x},{y})";
        }

        public override bool Equals (object obj)
        {
            return obj is Vector2 vector &&
                     x == vector.x &&
                     y == vector.y;
        }

        public override int GetHashCode ()
        {
            return HashCode.Combine(x, y);
        }
    }
}
