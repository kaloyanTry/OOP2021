using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    //using Database; //Comment for Judge

    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void Setup()
        {
            database = new Database();
        }

        //--Ctor tests--
        [Test]
        public void Ctor_ThrowsExceptionWhenDBCapacityIsExceeded()
        {
            Assert.Throws<InvalidOperationException>(() =>
            database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17));
        }

        [Test]
        public void Ctor_AddsElementsToDB()
        {
            int[] arr = new[] { 1, 2, 3 };

            database = new Database(arr);

            Assert.That(database.Count, Is.EqualTo(arr.Length));
            Assert.That(database.Fetch(), Is.EquivalentTo(arr));
        }


        //--Methods tests--
        [Test]
        public void Add_IncreaseDBCount_WhenAddIsValid()
        {
            int n = 15;
            for (int i = 0; i < n; i++)
            {
                database.Add(123);
            }

            Assert.That(database.Count, Is.EqualTo(n));
        }

        [Test]
        public void Add_ThrowsInvalidOperationException_WhenCapacityExceeded()
        {
            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(17));
        }

        [Test]
        public void Add_AddsElementsToDatabase()
        {
            int element = 123;

            database.Add(element);

            int[] elements = database.Fetch();

            Assert.That(elements.Contains(element));
        }

        [Test]
        public void Count_ReturnsZero_WhenDBIsEmpty()
        {
            Assert.That(database.Count, Is.EqualTo(0));
        }

        [Test]
        public void Remove_ThrowsInvalidOperationException_WhenDBIsEmpry()
        {
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void Remove_DecreasesDBCount()
        {
            database.Add(1);
            database.Add(2);
            database.Add(3);

            database.Remove();
            int expectedCount = 2;

            Assert.That(database.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Remove_LastElementFromDB()
        {
            database.Add(1);
            database.Add(2);
            database.Add(3);

            database.Remove();

            int[] elements = database.Fetch();

            Assert.IsFalse(elements.Contains(3));
        }

        [Test]
        public void Fetch_ReturnsDBCopyInsteadOfReference()
        {
            database.Add(1);
            database.Add(2);

            int[] firstCopy = database.Fetch();

            database.Add(3);

            int[] secondCopy = database.Fetch();

            Assert.That(firstCopy, Is.Not.EqualTo(secondCopy));
        }
    }
}