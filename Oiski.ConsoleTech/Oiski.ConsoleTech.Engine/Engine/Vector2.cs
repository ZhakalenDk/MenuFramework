using System.Collections.Generic;
using System.Runtime.Remoting.Channels;

namespace Oiski.ConsoleTech.Engine
{
    /// <summary>
    /// Defines a two-dimensional Vector with points
    /// </summary>
    public struct Vector2
    {
        /// <summary>
        /// The vectors value on the X-axis
        /// </summary>
        public readonly int x;
        /// <summary>
        /// The vectors value on the Y-Axis
        /// </summary>
        public readonly int y;

        /// <summary>
        /// Initializes a new instance of type <see cref="Vector2"/> where X and Y are set.
        /// </summary>
        /// <param name="_x"></param>
        /// <param name="_y"></param>
        public Vector2(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        /// <summary>
        /// Compares <paramref name="_a"/> against <paramref name="_b"/> to see if the two <see cref="Vector2"/> contain the same values for <see cref="x"/> and <see cref="y"/>
        /// </summary>
        /// <param name="_a"></param>
        /// <param name="_b"></param>
        /// <returns><see langword="true"/> if the two <see cref="Vector2"/>s contain the same values. Otherwise <see langword="false"/></returns>
        public static bool operator ==(Vector2 _a, Vector2 _b)
        {
            return ( _a.x == _b.x ) && ( _a.y == _b.y );
        }

        /// <summary>
        /// Compares <paramref name="_a"/> against <paramref name="_b"/> to see if the two <see cref="Vector2"/> does not contain the same values for <see cref="x"/> and <see cref="y"/>
        /// </summary>
        /// <param name="_a"></param>
        /// <param name="_b"></param>
        /// <returns><see langword="true"/> if the two <see cref="Vector2"/>s does not contain the same values. Otherwise <see langword="false"/></returns>
        public static bool operator !=(Vector2 _a, Vector2 _b)
        {
            return ( _a.x != _b.x ) || ( _a.y != _b.y );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>A string representation of the current <see cref="Vector2"/> as "<i>(<see cref="x"/>,<see cref="y"/>)</i>"</returns>
        public override string ToString()
        {
            return $"({x},{y})";
        }

        /// <summary>
        /// Will determine if <see langword="this"/> instance is equal to <paramref name="obj"/>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns><see langword="true"/> if <see langword="this"/> is equal to <paramref name="obj"/>. Otherwise <see langword="false"/></returns>
        public override bool Equals(object obj)
        {
            return obj is Vector2 vector &&
                     x == vector.x &&
                     y == vector.y;
        }

        /// <summary>
        /// Returns the hash code for <see langword="this"/> instance
        /// </summary>
        /// <returns>A 32-bit signed <see langword="integer"/> that is the hash code for <see langword="this"/> instance</returns>
        public override int GetHashCode()
        {
            return new { x, y }.GetHashCode(); /*HashCode.Combine(x, y);*/
        }
    }
}
