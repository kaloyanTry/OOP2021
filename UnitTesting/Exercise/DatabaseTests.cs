using NUnit.Framework;
using System;

namespace Tests
{
    //using Database; // comment for Judge
    using System.Linq;

    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void Setup()
        {
            database = new Database();
        }

        // Constructor tests:
        [Test]
        public void Ctor_AddElementsToDBCorrectly()
        {
            int[] elements = new int[] { 1, 3, 4 };
            database = new Database(elements);

            Assert.That(database.Count, Is.EqualTo(elements.Length));
            Assert.That(database.Fetch(), Is.EqualTo(elements));
        }

        //methods tests:
        [Test]
       public void AddElements_ShouldThrowExceptionIfMoreThanCapacity()
        {
            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(17));
        }

        [Test]
        public void AddMoreElements_ShouldThrowException()
        {
            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }

            Assert.That(() =>
            {
                database.Add(17);
            }, Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void AddElement_ShoulBeCorrectInCapacity()
        {
            for (int i = 0; i < 15; i++)
            {
                database.Add(i);
            }
            Assert.That(database.Count, Is.EqualTo(15));
        }

        [Test]
        public void AddElementToDB_Fetch()
        {
            database.Add(3);

            int[] elements = database.Fetch();

            Assert.That(elements.Contains(3));
        }

        [Test]
        public void CountReturnsZero_WhenDBIsEmpty()
        {
            Assert.That(database.Count, Is.EqualTo(0));
        }

        [Test]
        public void RemoveElementFromEmptyDB_ShouldThrowException()
        {
            Assert.That(() =>
            {
                database.Remove();
            }, Throws.InvalidOperationException.With.Message.EqualTo("The collection is empty!"));

            //Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void RemoveCorrectlyFromDB()
        {
            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
            }

            database.Remove();

            Assert.That(database.Count, Is.EqualTo(15));
        }

        [Test]
        public void FetchCopyCorrectly()
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