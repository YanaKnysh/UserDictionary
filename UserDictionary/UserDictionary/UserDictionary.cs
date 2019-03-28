using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDictionary
{
    public class UserDictionary : IEnumerable<Entry>, IEnumerator<Entry>
    {
        private int position;

        public int Count { get; private set; }
        public Entry[] Entries { get; private set; }

        public Entry Current => Entries[position];
        object IEnumerator.Current => Entries[position];

        public UserDictionary()
        {
            Entries = new Entry[10];
            Count = 0;
            position = -1;
        }

        public Entry this[string index]
        {
            get
            {
                for (int i = 0; i < Count; i++)
                {
                    if (Entries[i].Key == index)
                    {
                        return Entries[i];
                    }
                }

                return null;
            }
        }

        public Entry this[int index]
        {
            get
            {
                if (index < 0 & index >= Count)
                {
                    return null;
                }

                for (int i = 0; i < Entries.Length; i++)
                {
                    if (i == index)
                    {
                        return Entries[i];
                    }
                }

                return null;
            }
        }

        public void Add(string key, int value)
        {
            if (Count >= Entries.Length)
            {
                EnlargeArray(Entries);
            }

            Entries[Count] = new Entry(key, value);

            Count++;
        }

        public void Add(Entry entry)
        {
            if (Count >= Entries.Length)
            {
                EnlargeArray(Entries);
            }

            Entries[Count] = entry;

            Count++;
        }

        public void Clear()
        {
            Count = 0;
        }

        public bool ContainsKey(string key)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Entries[i].Key == key)
                {
                    return true;
                }
            }

            return false;
        }

        public bool TryGetValue(string key, out int value)
        {
            Entry entry = this[key];

            if (entry == null)
            {
                value = 0;
                return false;
            }

            value = entry.Value;
            return true;

        }

        public bool ContainsValue(int value)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Entries[i].Value == value)
                {
                    return true;
                }
            }

            return false;
        }

        public void Remove(string key)
        {
            int indexOfRemovedElement = ReturnIndexOfElement(key);

            if (indexOfRemovedElement == -1)
            {
                return;
            }

            Count--;

            ShiftAfterRemoval(Entries, indexOfRemovedElement);
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (position < Count - 1)
            {
                position++;
                return true;
            }

            Reset();
            return false;
        }

        public void Reset()
        {
            position = -1;
        }

        public IEnumerator<Entry> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

        private void EnlargeArray(Entry[] oldArray)
        {
            Entry[] newArray = new Entry[oldArray.Length * 2];

            for (int i = 0; i < Count; i++)
            {
                newArray[i] = oldArray[i];
            }

            Entries = newArray;
        }

        private void ShiftAfterRemoval(Entry[] oldArray, int indexOfRemovedElement)
        {
            for (int i = indexOfRemovedElement; i < Count; i++)
            {
                oldArray[i] = oldArray[i + 1];
            }
        }

        private int ReturnIndexOfElement(string key)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Entries[i].Key == key)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
