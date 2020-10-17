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
        protected char[,] grid = null;
        /// <summary>
        /// The symbols used to construct the border of the <see cref="Control"/>
        /// </summary>
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
        /// <summary>
        /// The <see cref="Vector2"/> size for the <see cref="Control"/>
        /// </summary>
        public Vector2 Size { get; set; } = new Vector2(3, 3);
        /// <summary>
        /// The <see cref="Vector2"/> position in screenspace cordinates
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// Set the <see cref="ZIndex"/> for <see langword="this"/> <see cref="Control"/>
        /// </summary>
        /// <param name="_index"></param>
        public void SetZIndex(int _index)
        {
            ZIndex = ( ( _index < 0 ) ? ( 0 ) : ( _index ) );
        }

        internal abstract char[,] Build();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_attachToEngine">Whether or not to add the contorl directly to the engine</param>
        public Control(bool _attachToEngine = true)
        {
            lock ( OiskiEngine.Controls )
            {
                IndexID = OiskiEngine.Controls.GetControls.Count;
                ZIndex = 1;
                if ( _attachToEngine )
                {
                    OiskiEngine.Controls.AddControl(this);
                }

            }

            if ( grid == null )
            {
                grid = new char[Size.x, Size.y];
            }
        }
    }
}
