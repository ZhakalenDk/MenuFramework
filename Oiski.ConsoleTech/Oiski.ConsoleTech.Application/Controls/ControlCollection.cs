using Oiski.ConsoleTech.Engine.Controls;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.ConsoleTech.OiskiEngine.Controls
{
    public class ControlCollection
    {
        private readonly object lockObject = new object();

        private List<Control> controls;
        private List<SelectableControl> selectableControls;

        public void AddControl (Control _control)
        {
            lock ( lockObject )
            {
                controls.Add(_control);

                if ( _control is SelectableControl sControl )
                {
                    selectableControls.Add(sControl);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_control"></param>
        /// <returns><see langword="true"/> if the <see cref="Control"/> could be removed, otherwise <see langword="false"/></returns>
        public bool RemoveControl (Control _control)
        {
            bool wasRemoved = false;
            lock ( lockObject )
            {
                wasRemoved = controls.Remove(_control);

                if ( _control is SelectableControl sControl )
                {
                    wasRemoved = selectableControls.Remove(sControl) && wasRemoved;
                }
            }

            return wasRemoved;
        }
    }
}
