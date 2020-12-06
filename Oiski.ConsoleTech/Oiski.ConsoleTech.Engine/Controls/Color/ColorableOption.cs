using Oiski.ConsoleTech.Engine.Color.Rendering;
using Oiski.ConsoleTech.Engine.Controls;
using System;

namespace Oiski.ConsoleTech.Engine.Color.Controls
{
    /// <summary>
    /// Represents an extension of the <see cref="Option"/> <see cref="Control"/> that implements the <see cref="IColorableControl"/>
    /// </summary>
    public class ColorableOption : Option, IColorableControl
    {
        /// <summary>
        /// The <see cref="RenderColor"/> to apply as text color in the <see cref="Console"/>
        /// </summary>
        public RenderColor TextColor { get; set; }
        /// <summary>
        /// The <see cref="RenderColor"/> to apply as border color in the <see cref="Console"/>
        /// </summary>
        public RenderColor BorderColor { get; set; }
        /// <summary>
        /// The grid that contains the <see cref="RenderColor"/> mappings for <see langword="this"/> <see cref="Control"/>
        /// </summary>
        public RenderColor[,] ColorGrid { get; protected set; } = new RenderColor[1, 1];

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        protected override char[,] Build()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            char[,] charBuild = base.Build();
            ColorGrid = new RenderColor[grid.GetLength(0), grid.GetLength(1)];

            int textIndex = 0;
            for ( int y = 0; y < ColorGrid.GetLength(1); y++ )
            {
                for ( int x = 0; x < ColorGrid.GetLength(0); x++ )
                {
                    if ( x == 0 || x == ColorGrid.GetLength(0) - 1 )
                    {
                        if ( y == 0 || y == ColorGrid.GetLength(1) - 1 )
                        {
                            if ( VisibleBorder[( int ) BorderArea.Corner] )
                            {
                                ColorGrid[x, y] = BorderColor;
                            }
                        }
                        else
                        {
                            if ( VisibleBorder[( int ) BorderArea.Vertical] )
                            {
                                ColorGrid[x, y] = BorderColor;
                            }
                        }

                    }
                    else if ( y == 0 || y == grid.GetLength(1) - 1 )
                    {
                        if ( VisibleBorder[( int ) BorderArea.Horizontal] )
                        {
                            ColorGrid[x, y] = BorderColor;
                        }
                    }
                    else
                    {
                        if ( textIndex < Text.Length )
                        {
                            ColorGrid[x, y] = TextColor;
                        }

                        textIndex++;
                    }
                }
            }

            return charBuild;
        }

        /// <summary>
        /// Initializes a new instance of type <see cref="ColorableOption"/> where the text and text color + border color is set
        /// </summary>
        /// <param name="_text"></param>
        /// <param name="_textColor"></param>
        /// <param name="_borderColor"></param>
        /// <param name="_attachToEngine">Whether or not to attach <see langword="this"/> <see cref="Control"/> <strong>directly</strong> to the <see cref="OiskiEngine"/></param>
        public ColorableOption(string _text, RenderColor _textColor, RenderColor _borderColor, bool _attachToEngine = true) : base(_text, _attachToEngine)
        {
            TextColor = _textColor;
            BorderColor = _borderColor;
        }

        /// <summary>
        /// Initializes a new instance of type <see cref="ColorableOption"/> where the text, text color, border color and position is set
        /// </summary>
        /// <param name="_text"></param>
        /// <param name="_textColor"></param>
        /// <param name="_borderColor"></param>
        /// <param name="_position"></param>
        /// <param name="_attachToEngine">Whether or not to attach <see langword="this"/> <see cref="Control"/> <strong>directly</strong> to the <see cref="OiskiEngine"/></param>
        public ColorableOption(string _text, RenderColor _textColor, RenderColor _borderColor, Vector2 _position, bool _attachToEngine = true) : this(_text, _textColor, _borderColor, _attachToEngine)
        {
            Position = _position;
        }
    }
}
