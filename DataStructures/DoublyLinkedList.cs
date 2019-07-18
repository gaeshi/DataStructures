using System;

namespace DataStructures
{
    public class DoublyLinkedList<T>
    {
        public class Node
        {
            public T Value { get; }
            public Node Next { get; set; }
            public Node Previous { get; set; }

            public Node(T value)
            {
                Value = value;
            }
        }

        public Node Head { get; private set; }
        public Node Tail { get; private set; }
        public int Length { get; private set; }

        public void Push(T value)
        {
            var node = new Node(value);
            if (Head == null)
            {
                Head = node;
            }
            else
            {
                node.Previous = Tail;
                Tail.Next = node;
            }

            Tail = node;
            Length++;
        }

        public T Pop()
        {
            if (Tail == null)
            {
                throw new Exception("Can't pop: Tail is null");
            }

            Length--;
            var temp = Tail;

            if (Length == 0)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Tail = Tail.Previous;
                Tail.Next = null;
                temp.Previous = null;
            }

            return temp.Value;
        }
    }
}
