using System;
using System.Collections.Generic;

namespace Lab_3_sem3
{
    public class SimpleListItem<T>
    {
        public T Data { get; set; }

        public SimpleListItem<T> Next { get; set; }

        public SimpleListItem(T param)
        {
            Data = param;
        }
    }

    public class SimpleList<T> : IEnumerable<T> where T : IComparable
    {
        protected SimpleListItem<T> first = null;

        protected SimpleListItem<T> last = null;

        public int Count { get;  protected set; }

        public void Add(T element)
        {
            SimpleListItem<T> newItem = new SimpleListItem<T>(element);
            Count++;

            if (last == null)
            {
                first = newItem;
                last = newItem;
            }
            else
            {
                last.Next = newItem;
                last = newItem;
            }
        }

        public SimpleListItem<T> GetItem(int number)
        {
            if ((number < 0) || (number >= Count))
            {
                throw new Exception("Выход за границу индекса");
            }

            SimpleListItem<T> current = first;
            int i = 0;

            while (i < number)
            {
                current = current.Next;
                i++;
            }

            return current;
        }

        public T Get(int number)
        {
            return GetItem(number).Data;
        }


        public IEnumerator<T> GetEnumerator()
        {
            SimpleListItem<T> current = first;

            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Sort()
        {
            Sort(0, Count - 1);
        }

        private void Sort(int low, int high)
        {
            int i = low;
            int j = high;
            T x = Get((low + high) / 2);
            do
            {
                while (Get(i).CompareTo(x) < 0) ++i;
                while (Get(j).CompareTo(x) > 0) --j;
                if (i <= j)
                {
                    Swap(i, j);
                    i++; j--;
                }
            } while (i <= j);

            if (low < j) Sort(low, j);
            if (i < high) Sort(i, high);
        }

        private void Swap(int i, int j)
        {
            SimpleListItem<T> ci = GetItem(i);
            SimpleListItem<T> cj = GetItem(j);
            T temp = ci.Data;
            ci.Data = cj.Data;
            cj.Data = temp;
        }
    }
}
