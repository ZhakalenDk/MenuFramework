using System;

namespace Oiski.ConsoleTech.Engine.Color.Rendering
{
    /// <summary>
    /// Defines a collection of <see cref="ConsoleColor"/> that maps <see cref="Console.ForegroundColor"/> and <see cref="Console.BackgroundColor"/>
    /// </summary>
    public struct RenderColor
    {
        /// <summary>
        /// The <see cref="ConsoleColor"/> to apply as <see cref="Console.ForegroundColor"/>
        /// </summary>
        public ConsoleColor ForegroundColor { get; set; }
        /// <summary>
        /// The <see cref="ConsoleColor"/> to apply as <see cref="Console.BackgroundColor"/>
        /// </summary>
        public ConsoleColor BackgroundColor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>A formated string representing this <see langword="instance"/> as (<see cref="ForegroundColor"/>, <see cref="BackgroundColor"/>)</returns>
        public override string ToString()
        {
            return $"({ForegroundColor}, {BackgroundColor})";
        }

        /// <summary>
        /// Writes the <see cref="RenderColor"/> into the <see cref="Console"/> with the appropiate color applied as (<see cref="ForegroundColor"/>, <see cref="BackgroundColor"/>)
        /// </summary>
        public void ToConsole()
        {
            Console.Write("(");
            Console.ForegroundColor = ForegroundColor;
            Console.Write($"{ForegroundColor}");
            Console.Write(", ");
            Console.BackgroundColor = BackgroundColor;
            Console.Write($"{BackgroundColor}");
            Console.ResetColor();
            Console.Write(")");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns><see langword="base"/>.Equals(<see langword="object"/>)</returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns><see langword="base"/>.GetHashCode()</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Compares <paramref name="_a"/> to <paramref name="_b"/> for equality
        /// </summary>
        /// <param name="_a"></param>
        /// <param name="_b"></param>
        /// <returns><see langword="true"/> if <paramref name="_a"/>s <see langword="values"/> are equal to the <see langword="values"/> of <paramref name="_b"/>. Otherwise <see langword="false"/></returns>
        public static bool operator ==(RenderColor _a, RenderColor _b)
        {
            return _a.ForegroundColor == _b.ForegroundColor && _a.BackgroundColor == _b.BackgroundColor;
        }
        /// <summary>
        /// Compares <paramref name="_a"/> to <paramref name="_b"/> for inequality
        /// </summary>
        /// <param name="_a"></param>
        /// <param name="_b"></param>
        /// <returns><see langword="true"/> if <paramref name="_a"/>s <see langword="values"/> are not equal to the <see langword="values"/> of <paramref name="_b"/>. Otherwise <see langword="false"/></returns>
        public static bool operator !=(RenderColor _a, RenderColor _b)
        {
            return _a.ForegroundColor != _b.ForegroundColor || _a.BackgroundColor != _b.BackgroundColor;
        }

        /// <summary>
        /// Initialize a new instance of type <see cref="RenderColor"/> where the foregorund and background <see cref="ConsoleColor"/>s are set
        /// </summary>
        /// <param name="_foregroudColor">Represents the <see cref="Console.ForegroundColor"/></param>
        /// <param name="_backgroundColor">Represents the <see cref="Console.BackgroundColor"/></param>
        public RenderColor(ConsoleColor _foregroudColor, ConsoleColor _backgroundColor)
        {
            ForegroundColor = _foregroudColor;
            BackgroundColor = _backgroundColor;
        }
    }
}
