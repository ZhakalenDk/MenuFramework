using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.ConsoleTech.Application.Controls
{
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

        protected bool[] VisibleBorder { get; } = { true, true, true };

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

        public void SetBorder (BorderArea _area, bool _visible)
        {
            VisibleBorder[( int ) _area] = _visible;
        }
        public void BorderStyle (BorderArea _area, char _style)
        {
            border[( int ) _area] = _style;
        }

        public Label (string _text) : base()
        {
            Text = _text;
            Size = new Vector2(Text.Length + 2, 3);
            Position = new Vector2(0, 0);

            IndexID = MenuEngine.Controls.Count;

            MenuEngine.AddControl(this);
        }

        public Label (string _text, Vector2 _position) : this(_text)
        {
            Position = _position;
        }
    }
}
