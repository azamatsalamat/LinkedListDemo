using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListDemo
{
    public class ListNode<T>
    {
        public ListNode<T>? Previous { get; set; }
        public T? Value { get; set; }
        public ListNode<T>? Next { get; set; }
    }
}
