using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.ConsoleTech.OiskiEngine.Controls
{
    /// <summary>
    /// Defines an <see langword="abstract"/> <see langword="class"/> that can be inherited from.
    /// <br/>
    /// This is the base <see langword="class"/> for all <see cref="Controls"/> in the <see cref="OiskiEngine"/> environment
    /// </summary>
    public abstract class Control
    {
        /// <summary>
        /// The local two-dimensional grid holds the unrendered <i>template</i> for the <see cref="Control"/>
        /// </summary>
        protected char[,] grid = new char[3, 3];
        protected readonly char[] border = { '+', '|', '-' };

        /// <summary>
        /// The ID that defines this <see cref="object"/> in the <see cref="MenuEngine.Controls"/> herirachy
        /// </summary>
        public int IndexID { get; protected set; }
        public Vector2 Size { get; set; }
        public Vector2 Position { get; set; }

        internal abstract char[,] Build ();

        public Control ()
        {
            lock ( this )
            {
                IndexID = MenuEngine.Controls.Count;

                MenuEngine.AddControl(this);
            }
        }
    }
}
