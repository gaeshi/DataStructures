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

        [TestCase(1, "Foo", "Foo")]
        [TestCase(1, "Hello", "Hello", "Goodbye", "!")]
        [TestCase(3, "!", "Hello", "Goodbye", "!")]
        public void GetTests(int index, string expectedValue, params string[] vals)
        {
            var sll = CreateSinglyLinkedList(vals);

            Assert.That(sll.Get(index), Is.EqualTo(expectedValue));
        }

        [Test]
        public void Get_NoElements_ThrowsException()
        {
            Assert.Throws<Exception>(() => new SinglyLinkedList<object>().Get(1));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void Get_IndexZeroOrLess_ThrowsArgumentOutOfRangeException(int index)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => CreateSinglyLinkedList("foo").Get(index));
        }

        [Test]
        public void Get_IndexGreaterThanLength_ThrowsArgumentOutOfRangeException()
        {
            var sll = CreateSinglyLinkedList("foo", "bar");

            Assert.DoesNotThrow(() => sll.Get(2));
            Assert.Throws<ArgumentOutOfRangeException>(() => sll.Get(3));
        }

        [TestCase(1, "Boo", "Foo")]
        [TestCase(1, "Test", "Hello", "Goodbye", "!")]
        [TestCase(3, "Best", "Hello", "Goodbye", "!")]
        public void SetTests(int index, string expectedValue, params string[] vals)
        {
            var sll = CreateSinglyLinkedList(vals);
            sll.Set(index, expectedValue);

            Assert.That(sll.Get(index), Is.EqualTo(expectedValue));
        }

        [Test]
        public void Set_NoElements_ThrowsException()
        {
            Assert.Throws<Exception>(() => new SinglyLinkedList<object>().Set(1, new object()));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void Set_IndexZeroOrLess_ThrowsArgumentOutOfRangeException(int index)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => CreateSinglyLinkedList("foo").Set(index, "bar"));
        }

        [Test]
        public void Set_IndexGreaterThanLength_ThrowsArgumentOutOfRangeException()
        {
            var sll = CreateSinglyLinkedList("foo", "bar");

            Assert.DoesNotThrow(() => sll.Set(2, "baz"));
            Assert.Throws<ArgumentOutOfRangeException>(() => sll.Set(3, "bazinga!"));
        }

        [TestCase(1, "Foo", "Bar")]
        [TestCase(1, "Test", "Hello", "Goodbye", "!")]
        [TestCase(3, "Best", "Hello", "Goodbye", "!")]
        public void InsertTests(int index, string insertValue, params string[] vals)
        {
            var sll = CreateSinglyLinkedList(vals);
            sll.Insert(index, insertValue);

            Assert.That(sll.Get(index + 1), Is.EqualTo(insertValue));
        }

        [Test]
        public void Insert_NoElements_ThrowsException()
        {
            Assert.Throws<Exception>(() => new SinglyLinkedList<object>().Insert(1, new object()));
        }

        [Test]
        public void Insert_IndexLessThanZero_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => CreateSinglyLinkedList("foo").Insert(-1, "bar"));
        }

        [Test]
        public void Insert_IndexGreaterThanLength_ThrowsArgumentOutOfRangeException()
        {
            var sll = CreateSinglyLinkedList("foo", "bar");

            Assert.Throws<ArgumentOutOfRangeException>(() => sll.Insert(3, "bazinga!"));
        }

        [Test]
        public void Insert_Start_ValidateContents()
        {
            var sll = CreateSinglyLinkedList("you", "!");
            sll.Insert(0, "Thank");

            AssertThankYou(sll);
        }

        [Test]
        public void Insert_Middle_ValidateContents()
        {
            var sll = CreateSinglyLinkedList("Thank", "!");
            sll.Insert(1, "you");

            AssertThankYou(sll);
        }

        [Test]
        public void Insert_End_ValidateContents()
        {
            var sll = CreateSinglyLinkedList("Thank", "you");
            sll.Insert(2, "!");

            AssertThankYou(sll);
        }

        private static void AssertThankYou(SinglyLinkedList<string> sll)
        {
            Assert.That(sll.Length, Is.EqualTo(3));
            Assert.That(sll.Head.Value, Is.EqualTo("Thank"));
            Assert.That(sll.Head.Next.Value, Is.EqualTo("you"));
            Assert.That(sll.Head.Next.Next.Value, Is.EqualTo("!"));
            Assert.That(sll.Head.Next.Next.Next, Is.Null);
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
