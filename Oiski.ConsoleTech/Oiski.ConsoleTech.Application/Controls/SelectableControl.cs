using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.ConsoleTech.Engine.Controls
{
    /// <summary>
    /// Defines an <see langword="abstract"/> <see langword="class"/> that acts as the base <see cref="Control"/> <see langword="class"/> for all selectedable <see cref="Control"/>s
    /// </summary>
    public abstract class SelectableControl : Label
    {
        /// <summary>
        /// Defines the index heriachy of which any <see cref="SelectableControl"/> is selected in an ascending order.
        /// </summary>
        public Vector2 SelectedIndex { get; set; }

        /// <summary>
        /// Whether or not the <see cref="Control"/> is currently selected
        /// </summary>
        public bool IsSelected { get; private set; } = false;

        /// <summary>
        /// The event that would occur when the <see cref="SelectableControl"/> is selected
        /// <br/>
        /// The <see cref="SelectableControl"/> parameter refers to the current <see cref="SelectableControl"/>
        /// </summary>
        public event Action<SelectableControl> OnSelect;

        public SelectableControl (string _text) : base(_text)
        {
            SelectedIndex = new Vector2(Position.x, Position.y);
        }

        /// <summary>
        /// Will be trickered when the <see cref="SelectableControl"/> is targeted by the <see cref="OiskiEngine.Input"/> selection system
        /// </summary>
        internal void HandleSelectEvent ()
        {
            OnSelect?.Invoke(this);
        }
    }
}
