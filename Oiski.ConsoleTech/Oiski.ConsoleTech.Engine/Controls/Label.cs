namespace Oiski.ConsoleTech.Engine.Controls
{
    /// <summary>
    /// Represents a <see cref="Label"/> that can be placed and manipulated through the <see cref="OiskiEngine"/>
    /// </summary>
    public class Label : Control
    {
        private string text = string.Empty;
        /// <summary>
        /// The <see langword="string"/> value inside the <see cref="Label"/> <see cref="Control"/>
        /// </summary>
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;

                Size = new Vector2(value.Length + 2, 3);
            }
        }

        /// <summary>
        /// The size of the <see cref="Label"/> <see cref="Control"/>
        /// </summary>
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
        /// Defines the visible area of the border for the <see cref="Label"/>. 
        /// <br/>
        /// Use the <see cref="BorderArea"/> <see langword="enum"/> to access the individual components of the border through this member
        /// </summary>
        protected bool[] VisibleBorder { get; } = { true, true, true };

        /// <summary>
        /// This ensures that the width of the <see cref="Label"/> always encapsulates the <see cref="Text"/>
        /// </summary>
        protected void CorrectSize ()
        {
            Size = new Vector2(Text.Length + 2, 3); //  Plus two because the border takes up two spaces

            grid = new char[Size.x, Size.y];
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        protected override char[,] Build ()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
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
        /// Initializes a new instance of type <see cref="Label"/> where the <paramref name="_text"/> is set, and adds the <see cref="Control"/> to the <see cref="OiskiEngine.Controls"/>
        /// </summary>
        /// <param name="_text"></param>
        /// <param name="_attachToEngine">Whether or not to attach the <see cref="Control"/> directly to the <see cref="OiskiEngine"/> controls heirachy</param>
        public Label (string _text, bool _attachToEngine = true) : base(_attachToEngine)
        {
            Text = _text;
            Size = new Vector2(Text.Length + 2, 3); //  Plus two because the border takes up two spaces
            Position = new Vector2(0, 0);
        }

        /// <summary>
        /// Initializes a new instance of type <see cref="Label"/> where the <paramref name="_text"/> and <paramref name="_position"/> is set, and adds the <see cref="Control"/> to the <see cref="OiskiEngine.Controls"/>
        /// </summary>
        /// <param name="_text"></param>
        /// <param name="_position"></param>
        /// <param name="_attachToEngine">Whether or not to attach the <see cref="Control"/> directly to the <see cref="OiskiEngine"/> controls heirachy</param>
        public Label (string _text, Vector2 _position, bool _attachToEngine = true) : this(_text, _attachToEngine)
        {
            Position = _position;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>A formated <see langword="string"/> representation for <see langword="this"/> instance</returns>
        public override string ToString ()
        {
            return $"{{{IndexID},{Text}}}";
        }
    }
}
