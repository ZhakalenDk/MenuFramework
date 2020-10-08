using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.ConsoleTech.OiskiEngine.Controls
{
    /// <summary>
    /// Defines an <see langword="abstract"/> <see langword="class"/> that acts as the base <see cref="Control"/> <see langword="class"/> for all selectedable <see cref="Control"/>s
    /// </summary>
    public abstract class SelectableControl : Label
    {
        /// <summary>
        /// Defines the index heriachy of which any <see cref="SelectableControl"/> is selected in an ascending order.
        /// </summary>
        public int SelectedIndex { get; set; }

        /// <summary>
        /// Whether or not the <see cref="Control"/> is currently selected
        /// </summary>
        public bool IsSelected { get; private set; } = false;

        /// <summary>
        /// The event that would occur when the <see cref="SelectableControl"/> is selected
        /// </summary>
        public event Action<SelectableControl> OnSelect;

        public SelectableControl (string _text) : base(_text)
        {

        }

        internal void HandleMe ()
        {
            OnSelect?.Invoke(this);
        }
    }
}
