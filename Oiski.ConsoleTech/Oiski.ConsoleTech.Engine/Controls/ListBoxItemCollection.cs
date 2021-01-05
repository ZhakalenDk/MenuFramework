using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oiski.ConsoleTech.Engine.Controls
{
    /// <summary>
    /// Defines a collection of <see cref="ListBoxItem{ValueType}"/> that can be iterated
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ListBoxItemCollection<T> : IEnumerable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_index"></param>
        /// <returns>An instance of type <see cref="ListBoxItem{ValueType}"/> from the <see cref="ListBoxItemCollection{T}"/> at the specified <paramref name="_index"/></returns>
        public ListBoxItem<T> this[int _index]
        {
            get
            {
                return items[_index];
            }
        }
        /// <summary>
        /// The amount of items currently in the collection
        /// </summary>
        public int Count
        {
            get
            {
                return items.Count;
            }
        }
        private readonly List<ListBoxItem<T>> items = new List<Controls.ListBoxItem<T>>();

        /// <summary>
        /// Adds <paramref name="_item"/> to the collection
        /// </summary>
        /// <param name="_item">The item to add</param>
        public void AddItem (ListBoxItem<T> _item)
        {
            items.Add(_item);
        }

        /// <summary>
        /// Creates and adds a new <see cref="ListBoxItem{ValueType}"/> where the text and value is set
        /// </summary>
        /// <param name="_Text"></param>
        /// <param name="_value"></param>
        public void AddItem (string _Text, T _value)
        {
            AddItem(new ListBoxItem<T>(_Text, _value));
        }

        /// <summary>
        /// Remove a <see cref="ListBoxItem{ValueType}"/> from the collection at the specified <paramref name="_index"/>
        /// </summary>
        /// <param name="_index"></param>
        public void RemoveItemAt (int _index)
        {
            items.RemoveAt(_index);
        }

        /// <summary>
        /// Remove a <paramref name="_item"/> from the collection
        /// </summary>
        /// <param name="_item"></param>
        /// <returns></returns>
        public bool RemoveItem (ListBoxItem<T> _item)
        {
            return items.Remove(_item);
        }

        /// <summary>
        /// Searches the collection for an item with a value that matches <paramref name="_value"/>
        /// </summary>
        /// <param name="_value"></param>
        /// <returns>The first occurence where the <see cref="ListBoxItem{ValueType}.Value"/> = <paramref name="_value"/></returns>
        public ListBoxItem<T> FindBy (T _value)
        {

            return items.Find(item => Equals(item.Value, _value));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>An enumerator that iterates over the <see cref="ListBoxItemCollection{T}"/></returns>
        public IEnumerator<ListBoxItem<T>> GetEnumerator ()
        {
            foreach ( ListBoxItem<T> item in items )
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator ()
        {
            return GetEnumerator();
        }
    }
}