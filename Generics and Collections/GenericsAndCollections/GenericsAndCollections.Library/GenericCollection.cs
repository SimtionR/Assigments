using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsAndCollections.Library
{
    public class GenericCollection<T> : ISetItem<T>, IGetItem<T>, ISwapItems<T>
    {
        private readonly int _maximumSize;
        private T[] _items;

        public GenericCollection(T[] items)
        {
            _items = items;
            _maximumSize = items.Length;
        }

        public T GetItem(int index)
        {
            if(index <0)
            {
                throw new InvalidOperationException();
            }
            if(index >= _maximumSize)
            {
                throw  new IndexOutOfRangeException();
            }


            return _items[index];
            
        }

        public void SetItem(T item, int index)
        {
            if (index < 0)
            {
                throw new InvalidOperationException();
            }
            if (index >= _maximumSize)
            {
                throw new IndexOutOfRangeException();
            }

            _items[index] = item;
        }

        public void SwapItems(T firstItem, T secondItem)
        {
            var firstIndex = Array.FindIndex(_items, x => x.Equals(firstItem));

            var secondIndex =Array.FindIndex(_items, x => x.Equals(secondItem));

            _items[firstIndex] = secondItem;
            _items[secondIndex] = firstItem;
        }

        public void SwapItemsByIndex(int firstItemIndex, int secondItemIndex)
        {

            if (firstItemIndex < 0 || secondItemIndex < 0)
            {
                throw new InvalidOperationException();
            }
            if(firstItemIndex >= _maximumSize || secondItemIndex >= _maximumSize)
            {
                throw new IndexOutOfRangeException();
            }


            var firstItem = _items[firstItemIndex];
            var secondItem = _items[secondItemIndex];


            _items[secondItemIndex] = firstItem;
            _items[firstItemIndex] = secondItem;
        }
    }
}
