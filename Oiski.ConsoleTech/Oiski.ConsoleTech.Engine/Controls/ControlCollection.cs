using System;
using System.Collections.Generic;

namespace Oiski.ConsoleTech.Engine.Controls
{
    /// <summary>
    /// Defines a collection of <see cref="Control"/>s that can be added to and removed from
    /// </summary>
    public class ControlCollection
    {
        /// <summary>
        /// Use this to <see langword="lock"/> internal values when changing them
        /// </summary>
        private readonly object lockObject = new object();

        private readonly List<Control> controls = new List<Control>();
        private readonly List<SelectableControl> selectableControls = new List<SelectableControl>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_index"></param>
        /// <returns>The <see cref="Control"/> with index of <paramref name="_index"/></returns>
        public Control this[int _index]
        {
            get
            {
                return controls[_index];
            }
        }

        /// <summary>
        /// Returns an <see cref="IReadOnlyList{T}"/> containing all <see cref="Control"/>s in the <see cref="ControlCollection"/>
        /// </summary>
        public IReadOnlyList<Control> GetControls
        {
            get
            {

                return controls;
            }
        }

        /// <summary>
        /// Returns an <see cref="IReadOnlyList{T}"/> containing all <see cref="SelectableControl"/>s in the <see cref="ControlCollection"/>
        /// </summary>
        public IReadOnlyList<SelectableControl> GetSelectableControls
        {
            get
            {

                return selectableControls;

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns><see langword="true"/> if there's no <see cref="Control"/>s in the <see cref="ControlCollection"/>. Otherwise <see langword="false"/></returns>
        public bool IsEmpty()
        {
            lock ( lockObject )
            {
                return controls.Count <= 0;
            }

        }

        /// <summary>
        /// Add a <see cref="Control"/> to the <see cref="ControlCollection"/>
        /// </summary>
        /// <param name="_control"></param>
        /// <exception cref="NullReferenceException"/>
        public void AddControl(Control _control)
        {
            lock ( lockObject )
            {
                if ( _control != null )
                {
                    _control.IndexID = controls.Count;
                    controls.Add(_control);

                    if ( _control is SelectableControl sControl )
                    {
                        selectableControls.Add(sControl);
                    }
                }
                else
                {
                    throw new NullReferenceException("Control can't be null when adding it to an instance of type Menu");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_control"></param>
        /// <returns><see langword="true"/> if the <see cref="Control"/> could be removed, otherwise <see langword="false"/></returns>
        public bool RemoveControl(Control _control)
        {
            bool wasRemoved = false;
            lock ( lockObject )
            {
                if ( _control != null )
                {
                    wasRemoved = controls.Remove(_control);

                    if ( _control is SelectableControl sControl )
                    {
                        wasRemoved = selectableControls.Remove(sControl) && wasRemoved;
                    }
                }
                else
                {
                    throw new NullReferenceException("Control can't be null when removing it from an instance of type Menu");
                }
            }

            return wasRemoved;
        }

        /// <summary>
        /// Search the list of <see cref="Control"/>s for a <see cref="Control"/> that fits the <paramref name="_match"/> conditions.
        /// </summary>
        /// <param name="_match"></param>
        /// <returns>The first occurence that matches the predicate. If no <see cref="Control"/> is found it will return <see langword="null"/></returns>
        public Control FindControl(Predicate<Control> _match)
        {
            return controls.Find(_match);
        }

        /// <summary>
        /// Search for a <see cref="SelectableControl"/> based on the <paramref name="_selectedIndex"/>
        /// </summary>
        /// <param name="_selectedIndex"></param>
        /// <returns>The first occurence that matches the <paramref name="_selectedIndex"/>. If no match is found it will return <see langword="null"/></returns>
        public SelectableControl FindControl(Vector2 _selectedIndex)
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
