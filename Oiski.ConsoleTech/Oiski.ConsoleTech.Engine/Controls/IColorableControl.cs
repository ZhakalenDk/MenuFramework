using Oiski.ConsoleTech.Engine.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oiski.ConsoleTech.Engine.Controls
{
    public interface IColorableControl
    {
        RenderColor TextColor { get; set; }
        RenderColor BorderColor { get; set; }

        RenderColor[,] ColorGrid { get; }
    }
}
