using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.ConsoleTech.Application.Controls
{
    public abstract class SelectableControl : Label
    {
        public bool IsSelected { get; private set; } = false;

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
