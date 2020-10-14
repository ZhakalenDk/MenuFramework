using Oiski.ConsoleTech.Engine.Color.Controls;
using Oiski.ConsoleTech.Engine.Controls;
using Oiski.ConsoleTech.Engine.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oiski.ConsoleTech.Engine.Color.Rendering
{
    public class ColorRenderer : Renderer
    {
        public RenderColor[,] ColorGrid { get; protected set; } = null;

        public RenderColor DefaultColor { get; set; } = new RenderColor(Console.ForegroundColor, Console.BackgroundColor);

        public override void InsertAt (Vector2 _position, char _symbol)
        {
            MatchColor(_position);
            base.InsertAt(_position, _symbol);
        }

        protected virtual void MatchColor (Vector2 _position)
        {
            if ( OiskiEngine.Controls.FindControl(item => item.Position == _position) is IColorableControl control )
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

        protected override void InitGrid (int _x, int _y)
        {
            ColorGrid = new RenderColor[Configuration.Size.x, Configuration.Size.y];
            base.InitGrid(_x, _y);
        }

        protected override void BuildScreenBorder ()
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

        protected override void RenderCharacter (int _xIndex, int _yIndex)
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
