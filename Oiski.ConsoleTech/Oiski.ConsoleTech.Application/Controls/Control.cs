using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.ConsoleTech.Application.Controls
{
    public abstract class Control
    {
        protected char[,] grid = new char[3, 3];
        protected readonly char[] border = { '+', '|', '-' };

        public int IndexID { get; protected set; }
        public Vector2 Size { get; set; }
        public Vector2 Position { get; set; }

        internal abstract char[,] Build ();
    }
}
