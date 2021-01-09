using System;

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
        /// Shorthand for <see cref="Vector2"/> (0,0)
        /// </summary>
        public static Vector2 Zero
        {
            get
            {
                return new Vector2(0, 0);
            }
        }

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

        /// <summary>
        /// Compares <paramref name="_a"/> against <paramref name="_b"/> to see if the two <see cref="Vector2"/> contain the same values for <see cref="x"/> and <see cref="y"/>
        /// </summary>
        /// <param name="_a"></param>
        /// <param name="_b"></param>
        /// <returns><see langword="true"/> if the two <see cref="Vector2"/>s contain the same values. Otherwise <see langword="false"/></returns>
        public static bool operator == (Vector2 _a, Vector2 _b)
        {
            return ( _a.x == _b.x ) && ( _a.y == _b.y );
        }

        /// <summary>
        /// Compares <paramref name="_a"/> against <paramref name="_b"/> to see if the two <see cref="Vector2"/> does not contain the same values for <see cref="x"/> and <see cref="y"/>
        /// </summary>
        /// <param name="_a"></param>
        /// <param name="_b"></param>
        /// <returns><see langword="true"/> if the two <see cref="Vector2"/>s does not contain the same values. Otherwise <see langword="false"/></returns>
        public static bool operator != (Vector2 _a, Vector2 _b)
        {
            return ( _a.x != _b.x ) || ( _a.y != _b.y );
        }

        /// <summary>
        /// Compares <see cref="Vector2.x"/> and <see cref="Vector2.y"/> of <paramref name="_a"/> with the corresponding values of <paramref name="_b"/>
        /// </summary>
        /// <param name="_a"></param>
        /// <param name="_b"></param>
        /// <returns><see langword="true"/> of x and y of <paramref name="_a"/> are higher than the corresponding values of <paramref name="_b"/>; Otherwise <see langword="false"/> </returns>
        public static bool operator > (Vector2 _a, Vector2 _b)
        {
            return ( _a.x > _b.x ) && ( _a.y > _b.y );
        }

        /// <summary>
        /// Compares <see cref="Vector2.x"/> and <see cref="Vector2.y"/> of <paramref name="_a"/> with the corresponding values of <paramref name="_b"/>
        /// </summary>
        /// <param name="_a"></param>
        /// <param name="_b"></param>
        /// <returns><see langword="true"/> of x and y of <paramref name="_a"/> are lower than the corresponding values of <paramref name="_b"/>; Otherwise <see langword="false"/> </returns>
        public static bool operator < (Vector2 _a, Vector2 _b)
        {
            return ( _a.x < _b.x ) && ( _a.y < _b.y );
        }

        /// <summary>
        /// Compares <see cref="Vector2.x"/> and <see cref="Vector2.y"/> of <paramref name="_a"/> with the corresponding values of <paramref name="_b"/>
        /// </summary>
        /// <param name="_a"></param>
        /// <param name="_b"></param>
        /// <returns><see langword="true"/> of x and y of <paramref name="_a"/> are higher or equal to the corresponding values of <paramref name="_b"/>; Otherwise <see langword="false"/> </returns>
        public static bool operator >= (Vector2 _a, Vector2 _b)
        {
            return ( _a.x >= _b.x ) && ( _a.y >= _b.y );
        }

        /// <summary>
        /// Compares <see cref="Vector2.x"/> and <see cref="Vector2.y"/> of <paramref name="_a"/> with the corresponding values of <paramref name="_b"/>
        /// </summary>
        /// <param name="_a"></param>
        /// <param name="_b"></param>
        /// <returns><see langword="true"/> of x and y of <paramref name="_a"/> are lower or equal to the corresponding values of <paramref name="_b"/>; Otherwise <see langword="false"/> </returns>
        public static bool operator <= (Vector2 _a, Vector2 _b)
        {
            return ( _a.x <= _b.x ) && ( _a.y <= _b.y );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>A string representation of the current <see cref="Vector2"/> as "<i>(<see cref="x"/>,<see cref="y"/>)</i>"</returns>
        public override string ToString ()
        {
            return $"({x},{y})";
        }

        /// <summary>
        /// Will determine if <see langword="this"/> instance is equal to <paramref name="obj"/>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns><see langword="true"/> if <see langword="this"/> is equal to <paramref name="obj"/>. Otherwise <see langword="false"/></returns>
        public override bool Equals (object obj)
        {
            return obj is Vector2 vector &&
                     x == vector.x &&
                     y == vector.y;
        }

        /// <summary>
        /// Returns the hash code for <see langword="this"/> instance
        /// </summary>
        /// <returns>A 32-bit signed <see langword="integer"/> that is the hash code for <see langword="this"/> instance</returns>
        public override int GetHashCode ()
        {
            return new { x, y }.GetHashCode(); /*HashCode.Combine(x, y);*/
        }

        /// <summary>
        /// Returns the distance between point <paramref name="_a"/> and point <paramref name="_b"/> as a positive <see cref="Vector2"/>
        /// </summary>
        /// <param name="_a"></param>
        /// <param name="_b"></param>
        /// <returns></returns>
        public static Vector2 Distance (Vector2 _a, Vector2 _b)
        {
            int x = _a.x - _b.x;
            x *= Math.Sign(x);

            int y = _a.y - _b.y;
            y *= Math.Sign(x);

            return new Vector2(x, y);
        }

        /// <summary>
        /// Calculates the center position for <see cref="Vector2.x"/> based on the width of a <see cref="Controls.Control"/>.
        /// </summary>
        /// <param name="_controlSizeX"></param>
        /// <returns>A positive <see langword="int"/> representing the positional point for the x component of a <see cref="Vector2"/></returns>
        public static int CenterX (int _controlSizeX)
        {
            return ( int ) ( ( OiskiEngine.Configuration.Size.x / 2F ) - ( _controlSizeX / 2F ) );
        }

        /// <summary>
        /// Calculates the center position for <see cref="Vector2.y"/> based on the width of a <see cref="Controls.Control"/>.
        /// </summary>
        /// <param name="_controlSizeY"></param>
        /// <returns>A positive <see langword="int"/> representing the positional point for the y component of a <see cref="Vector2"/></returns>
        public static int CenterY (int _controlSizeY)
        {
            return ( int ) ( ( OiskiEngine.Configuration.Size.y / 2F ) - ( _controlSizeY / 2F ) );
        }

        /// <summary>
        /// Provides a <see cref="Vector2"/> that represents a horizontal and vertical center position based on a <see cref="Controls.Control"/>s height and width.
        /// </summary>
        /// <param name="_controlSize"></param>
        /// <returns>A new <see cref="Vector2"/> that defines the horizontal and vertical center position for a <see cref="Controls.Control"/> placement on the screen</returns>
        public static Vector2 Center (Vector2 _controlSize)
        {
            return new Vector2(CenterX(_controlSize.x), CenterY(_controlSize.y));
        }
    }
}
