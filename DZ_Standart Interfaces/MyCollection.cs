using System;
using System.Collections;
using System.Collections.Generic;

namespace DZ_Generic_Collections
{
    internal class MyClass
    {
        public int Value { get; set; }
    }

    internal class MyCollection<T> : IEnumerable<T>, IEnumerator<T>
    {
        private T[] items;
        private int position;
        public int Count { get; private set; }
        public MyCollection() { items = new T[0]; position = -1; Count = 0; }
        public T this[int index]
        {
            get { if (index < 0 || index >= Count) throw new IndexOutOfRangeException(); return items[index]; }
            set { if (index < 0 || index >= Count) throw new IndexOutOfRangeException(); items[index] = value; }
        }
        public void Add(T item) { System.Array.Resize(ref items, Count + 1); items[Count] = item; Count++; }
        public void Sort(IComparer<T> comparer)
        {
            for (int i = 0; i < Count - 1; i++)
                for (int j = 0; j < Count - i - 1; j++)
                    if (comparer.Compare(items[j], items[j + 1]) > 0)
                    { T temp = items[j]; items[j] = items[j + 1]; items[j + 1] = temp; }
        }
        public IEnumerator<T> GetEnumerator() { return GetEnumeratorWithYield(); }
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        private IEnumerator<T> GetEnumeratorWithYield()
        {
            for (int i = 0; i < Count; i++) yield return items[i];
        }
        public T Current { get { if (position < 0 || position >= Count) throw new InvalidOperationException(); return items[position]; } }
        object IEnumerator.Current { get { return Current; } }
        public bool MoveNext() { position++; return position < Count; }
        public void Reset() { position = -1; }
        public void Dispose() { }
    }
}
