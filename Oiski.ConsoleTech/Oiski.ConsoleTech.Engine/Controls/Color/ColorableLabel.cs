using Oiski.ConsoleTech.Engine.Color.Rendering;
using Oiski.ConsoleTech.Engine.Controls;
using System;

namespace Oiski.ConsoleTech.Engine.Color.Controls
{
    /// <summary>
    /// Represents an extension of the <see cref="Label"/> <see cref="Control"/> that implements the <see cref="IColorableControl"/>
    /// </summary>
    public class ColorableLabel : Label, IColorableControl
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
            /*
                Builds the color grid to lay on top of the actual visual grid that is drawn in the Label control itself.
                This will therefore not alter how the control is rendered but will only define how the color is drawn on top of the control grid.
             */

            char[,] charBuild = base.Build();
            ColorGrid = new RenderColor[grid.GetLength(0), grid.GetLength(1)];

            int textIndex = 0;
            for ( int y = 0; y < ColorGrid.GetLength(1); y++ )  //  Vertical iteration
            {
                for ( int x = 0; x < ColorGrid.GetLength(0); x++ )  //  Horizontal iteration
                {
                    if ( x == 0 || x == ColorGrid.GetLength(0) - 1 )    //  If the current horizontal char is a border piece
                    {
                        if ( y == 0 || y == ColorGrid.GetLength(1) - 1 )    //  If the current char is a corner piece
                        {
                            if ( VisibleBorder[( int ) BorderArea.Corner] ) //  If the border should be rendered
                            {
                                ColorGrid[x, y] = BorderColor;
                            }
                        }
                        else    //  If the current char is a vertical border piece
                        {
                            
                            if ( VisibleBorder[( int ) BorderArea.Vertical] )   //  If the border should be rendered
                            {
                                ColorGrid[x, y] = BorderColor;
                            }
                        }

                    }
                    else if ( y == 0 || y == grid.GetLength(1) - 1 )    //  If the current char is a horizontal border piece
                    {
                        if ( VisibleBorder[( int ) BorderArea.Horizontal] ) //  If the border should be rendered
                        {
                            ColorGrid[x, y] = BorderColor;
                        }
                    }
                    else    //  If the current char is text
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
        /// Initializes a new instance of type <see cref="ColorableLabel"/> where the text and text color + border color is set
        /// </summary>
        /// <param name="_text"></param>
        /// <param name="_textColor"></param>
        /// <param name="_borderColor"></param>
        /// <param name="_attachToEngine">Whether or not to attach <see langword="this"/> <see cref="Control"/> <strong>directly</strong> to the <see cref="OiskiEngine"/></param>
        public ColorableLabel(string _text, RenderColor _textColor, RenderColor _borderColor, bool _attachToEngine = true) : base(_text, _attachToEngine)
        {
            TextColor = _textColor;
            BorderColor = _borderColor;
            //build = Build();
        }

        /// <summary>
        /// Initializes a new instance of type <see cref="ColorableLabel"/> where the text, text color, border color and position is set
        /// </summary>
        /// <param name="_text"></param>
        /// <param name="_textColor"></param>
        /// <param name="_borderColor"></param>
        /// <param name="_position"></param>
        /// <param name="_attachToEngine">Whether or not to attach <see langword="this"/> <see cref="Control"/> <strong>directly</strong> to the <see cref="OiskiEngine"/></param>
        public ColorableLabel(string _text, RenderColor _textColor, RenderColor _borderColor, Vector2 _position, bool _attachToEngine = true) : this(_text, _textColor, _borderColor, _attachToEngine)
        {
            Position = _position;
        }
    }
}
