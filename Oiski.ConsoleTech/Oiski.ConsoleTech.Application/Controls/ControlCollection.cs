using Oiski.ConsoleTech.Engine;
using Oiski.ConsoleTech.Engine.Controls;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oiski.ConsoleTech.Engine.Controls
{
    public class ControlCollection
    {
        private readonly object lockObject = new object();

        private readonly List<Control> controls = new List<Control>();
        private readonly List<SelectableControl> selectableControls = new List<SelectableControl>();

        public Control this[int _index]
        {
            get
            {
                return controls[_index];
            }
        }

        public IReadOnlyList<Control> GetControls
        {
            get
            {
                return controls;
            }
        }

        public IReadOnlyList<SelectableControl> GetSelectableControls
        {
            get
            {
                return selectableControls;
            }
        }

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

        /// <summary>
        /// Search the list of <see cref="Control"/>s for a <see cref="Control"/> that fits the <paramref name="_match"/> conditions.
        /// </summary>
        /// <param name="_match"></param>
        /// <returns>The first occurence that matches the predicate. If not <see cref="Control"/> is found it will return <see langword="null"/></returns>
        public Control FindControl (Predicate<Control> _match)
        {
            return controls.Find(_match);
        }

        /// <summary>
        /// Search for a <see cref="SelectableControl"/> based on the <paramref name="_selectedIndex"/>
        /// </summary>
        /// <param name="_selectedIndex"></param>
        /// <returns>The first occurence that matches the <paramref name="_selectedIndex"/>. If no match is found it will return <see langword="null"/></returns>
        public SelectableControl FindControl (Vector2 _selectedIndex)
        {
            foreach ( SelectableControl control in selectableControls )
            {
                if ( control.SelectedIndex == _selectedIndex )
                {
                    return control;
                }
            }

            return null;
        }
    }
}
