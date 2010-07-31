/*

WeK - A magic packet Wake On LAN Utility for Microsoft Windows.
Copyright © 2010 Chris Dickson

WeK is free software; you can redistribute it and/or modify 
it under the terms of the GNU General Public License as 
published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.

WeK is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

*/

#region Using Statements

using System;
using System.Collections.ObjectModel;

#endregion

namespace Madcow.ComponentModel
{
    /// <summary>
    /// Class extending a generic collection to raise events when the list is changed.
    /// </summary>
    /// <typeparam name="T">The type of objects stored in the collection.</typeparam>
    public class ObservableCollection<T> : Collection<T>
        where T : class
    {
        #region Public Events

        /// <summary>
        /// Event raised when the collection is changed.
        /// </summary>
        public event EventHandler ListChanged;

        #endregion

        #region Public Properties

        /// <summary>
        /// Indexer providing access to specific items in the collection.
        /// </summary>
        /// <param name="index">The numeric position of the item in the collection.</param>
        /// <returns>The item at the given position, or null.</returns>
        public new T this[int index]
        {
            get { return base[index]; }
            set
            {
                base[index] = value;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds an item of type <typeparamref name="T"/> to the collection.
        /// </summary>
        /// <param name="item">The item to be added.</param>
        public new void Add(T item)
        {
            base.Add(item);
            OnListChanged();
        }

        /// <summary>
        /// Finds an item in the collection using the predicate function.
        /// </summary>
        /// <param name="predicate">The predicate used for searching.</param>
        /// <returns>The first item matching the predicate, or the default if no item matches.</returns>
        public T Find(Predicate<T> predicate)
        {
            T FoundItem = default(T);
            for (int i = 0; i < base.Items.Count; i++)
            {
                if (predicate(base.Items[i]))
                {
                    FoundItem = base.Items[i];
                    break;
                }
            }

            return FoundItem;
        }

        /// <summary>
        /// Inserts an item of type <typeparamref name="T"/> into the collection at the specified position.
        /// </summary>
        /// <param name="index">The position within the collection at which the item is to be inserted.</param>
        /// <param name="item">The item to be inserted into the collection.</param>
        public new void Insert(int index, T item)
        {
            base.Insert(index, item);
            OnListChanged();
        }

        /// <summary>
        /// Removes the given item from the collection, if it exists.
        /// </summary>
        /// <param name="item">The item to be removed from the collection.</param>
        public new void Remove(T item)
        {
            base.Remove(item);
            OnListChanged();
        }

        /// <summary>
        /// Removes the item at the specified position within the collection.
        /// </summary>
        /// <param name="index">The position of the item that is to be removed.</param>
        public new void RemoveAt(int index)
        {
            base.RemoveAt(index);
            OnListChanged();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Raises the ListChanged event.
        /// </summary>
        protected virtual void OnListChanged()
        {
            EventHandler Handler = ListChanged;

            if (Handler != null)
            {
                // Raise the event.
                ListChanged(this, null);
            }
        }

        #endregion
    }
}
