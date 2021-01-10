using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oiski.ConsoleTech.Engine.Controls
{
    /// <summary>
    /// Defines an item that can be stored in a <see cref="ListBoxItemCollection{T}"/>
    /// </summary>
    /// <typeparam name="ValueType"></typeparam>
    public class ListBoxItem<ValueType>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_index"></param>
        /// <returns>the <see langword="char"/> indexed at <paramref name="_index"/> in <see cref="Text"/></returns>
        public char this[int _index]
        {
            get
            {
                return Text[_index];
            }
        }
        /// <summary>
        /// The text that will be displayed in a listbox
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// The value saved with this <see cref="ListBoxItem{ValueType}"/>
        /// </summary>
        public ValueType Value { get; set; }

        /// <summary>
        /// Creates a new instance of type <see cref="ListBoxItem{ValueType}"/> where the text and value of the item is set
        /// </summary>
        /// <param name="_text">The text that will be displayed in the listbox</param>
        /// <param name="_value">The value to save inside the <see cref="ListBoxItem{ValueType}"/></param>
        public ListBoxItem (string _text, ValueType _value)
        {
            Text = _text;
            Value = _value;
        }
    }
}
