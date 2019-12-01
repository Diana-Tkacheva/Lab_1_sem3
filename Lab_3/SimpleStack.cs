using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_sem3
{
    public class SimpleStack<T> : SimpleList<T> where T : IComparable
    {
        public void Push(T element)
        {
            Add(element);
        }
        public T Pop()
        {
            if (Count == 0)
            {
                throw new Exception("Список пуст!");
            }
            var res = Get(Count - 1);
            if (Count > 1)
            {
                var newLast = GetItem(Count - 2);
                newLast.Next = null;
                last = newLast;
            } else
            {
                last = null;
                first = null;
            }
            Count--;
            return res;
        }
    }
}
