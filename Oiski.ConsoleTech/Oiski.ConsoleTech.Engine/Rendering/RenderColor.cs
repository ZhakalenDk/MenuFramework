using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oiski.ConsoleTech.Engine.Rendering
{
    public struct RenderColor
    {
        public ConsoleColor ForegroundColor { get; set; }
        public ConsoleColor BackgroundColor { get; set; }

        public override string ToString()
        {
            return $"({ForegroundColor}, {BackgroundColor})";
        }

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

        public RenderColor(ConsoleColor _foregroudColor, ConsoleColor _backgroundColor)
        {
            ForegroundColor = _foregroudColor;
            BackgroundColor = _backgroundColor;
        }
    }
}
