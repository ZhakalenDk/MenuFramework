using Oiski.ConsoleTech.Engine.Color.Controls;
using Oiski.ConsoleTech.Engine.Controls;
using Oiski.ConsoleTech.Engine.Rendering;
using System;

namespace Oiski.ConsoleTech.Engine.Color.Rendering
{
    /// <summary>
    /// Represents an extension of the basic <see cref="Renderer"/> that can render colors in the <see cref="Console"/> windows
    /// <br/>
    /// <strong>Note:</strong> the <see cref="ColorRenderer"/> can still render <see cref="Control"/>s that does not implement the <see cref="IColorableControl"/> <see langword="interface"/>
    /// </summary>
    public class ColorRenderer : Renderer
    {
        /// <summary>
        /// The <see cref="RenderColor"/> mapping that matches the <see cref="Renderer.Grid"/> <see langword="chars"/>
        /// </summary>
        public RenderColor[,] ColorGrid { get; protected set; } = null;

        /// <summary>
        /// The default <see cref="RenderColor"/> to apply to the screenspace
        /// <br/>
        /// <strong>Note:</strong> <see cref="RenderColor.ForegroundColor"/> is applied as border <see cref="ConsoleColor"/>, where as <see cref="RenderColor.BackgroundColor"/> is the screenspace <see cref="ConsoleColor"/>
        /// </summary>
        public RenderColor DefaultColor { get; set; } = new RenderColor(Console.ForegroundColor, Console.BackgroundColor);

        /// <summary>
        /// Inserts a <see langword="char"/> <see langword="value"/> into the <see cref="Renderer.Grid"/> and maps the appropriate <see cref="RenderColor"/>
        /// </summary>
        /// <param name="_position"></param>
        /// <param name="_symbol"></param>
        public override void InsertAt(Vector2 _position, char _symbol)
        {
            MatchColor(_position);
            base.InsertAt(_position, _symbol);
        }

        /// <summary>
        /// Maps the entire <see cref="Control"/> if it implements <see cref="IColorableControl"/>. Otherwise it ignores the <see cref="Control"/>
        /// </summary>
        /// <param name="_position"></param>
        protected virtual void MatchColor(Vector2 _position)
        {
            if ( OiskiEngine.Controls.FindControl(item => item.Position == _position && item.Render == true) is IColorableControl control )
            {
                int xAxis = _position.x + BorderThickness_X;
                int yAxis = _position.y + BorderThickness_Y;

                for ( int y = 0; y < control.ColorGrid.GetLength(1); y++ )
                {
                    for ( int x = 0; x < control.ColorGrid.GetLength(0); x++ )
                    {
                        if ( xAxis >= 1 && xAxis <= ( ColorGrid.GetLength(0) - ( BorderThickness_X + 1 ) ) && yAxis >= 1 && yAxis <= ( ColorGrid.GetLength(1) - ( BorderThickness_Y + 1 ) ) )
                        {
                            ColorGrid[xAxis, yAxis] = control.ColorGrid[x, y];
                        }
                        xAxis++;
                    }

                    yAxis++;
                    xAxis = _position.x + BorderThickness_X;
                }
            }
        }

        /// <summary>
        /// Initiates the <see cref="Renderer.Grid"/> and <see cref="ColorGrid"/>
        /// </summary>
        /// <param name="_x"></param>
        /// <param name="_y"></param>
        protected override void InitGrid(int _x, int _y)
        {
            ColorGrid = new RenderColor[Configuration.Size.x, Configuration.Size.y];
            base.InitGrid(_x, _y);
        }

        /// <summary>
        /// Builds the screens border with <see cref="RenderColor"/>s then builds the <see langword="base"/> border of <see langword="chars"/>
        /// </summary>
        protected override void BuildScreenBorder()
        {
            for ( int y = 0; y < ColorGrid.GetLength(1); y++ )
            {
                for ( int x = 0; x < ColorGrid.GetLength(0); x++ )
                {
                    ColorGrid[x, y] = DefaultColor;
                }
            }

            base.BuildScreenBorder();
        }

        /// <summary>
        /// Renders a specific <see langword="char"/> <see langword="value"/> and applies the matching mapped <see cref="RenderColor"/>s from the <see cref="ColorGrid"/>[<paramref name="_xIndex"/>, <paramref name="_yIndex"/>]
        /// </summary>
        /// <param name="_xIndex">The X index in the <see cref="ColorGrid"/></param>
        /// <param name="_yIndex">THe Y index in the <see cref="ColorGrid"/></param>
        protected override void RenderCharacter(int _xIndex, int _yIndex)
        {
            if ( _yIndex == 0 )
            {
                Console.ForegroundColor = ColorGrid[_xIndex, _yIndex].ForegroundColor;
                Console.BackgroundColor = ColorGrid[_xIndex, _yIndex].BackgroundColor;
            }
            else if ( _yIndex != 0 || Grid[_xIndex - ( ( _xIndex - 1 < 0 ) ? ( 0 ) : ( 1 ) ), _yIndex] == ' ' )
            {
                RenderColor oldColor = ColorGrid[_xIndex - ( ( _xIndex - 1 < 0 ) ? ( 0 ) : ( 1 ) ), _yIndex];
                RenderColor newColor = ColorGrid[_xIndex, _yIndex];

                if ( newColor != oldColor )
                {
                    Console.ForegroundColor = ColorGrid[_xIndex, _yIndex].ForegroundColor;
                    Console.BackgroundColor = ColorGrid[_xIndex, _yIndex].BackgroundColor;
                }
            }

            base.RenderCharacter(_xIndex, _yIndex);

            if ( _xIndex < ColorGrid.GetLength(0) - BorderThickness_X && _yIndex < ColorGrid.GetLength(1) - BorderThickness_Y )
            {
                if ( ColorGrid[_xIndex + 1, _yIndex] != ColorGrid[_xIndex, _yIndex] || ColorGrid[_xIndex + 1, _yIndex] != ColorGrid[_xIndex, _yIndex] )
                {
                    Console.ResetColor();
                }

            }
        }
    }
}
