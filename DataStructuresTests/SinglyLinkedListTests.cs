using System;
using DataStructures;
using NUnit.Framework;

namespace DataStructuresTests
{
    public class SinglyLinkedListTests
    {
        [TestCase(0)]
        [TestCase(1, "Foo")]
        [TestCase(3, "Hello", "Goodbye", "!")]
        public void Push_CheckLength(int expectedLength, params string[] vals)
        {
            var sll = CreateSinglyLinkedList(vals);
            Assert.That(sll.Length, Is.EqualTo(expectedLength));
        }

        [Test]
        public void Push_SLL_OneElement_HeadEqualsToTail()
        {
            var sll = CreateSinglyLinkedList("A value");
            
            Assert.That(sll.Length, Is.EqualTo(1));
            Assert.That(sll.Head, Is.EqualTo(sll.Tail));
            Assert.That(sll.Head.Value, Is.EqualTo("A value"));
        }

        [TestCase(0, "Foo", "Foo")]
        [TestCase(2, "!", "Hello", "Goodbye", "!")]
        public void PopTests(int expectedLength, string expectedValue, params string[] vals)
        {
            var sll = CreateSinglyLinkedList(vals);

            var returnedValue = sll.Pop();

            Assert.That(sll.Length, Is.EqualTo(expectedLength));
            Assert.That(returnedValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void Pop_ValidateContents()
        {
            var sll = CreateSinglyLinkedList("Aa", "Ea", "Bae");

            var returnedValue = sll.Pop();

            Assert.That(returnedValue, Is.EqualTo("Bae"));
            
            Assert.That(sll.Length, Is.EqualTo(2));
            Assert.That(sll.Head.Value, Is.EqualTo("Aa"));
            Assert.That(sll.Head.Next.Value, Is.EqualTo("Ea"));
            Assert.That(sll.Head.Next.Next, Is.Null);
        }

        [Test]
        public void Pop_SLL_NoElements_CantShift()
        {
            Assert.Throws<Exception>(() => new SinglyLinkedList<object>().Pop());
        }

        [TestCase(0, "Foo", "Foo")]
        [TestCase(2, "Hello", "Hello", "Goodbye", "!")]
        public void ShiftTests(int expectedLength, string expectedValue, params string[] vals)
        {
            var sll = CreateSinglyLinkedList(vals);

            var returnedValue = sll.Shift();

            Assert.That(sll.Length, Is.EqualTo(expectedLength));
            Assert.That(returnedValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void Shift_ValidateContents()
        {
            var sll = CreateSinglyLinkedList("foo", "bar", "baz");

            var returnedValue = sll.Shift();

            Assert.That(returnedValue, Is.EqualTo("foo"));
            
            Assert.That(sll.Length, Is.EqualTo(2));
            Assert.That(sll.Head.Value, Is.EqualTo("bar"));
            Assert.That(sll.Head.Next.Value, Is.EqualTo("baz"));
            Assert.That(sll.Head.Next.Next, Is.Null);
        }

        [Test]
        public void Shift_SLL_NoElements_CantShift()
        {
            Assert.Throws<Exception>(() => new SinglyLinkedList<object>().Shift());
        }

        [TestCase(1, "Dash")]
        [TestCase(2, "Foo", "Bar")]
        [TestCase(4, "Hey", "Hello", "Goodbye", "!")]
        public void UnshiftTests(int expectedLength, string expectedValue, params string[] vals)
        {
            var sll = CreateSinglyLinkedList(vals);

            var returnedValue = sll.Unshift(expectedValue);

            Assert.That(sll.Length, Is.EqualTo(expectedLength));
            Assert.That(returnedValue, Is.EqualTo(expectedValue));
            Assert.That(sll.Head.Value, Is.EqualTo(expectedValue));
        }

        [Test]
        public void Unshift_ValidateContents()
        {
            var sll = CreateSinglyLinkedList("foo", "bar", "baz");

            var returnedValue = sll.Unshift("hoge");

            Assert.That(sll.Length, Is.EqualTo(4));
            Assert.That(returnedValue, Is.EqualTo("hoge"));
            Assert.That(sll.Head.Value, Is.EqualTo("hoge"));
            Assert.That(sll.Head.Next.Value, Is.EqualTo("foo"));
            Assert.That(sll.Head.Next.Next.Value, Is.EqualTo("bar"));
            Assert.That(sll.Head.Next.Next.Next.Value, Is.EqualTo("baz"));
            Assert.That(sll.Head.Next.Next.Next.Next, Is.Null);
        }

        private static SinglyLinkedList<string> CreateSinglyLinkedList(params string[] vals)
        {
            var sll = new SinglyLinkedList<string>();
            foreach (var val in vals)
            {
                sll.Push(val);
            }

            return sll;
        }
    }
}