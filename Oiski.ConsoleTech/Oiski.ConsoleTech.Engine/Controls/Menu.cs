using System;

namespace Oiski.ConsoleTech.Engine.Controls
{
    /// <summary>
    /// Represents a menu with <see cref="Control"/>s that can be shown or hidden
    /// </summary>
    public class Menu : Control
    {
        /// <summary>
        /// The <see cref="Vector2"/> size for the <see cref="Control"/>
        /// </summary>
        new public Vector2 Size { get; protected set; }
        /// <summary>
        /// The <see cref="Vector2"/> position in screenspace cordinates
        /// </summary>
        new public Vector2 Position { get; protected set; }
        /// <summary>
        /// The collection of controls, which are directly connected to <see langword="this"/> <see cref="Menu"/> instance
        /// </summary>
        public ControlCollection Controls { get; } = new ControlCollection();
        /// <summary>
        /// Whether or not the <see cref="Menu"/> <see cref="Control"/> should be rendered or not
        /// </summary>
        new public bool Render
        {
            get
            {
                return base.Render;
            }

            protected set
            {
                base.Render = value;
            }
        }

        /// <summary>
        /// The <see langword="event"/> that is triggered when a <see cref="SelectableControl"/> is targeted by the <see cref="OiskiEngine"/>s <see cref="Input.InputController"/>
        /// </summary>
        public Action<SelectableControl> OnTarget { get; set; } = null;

        /// <summary>
        /// If <paramref name="_visible"/> is <see langword="true"/> the <see cref="Menu"/> will be rendered by the <see cref="OiskiEngine"/>. Otherwise it will not be rendered
        /// </summary>
        /// <param name="_visible"></param>
        public void Show (bool _visible = true)
        {
            foreach ( var control in Controls.GetControls )
            {
                if ( _visible )
                {
                    OiskiEngine.Controls.AddControl(control);
                }
                else
                {
                    OiskiEngine.Controls.RemoveControl(control);
                }
            }
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        protected override char[,] Build ()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            if ( Render )
            {
                for ( int i = 0; i < grid.GetLength(1); i++ )
                {
                    for ( int j = 0; j < grid.GetLength(0); j++ )
                    {
                        grid[j, i] = '*';
                    }
                }
            }
            else
            {
                grid = new char[0, 0];
            }

            return grid;
        }

        /// <summary>
        /// Initializes a new instance of type <see cref="Menu"/>
        /// </summary>
        public Menu () : base()
        {
            Size = new Vector2(Console.WindowWidth - 1, Console.WindowHeight - 1);
            grid = new char[Size.x, Size.y];
            Render = false;

            if ( OnTarget == null )
            {
                OnTarget = MarkTarget;
            }

            OiskiEngine.Input.AtTarget = OnTarget;
        }

        /// <summary>
        /// The default behavior attached ot <see cref="OnTarget"/>
        /// </summary>
        /// <param name="_me"></param>
        protected virtual void MarkTarget (SelectableControl _me)
        {
            foreach ( SelectableControl control in OiskiEngine.Controls.GetSelectableControls )
            {
                if ( control == _me )
                {
                    _me.BorderStyle(BorderArea.Horizontal, '~');
                }
                else /*if ( control is SelectableControl sControl )*/
                {
                    control.BorderStyle(BorderArea.Horizontal, '-');
                }
            }
        }
    }
}
