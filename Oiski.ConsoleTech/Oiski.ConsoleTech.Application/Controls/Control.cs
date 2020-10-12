using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.ConsoleTech.Engine.Controls
{
    /// <summary>
    /// Defines an <see langword="abstract"/> <see langword="class"/> that can be inherited from.
    /// <br/>
    /// This is the base <see langword="class"/> for all <see cref="Controls"/> in the <see cref="ConsoleTech.Engine"/> environment
    /// </summary>
    public abstract class Control
    {
        /// <summary>
        /// The local two-dimensional grid holds the unrendered <i>template</i> for the <see cref="Control"/>
        /// </summary>
        protected char[,] grid = new char[3, 3];
        protected readonly char[] border = { '+', '|', '-' };

        /// <summary>
        /// The ID that defines this <see cref="object"/> in the <see cref="OiskiEngine.Controls"/> herirachy
        /// </summary>
        public int IndexID { get; protected set; }
        /// <summary>
        /// This is the index identifier that determines in which order controls should be rendered.
        /// <br/>
        /// <strong>Note: </strong>Lower numbers will render <strong>on top</strong> of higher numbers.
        /// </summary>
        public int ZIndex { get; internal set; }
        public Vector2 Size { get; set; }
        public Vector2 Position { get; set; }

        public void SetZIndex (int _index)
        {
            ZIndex = ( ( _index < 0 ) ? ( 0 ) : ( _index ) );
        }

        internal abstract char[,] Build ();

        public Control ()
        {
            lock ( OiskiEngine.Controls )
            {
                IndexID = OiskiEngine.Controls.Count;
                ZIndex = 1;

                OiskiEngine.AddControl(this);
            }
        }
    }
}
