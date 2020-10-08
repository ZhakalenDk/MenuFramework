using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.ConsoleTech.OiskiEngine.Controls
{
    /// <summary>
    /// Represents a <see cref="Label"/> that can be placed and manipulated through the <see cref="MenuEngine"/>
    /// </summary>
    public class Label : Control
    {
        public string Text { get; set; } = string.Empty;

        new public Vector2 Size
        {
            get
            {
                return base.Size;
            }
            protected set
            {
                base.Size = value;
            }
        }

        /// <summary>
        /// This ensures that the width of the <see cref="Label"/> always encapsulates the <see cref="Text"/>
        /// </summary>
        private void CorrectSize ()
        {
            Size = new Vector2(Text.Length + 2, 3);

            #region Legacy Code
            //if ( Size.x < Text.Length )
            //{
            //    Size = new Vector2(Text.Length + 1, Size.y);
            //}

            //if ( Size.y < 3 )
            //{
            //    Size = new Vector2(Size.x, 3);
            //}
            #endregion

            grid = new char[Size.x, Size.y];
        }

        /// <summary>
        /// Defines the visible area of the border for the <see cref="Label"/>. 
        /// <br/>
        /// Use the <see cref="BorderArea"/> <see langword="enum"/> to access the individual components of the border through this member
        /// </summary>
        protected bool[] VisibleBorder { get; } = { true, true, true };

        /// <summary>
        /// Builds the <see cref="Label"/> control
        /// </summary>
        /// <returns>A rendable two-dimensional <see langword="char"/> <see langword="array"/> that can be inserted into the <see cref="Rendering.Renderer"/> <see langword="class"/> via the <see cref="MenuEngine"/></returns>
        internal override char[,] Build ()
        {
            CorrectSize();

            int textIndex = 0;
            for ( int y = 0; y < grid.GetLength(1); y++ )
            {
                for ( int x = 0; x < grid.GetLength(0); x++ )
                {
                    if ( x == 0 || x == grid.GetLength(0) - 1 )
                    {
                        if ( y == 0 || y == grid.GetLength(1) - 1 )
                        {
                            if ( VisibleBorder[( int ) BorderArea.Corner] )
                            {
                                grid[x, y] = border[( int ) BorderArea.Corner];
                            }
                            else
                            {
                                grid[x, y] = ' ';
                            }
                        }
                        else
                        {
                            if ( VisibleBorder[( int ) BorderArea.Vertical] )
                            {
                                grid[x, y] = border[( int ) BorderArea.Vertical];
                            }
                            else
                            {
                                grid[x, y] = ' ';
                            }
                        }

                    }
                    else if ( y == 0 || y == grid.GetLength(1) - 1 )
                    {
                        if ( VisibleBorder[( int ) BorderArea.Horizontal] )
                        {
                            grid[x, y] = border[( int ) BorderArea.Horizontal];
                        }
                        else
                        {
                            grid[x, y] = ' ';
                        }
                    }
                    else
                    {
                        if ( textIndex < Text.Length )
                        {
                            grid[x, y] = Text[textIndex];
                        }

                        textIndex++;
                    }
                }
            }

            return grid;
        }

        /// <summary>
        /// Define which parts of the border that should be visible when the <see cref="Label"/> is rendered
        /// </summary>
        /// <param name="_area"></param>
        /// <param name="_visible"></param>
        public void SetBorder (BorderArea _area, bool _visible)
        {
            VisibleBorder[( int ) _area] = _visible;
        }

        /// <summary>
        /// Change the borde style for the <see cref="Label"/>
        /// </summary>
        /// <param name="_area"></param>
        /// <param name="_style"></param>
        public void BorderStyle (BorderArea _area, char _style)
        {
            border[( int ) _area] = _style;
        }

        /// <summary>
        /// Initializes a new instance of type <see cref="Label"/> where the <paramref name="_text"/> is set, and adds the <see cref="Control"/> to the <see cref="MenuEngine.Controls"/>
        /// </summary>
        /// <param name="_text"></param>
        public Label (string _text) : base()
        {
            Text = _text;
            Size = new Vector2(Text.Length + 2, 3);
            Position = new Vector2(0, 0);
        }

        /// <summary>
        /// Initializes a new instance of type <see cref="Label"/> where the <paramref name="_text"/> and <paramref name="_position"/> is set, and adds the <see cref="Control"/> to the <see cref="MenuEngine.Controls"/>
        /// </summary>
        /// <param name="_text"></param>
        /// <param name="_position"></param>
        public Label (string _text, Vector2 _position) : this(_text)
        {
            Position = _position;
        }
    }
}
