using System;

namespace DataStructures
{
    public class SinglyLinkedList<T>
    {
        public class Node
        {
            public T Value { get; }
            public Node Next { get; set; }

            public Node(T value)
            {
                Value = value;
            }
        }

        public Node Head { get; private set; }
        public Node Tail { get; private set; }
        public int Length { get; private set; }

        public void Push(T val)
        {
            var node = new Node(val);
            if (Head == null)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
            }

            Tail = node;
            Length++;
        }

        public T Pop()
        {
            if (Head == null)
            {
                throw new Exception("Can't pop: head is null");
            }

            Length--;

            if (Head.Next == null)
            {
                var returnValue = Head.Value;
                Head = null;
                Tail = null;
                return returnValue;
            }

            var popNode = Head;
            var prePopNode = Head;
            while (popNode.Next != null)
            {
                prePopNode = popNode;
                popNode = popNode.Next;
            }

            Tail = prePopNode;
            Tail.Next = null;
            return popNode.Value;
        }

        public T Shift()
        {
            if (Head == null)
            {
                throw new Exception("Can't Shift: Head is null");
            }

            Length--;

            if (Head.Next == null)
            {
                var returnValue = Head.Value;
                Head = null;
                Tail = null;
                return returnValue;
            }

            var node = Head;
            Head = Head.Next;
            return node.Value;
        }

        public T Unshift(T val)
        {
            var node = new Node(val) {Next = Head};
            Length++;

            if (Head == null)
            {
                Tail = node;
            }

            Head = node;
            return val;
        }
    }
}
