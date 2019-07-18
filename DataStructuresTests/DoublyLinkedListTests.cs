using DataStructures;
using NUnit.Framework;

namespace DataStructuresTests
{
    public class DoublyLinkedListTests
    {
        [Test]
        [TestCase(0)]
        [TestCase(1, "Foo")]
        [TestCase(3, "Hello", "Goodbye", "!")]
        public void Push_CheckLength(int expectedLength, params string[] vals)
        {
            var dll = CreateDoublyLinkedList(vals);
            Assert.That(dll.Length, Is.EqualTo(expectedLength));
        }

        [Test]
        public void Push_OneElement_HeadEqualsToTail()
        {
            var dll = CreateDoublyLinkedList("A value");

            Assert.That(dll.Length, Is.EqualTo(1));
            Assert.That(dll.Head, Is.EqualTo(dll.Tail));
            Assert.That(dll.Head.Value, Is.EqualTo("A value"));
        }

        [Test]
        public void Push_MultipleElements_ValidateSequence()
        {
            var dll = CreateDoublyLinkedList("one", "two", "three");

            Assert.That(dll.Length, Is.EqualTo(3));
            Assert.That(dll.Head.Value, Is.EqualTo("one"));
            Assert.That(dll.Head.Next.Value, Is.EqualTo("two"));
            Assert.That(dll.Head.Next.Next.Value, Is.EqualTo("three"));
            Assert.That(dll.Head.Next.Next.Next, Is.Null);

            Assert.That(dll.Tail.Value, Is.EqualTo("three"));
            Assert.That(dll.Tail.Previous.Value, Is.EqualTo("two"));
            Assert.That(dll.Tail.Previous.Previous.Value, Is.EqualTo("one"));
            Assert.That(dll.Tail.Previous.Previous.Previous, Is.Null);

            Assert.That(dll.Head.Next.Previous, Is.EqualTo(dll.Head));
            Assert.That(dll.Tail.Previous.Next, Is.EqualTo(dll.Tail));
        }

        private static DoublyLinkedList<string> CreateDoublyLinkedList(params string[] vals)
        {
            var dll = new DoublyLinkedList<string>();
            foreach (var val in vals)
            {
                dll.Push(val);
            }

            return dll;
        }
    }
}
