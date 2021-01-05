using System;
using System.Collections;
using System.Collections.Generic;

namespace Oiski.ConsoleTech.Engine.Controls
{
    /// <summary>
    /// Represents a <see cref="ControlCollection"/> that can't be added to or removed from
    /// </summary>
    public interface IReadOnlyControlCollection : IEnumerable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_index"></param>
        /// <returns>The <see cref="Control"/> at the specified <paramref name="_index"/></returns>
        Control this[int _index] { get; }

        /// <summary>
        /// Get all <see cref="Control"/>s in the collection
        /// </summary>
        IReadOnlyList<Control> GetControls { get; }
        /// <summary>
        /// Get all <see cref="SelectableControl"/>s in the collection
        /// </summary>
        IReadOnlyList<SelectableControl> GetSelectableControls { get; }

        /// <summary>
        /// Find and return the first occurence that matches the specified predicate condition
        /// </summary>
        /// <param name="_match"></param>
        /// <returns>The first occurence that matches the predicate</returns>
        Control FindControl (Predicate<Control> _match);

        /// <summary>
        /// Find and return the first occurence that matches the specified <see cref="Vector2"/> index.
        /// </summary>
        /// <param name="_selectedIndex"></param>
        /// <returns>The first occurence where the selected index matches <paramref name="_selectedIndex"/></returns>
        SelectableControl FindControl (Vector2 _selectedIndex);

        /// <summary>
        /// 
        /// </summary>
        /// <returns><see langword = "true" /> if there's no <see cref="Control"/>s in the <see cref="IReadOnlyControlCollection"/>. Otherwise <see langword="false"/></returns>
        bool IsEmpty ();
    }
}