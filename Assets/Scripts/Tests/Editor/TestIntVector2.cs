namespace SpencerHaney
{
    using NUnit.Framework;

    [TestFixture]
    public class TestIntVector2
    {
        [Test]
        public void TestEquals()
        {
            // Equals self
            IntVector2 a = new IntVector2(1, 20);
            Assert.AreEqual(a, a);

            // Equals others with same coords
            IntVector2 b = new IntVector2(1, 20);
            Assert.AreEqual(a, b);

            // Not the same object though
            Assert.AreNotSame(a, b);

            // Doesn't equal other with different coords
            IntVector2 c = new IntVector2(2, 5);
            Assert.AreNotEqual(a, c);
            Assert.AreNotEqual(b, c);

            // Doesn't equal objects of other types
            int x = 1;
            int y = 20;
            var other = new { x, y };
            Assert.AreNotEqual(a, other);

            // Children of different types are not equal ever
            IntVector2 child1 = new IntVectorChild1(1, 1);
            IntVector2 child2 = new IntVectorChild2(1, 1);
            Assert.AreNotEqual(child1, child2);
        }

        [Test]
        public void TestGetHashCode()
        {
            // Subsequent calls to GetHashCode return same value
            IntVector2 a = new IntVector2(5, 4);
            Assert.AreEqual(a.GetHashCode(), a.GetHashCode());

            // Equal valued vector returns same hashcode
            IntVector2 b = new IntVector2(5, 4);
            Assert.AreEqual(a.GetHashCode(), b.GetHashCode());

            // Different valued vectors return different hashcodes
            IntVector2 c = new IntVector2(4, 5);
            Assert.AreNotEqual(a.GetHashCode(), c.GetHashCode());
            Assert.AreNotEqual(b.GetHashCode(), c.GetHashCode());

            // Children of different types don't return the same hashcode
            IntVector2 child1 = new IntVectorChild1(1, 1);
            IntVector2 child2 = new IntVectorChild2(1, 1);
            Assert.AreNotEqual(child1.GetHashCode(), child2.GetHashCode());
        }

        [Test]
        public void TestToString()
        {
            // Test that different vectors return the correct string
            IntVector2 sut = new IntVector2(5, 62);
            Assert.AreEqual(sut.ToString(), "5, 62");

            sut = new IntVector2(0, 3);
            Assert.AreEqual(sut.ToString(), "0, 3");

            sut = new IntVector2(-51, 2345);
            Assert.AreEqual(sut.ToString(), "-51, 2345");
        }
    }

    public class IntVectorChild1 : IntVector2
    {
        public IntVectorChild1(int x, int y) : base(x, y)
        {
        }
    }

    public class IntVectorChild2 : IntVector2
    {
        public IntVectorChild2(int x, int y) : base(x, y)
        {
        }
    }
}