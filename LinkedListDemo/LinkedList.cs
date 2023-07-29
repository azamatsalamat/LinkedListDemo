using System.Collections;

namespace LinkedListDemo
{
    public class CustomLinkedList<T> : IEnumerable<T>
    {
        public ListNode<T>? First { get; set; }
        public int Count { get; set; } = 0;
        public ListNode<T>? Last { get; set; }

        public void AddAfter(ListNode<T> node, ListNode<T> newNode)
        {
            newNode.Previous = node;
            newNode.Next = node.Next;
            if (node.Next != null)
            {
                node.Next.Previous = newNode;
            }
            node.Next = newNode;

            Count++;
        }

        public ListNode<T> AddAfter(ListNode<T> node, T newValue)
        {
            var newNode = new ListNode<T> { Value = newValue };

            newNode.Previous = node;
            newNode.Next = node.Next;
            if (node.Next != null)
            {
                node.Next.Previous = newNode;
            }
            node.Next = newNode;

            Count++;

            return newNode;
        }

        public void AddBefore(ListNode<T> node, ListNode<T> newNode)
        {
            newNode.Previous = node.Previous;
            newNode.Next = node;
            if (node.Previous != null)
            {
                node.Previous.Next = newNode;
            }
            node.Previous = newNode;

            Count++;
        }

        public ListNode<T> AddBefore(ListNode<T> node, T newValue)
        {
            var newNode = new ListNode<T> { Value = newValue };
            
            newNode.Previous = node.Previous;
            newNode.Next = node;
            if (node.Previous != null)
            {
                node.Previous.Next = newNode;
            }
            node.Previous = newNode;

            Count++;

            return newNode;
        }

        public void AddFirst(ListNode<T> newNode)
        {
            if (First != null)
            {
                First.Previous = newNode;
                newNode.Next = First;
            }
            else
            {
                Last = newNode;
            }
            First = newNode;

            Count++;
        }

        public ListNode<T> AddFirst(T value)
        {
            var newNode = new ListNode<T> { Value = value };
            if (First != null)
            {
                First.Previous = newNode;
                newNode.Next = First;
            }
            else
            {
                Last = newNode;
            }
            First = newNode;

            Count++;

            return newNode;
        }

        public void AddLast(ListNode<T> newNode)
        {
            if (Last != null)
            {
                Last.Next = newNode;
                newNode.Previous = Last;
            }
            else
            {
                First = newNode;
            }
            Last = newNode;

            Count++;
        }

        public ListNode<T> AddLast(T value)
        {
            var newNode = new ListNode<T> { Value = value };
            if (Last != null)
            {
                Last.Next = newNode;
                newNode.Previous = Last;
            }
            else
            {
                First = newNode;
            }
            Last = newNode;

            Count++;

            return newNode;
        }

        public void Remove(ListNode<T> node)
        {
            if (node.Next == null && node.Previous == null)
            {
                First = null;
                Last = null;
            } 
            else if (node.Previous == null && node.Next != null)
            {
                First = node.Next;
                node.Next.Previous = null;
                node.Next = null;
            } 
            else if (node.Next == null && node.Previous != null)
            {
                Last = node.Previous;
                node.Previous.Next = null;
                node.Previous = null;
            }
            else
            {
                node.Previous.Next = node.Next;
                node.Next.Previous = node.Previous;
                node.Next = null;
                node.Previous = null;
            }

            Count--;
        }

        public bool Remove(T value)
        {
            var node = this.Find(value);

            if (node == null)
            {
                return false;
            }

            if (node.Next == null && node.Previous == null)
            {
                First = null;
                Last = null;
            }
            else if (node.Previous == null && node.Next != null)
            {
                First = node.Next;
                node.Next.Previous = null;
                node.Next = null;
            }
            else if (node.Next == null && node.Previous != null)
            {
                Last = node.Previous;
                node.Previous.Next = null;
                node.Previous = null;
            }
            else
            {
                node.Previous.Next = node.Next;
                node.Next.Previous = node.Previous;
                node.Next = null;
                node.Previous = null;
            }

            Count--;

            return true;
        }

        public void RemoveFirst()
        {
            if (First == null)
            {
                return;
            }

            if (First.Next == null)
            {
                First = null;
            }
            else
            {
                First.Next.Previous = null;
                First = First.Next;
            }

            Count--;
        }

        public void RemoveLast()
        {
            if (Last == null)
            {
                return;
            }

            if (Last.Previous == null)
            {
                Last = null;
            }
            else
            {
                Last.Previous.Next = null;
                Last = Last.Previous;
            }

            Count--;
        }

        public ListNode<T>? Find(T value)
        {
            if (First == null)
            {
                return null;
            }

            ListNode<T> currentNode = First;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(value))
                {
                    return currentNode;
                }
                currentNode = currentNode.Next;
            }

            return null;
        }

        public ListNode<T>? FindLast(T value)
        {
            if (Last == null)
            {
                return null;
            }

            ListNode<T> currentNode = Last;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(value))
                {
                    return currentNode;
                }
                currentNode = currentNode.Previous;
            }

            return null;
        }

        public bool Contains(T value)
        {
            if (First == null)
            {
                return false;
            }

            ListNode<T> currentNode = First;
            while (currentNode != null)
            {
                if (currentNode.Value.Equals(value))
                {
                    return true;
                }
                currentNode = currentNode.Next;
            }

            return false;
        }

        public void Clear()
        {
            while (First != null)
            {
                this.Remove(First);
            }

            Count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (First == null)
            {
                yield break;
            }

            ListNode<T> currentNode = First;
            do
            {
                yield return currentNode.Value;
                currentNode = currentNode.Next;
            }
            while (currentNode != null);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
