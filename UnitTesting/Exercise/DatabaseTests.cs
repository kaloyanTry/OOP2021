using NUnit.Framework;

namespace Tests
{
    using Database; //comment for Judge

    [TestFixture]
    public class DatabaseTests
    {
        private const int DatabasCapacity = 16;

        private Database database;

        //--Initialization--
        [SetUp]
        public void Setup()
        {
            database = new Database();
        }

        //--Constructor tests--
        [Test]
        [TestCase(10)]
        [TestCase(10, 20,30,40,50,60,70,80,90,100,1,2,3,4,5,6)]
        public void ConstructorShouldInitializeDatabaseElementsCorrectly(params int[] numbers)
        {
            database = new Database(numbers); //Arrange

            int[] dbElements = database.Fetch(); //Act

            for (int i = 0; i < numbers.Length; i++)
            {
                Assert.AreEqual(dbElements[i], numbers[i]); //Assert
            }
        }

        [Test]
        public void ConstructorShouldInitializeDatabaseWithExactly16Elements()
        {
            int[] array = new int[16];
            database = new Database(array);

            Assert.AreEqual(DatabasCapacity, database.Count, "Array's capacity must be exactly 16 integers!");
        }

        //--Operation tests--
        [Test]
        public void AddOperationShouldAddElementInTheNextFreeCell()
        {
            database.Add(123);
            Assert.AreEqual(1, database.Count, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16)]
        public void AddOperationExceeding16ElementsShouldThrowInvalidOperationException(params int[] arr)
        {
            database = new Database(arr);

            Assert.That(() => database.Add(17), Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        //--Fetch operation tests--
        [Test]
        public void FetchOperationShouldReturnTheElementsAsArray()
        {
            int[] arr = database.Fetch();

            Assert.That(arr, Is.TypeOf<int[]>());
        }

        //--Remove operation tests--
        [Test]
        public void RemoveOperationShouldRemoveElementAtLastIndex()
        {
            database = new Database(5);

            database.Remove();

            Assert.AreEqual(0, database.Count, "The collection is empty!");
        }

        [Test]
        public void RemoveOperationOnEmptyCollectionShouldThrowInvalidOperationException()
        {
            Assert.That(() => this.database.Remove(), Throws.InvalidOperationException.With.Message.EqualTo("The collection is empty!"));
        }
    }
}