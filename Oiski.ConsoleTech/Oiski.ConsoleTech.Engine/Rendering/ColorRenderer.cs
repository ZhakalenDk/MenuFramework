using Oiski.ConsoleTech.Engine.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oiski.ConsoleTech.Engine.Rendering
{
    public class ColorRenderer : Renderer
    {
        public RenderColor[,] ColorGrid { get; protected set; } = null;

        public RenderColor DefaultColor { get; set; } = new RenderColor(Console.ForegroundColor, Console.BackgroundColor);

        public override void InsertAt(Vector2 _position, char _symbol)
        {
            if ( OiskiEngine.Controls.FindControl(item => item.Position == _position) is IColorableControl control )
            {
                for ( int y = 0; y < control.ColorGrid.GetLength(1); y++ )
                {
                    for ( int x = 0; x < control.ColorGrid.GetLength(0); x++ )
                    {
                        ColorGrid[x, y] = control.ColorGrid[x, y];
                    }
                }
            }

            base.InsertAt(_position, _symbol);
        }

        public override void InitRenderer()
        {
            base.InitRenderer();
        }

        protected override void InitGrid(int _x, int _y)
        {
            ColorGrid = new RenderColor[Configuration.Size.x, Configuration.Size.y];
            base.InitGrid(_x, _y);
        }

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

        protected override void RenderCharacter(int _xIndex, int _yIndex)
        {
            Console.ForegroundColor = ColorGrid[_xIndex, _yIndex].ForegroundColor;
            Console.BackgroundColor = ColorGrid[_xIndex, _yIndex].BackgroundColor;
            base.RenderCharacter(_xIndex, _yIndex);
            Console.ResetColor();
        }
    }
}
