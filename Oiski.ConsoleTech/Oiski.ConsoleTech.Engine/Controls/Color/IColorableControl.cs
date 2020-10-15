using Oiski.ConsoleTech.Engine.Color.Rendering;
using Oiski.ConsoleTech.Engine.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oiski.ConsoleTech.Engine.Color.Controls
{
    /// <summary>
    /// Represents a colorable <see cref="Engine.Controls.Control"/>
    /// </summary>
    public interface IColorableControl
    {
        /// <summary>
        /// The <see cref="RenderColor"/> to apply as text color
        /// </summary>
        RenderColor TextColor { get; set; }
        /// <summary>
        /// The <see cref="RenderColor"/> to apply as border color
        /// </summary>
        RenderColor BorderColor { get; set; }

        /// <summary>
        /// The grid that contains the <see cref="RenderColor"/> mappings
        /// </summary>
        RenderColor[,] ColorGrid { get; }
    }
}
