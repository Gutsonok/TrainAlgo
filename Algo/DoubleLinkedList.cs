using System;
using System.Collections;
using System.Collections.Generic;

namespace Algo
{
    public class Node<T> where T : IComparable<T>
    {
        public Node(T data)
        {
            Data = data;
        }
 

        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public Node<T> Previous { get; set; }
    }

    class DoubleLinkedList<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private Int64 count;

        private Node<T> Head { get; set; }
        public Int64 Count { get { return count; } }
        public Boolean IsEmpty{ get { return count == 0; } }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public void Clear()
        {
            Head = null;
            count = 0;
        }

        public Node<T> Find(T data)
        {
            Node<T> current = Head;
            while (current != null)
            {
                if (current.Data.CompareTo(data) == 0)
                    return current;
                current = current.Next;
            }
            return null;
        }

        public void Add(T data)
        {
            var node = new Node<T>(data);

            if (Head == null)
                Head = node;
            else
            {
                node.Next = Head.Next;
                node.Previous = Head;
                Head.Next = node;
                if(node.Next != null)
                    node.Next.Previous = node;
            }
            count++;
        }

        public void Delete(T data)
        {
            var node = Find(data);

            if (node != null)
            {
                if (node.Previous != null)
                    node.Previous.Next = node.Next;
                else 
                    Head = node.Next;
                if (node.Next != null)
                    node.Next.Previous = node.Previous;
                node.Next = null;
                node.Previous = null;
                count--;
            }
        }
    }
}
