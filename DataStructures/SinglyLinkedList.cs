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

            if (Head.Next == null)
            {
                Length--;
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
            Length--;
            return popNode.Value;
        }

        public T Shift()
        {
            if (Head == null)
            {
                throw new Exception("Can't Shift: Head is null");
            }

            if (Head.Next == null)
            {
                Length--;
                var returnValue = Head.Value;
                Head = null;
                Tail = null;
                return returnValue;
            }

            var node = Head;
            Head = Head.Next;
            Length--;
            return node.Value;
        }

        public T Unshift(T val)
        {
            if (Head == null)
            {
                Push(val);
                return val;
            }

            var node = new Node(val) {Next = Head};
            Head = node;
            Length++;
            return val;
        }
    }
}
