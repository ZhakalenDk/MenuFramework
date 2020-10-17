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
        public bool IsSelected { get; internal set; } = false;

        /// <summary>
        /// The event that would occur when the <see cref="SelectableControl"/> is selected
        /// <br/>
        /// The <see cref="SelectableControl"/> parameter refers to the current <see cref="SelectableControl"/>
        /// </summary>
        public event Action<SelectableControl> OnSelect;

        /// <summary>
        /// Initializes a new instance of type <see cref="SelectableControl"/> where the text is set
        /// </summary>
        /// <param name="_text"></param>
        /// <param name="_attachToEngine">Whether or not to directly attach this <see cref="SelectableControl"/> to the <see cref="OiskiEngine"/></param>
        public SelectableControl (string _text, bool _attachToEngine = true) : base(_text, _attachToEngine)
        {
            int xIndex = ( ( OiskiEngine.Input.HorizontalNavigationEnabled ) ? ( OiskiEngine.Controls.GetSelectableControls.Count ) : ( 0 ) );
            int yIndex = ( ( OiskiEngine.Input.VerticalNavigationEnabled ) ? ( OiskiEngine.Controls.GetSelectableControls.Count ) : ( 0 ) );

            SelectedIndex = new Vector2(xIndex, yIndex);
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
