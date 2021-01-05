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
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public string Text { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public ValueType Value { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

        /// <summary>
        /// Creates a new instance of type <see cref="ListBoxItem{ValueType}"/> where the text and value of the item is set
        /// </summary>
        /// <param name="_text"></param>
        /// <param name="_value"></param>
        public ListBoxItem (string _text, ValueType _value)
        {
            Text = _text;
            Value = _value;
        }
    }
}
