using Oiski.ConsoleTech.Engine.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oiski.ConsoleTech.Engine.Controls
{
    public class ColorableLabel : Label, IColorableControl
    {
        public RenderColor TextColor { get; set; }
        public RenderColor[,] ColorGrid { get; private set; }
        public RenderColor BorderColor { get; set; }

        public char[,] build;

        internal override char[,] Build()
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

        public ColorableLabel(string _text, RenderColor _textColor, RenderColor _borderColor, bool _attachToEngine = true) : base(_text, _attachToEngine)
        {
            TextColor = _textColor;
            BorderColor = _borderColor;
            build = Build();
        }
    }
}
