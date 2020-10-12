using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.ConsoleTech.OiskiEngine.Engine.Input
{
    public class KeyBindings
    {
        public ConsoleKey Up { get; set; } = ConsoleKey.UpArrow;
        public ConsoleKey Down { get; set; } = ConsoleKey.DownArrow;
        public ConsoleKey Left { get; set; } = ConsoleKey.LeftArrow;
        public ConsoleKey Right { get; set; } = ConsoleKey.RightArrow;
        public ConsoleKey Select { get; set; } = ConsoleKey.Enter;

        internal ConsoleKey Debug { get; set; } = ConsoleKey.Tab;
    }
}
