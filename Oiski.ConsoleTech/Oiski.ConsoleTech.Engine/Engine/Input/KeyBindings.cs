using System;

namespace Oiski.ConsoleTech.Engine.Input
{
    /// <summary>
    /// Defines a collection of common keybinds for navigational purposes and selection
    /// </summary>
    public class KeyBindings
    {
        /// <summary>
        /// Defines navigational movement on the positive Y-axis
        /// </summary>
        public ConsoleKey Up { get; set; } = ConsoleKey.UpArrow;
        /// <summary>
        /// Defines navigational movement on the negative Y-axis
        /// </summary>
        public ConsoleKey Down { get; set; } = ConsoleKey.DownArrow;
        /// <summary>
        /// Defines navigational movement on the positive X-axis
        /// </summary>
        public ConsoleKey Left { get; set; } = ConsoleKey.LeftArrow;
        /// <summary>
        /// Defines navigational movement on the negative X-axis
        /// </summary>
        public ConsoleKey Right { get; set; } = ConsoleKey.RightArrow;
        /// <summary>
        /// THe key to press when selecting
        /// </summary>
        public ConsoleKey Select { get; set; } = ConsoleKey.Enter;

        /// <summary>
        /// The key to use for debug functionality
        /// </summary>
        internal ConsoleKey Debug { get; set; } = ConsoleKey.Tab;
    }
}
