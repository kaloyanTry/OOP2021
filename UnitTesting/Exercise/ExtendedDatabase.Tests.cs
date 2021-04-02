using NUnit.Framework;
using System;

namespace Tests
{
    //using ExtendedDatabase; //Comment for Judge

    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase extendedDB;

        [SetUp]
        public void Setup()
        {
            extendedDB = new ExtendedDatabase();
        }

        //--Ctor tests--
        [Test]
        public void Ctor_ThrowsExceptionWhenDBCapacityIsExceeded()
        {
            Person[] arguments = new Person[17];

            for (int i = 0; i < arguments.Length; i++)
            {
                arguments[i] = new Person(i, $"Username{i}");
            }
            Assert.Throws<ArgumentException>(() =>
            extendedDB = new ExtendedDatabase(arguments));
        }

        [Test]
        public void Ctor_AddInitialPeopleToDB()
        {
            Person[] arguments = new Person[5];

            for (int i = 0; i < arguments.Length; i++)
            {
                arguments[i] = new Person(i, $"Username{i}");
            }

            extendedDB = new ExtendedDatabase(arguments);

            Assert.That(extendedDB.Count, Is.EqualTo(arguments.Length));

            foreach (var person in arguments)
            {
                Person dbPerson = extendedDB.FindById(person.Id);
                Assert.That(person, Is.EqualTo(dbPerson));
            }
        }

        [Test]
        public void Add_ThrowsException_WhenCapacityExceeded()
        {
            for (int i = 0; i < 16; i++)
            {
                extendedDB.Add(new Person(i, $"Username{i}"));
            }

            Assert.Throws<InvalidOperationException>(() =>
            extendedDB.Add(new Person(16, "InvalidUserName")));
        }

        [Test]
        public void Add_ThrowsException_UserNameIsUsed()
        {
            extendedDB.Add(new Person(1, "SU"));

            Assert.Throws<InvalidOperationException>(() =>
            extendedDB.Add(new Person(2, "SU")));
        }

        [Test]
        public void Add_ThrowsException_IdIsUsed()
        {
            int id = 1;
            extendedDB.Add(new Person(id, "User1"));

            Assert.Throws<InvalidOperationException>(() =>
            extendedDB.Add(new Person(id, "User2")));
        }

        [Test]
        public void Add_IncreasedCounter_WhenUserIsValid()
        {
            extendedDB.Add(new Person(1, "User1"));
            extendedDB.Add(new Person(2, "User2"));

            int expectedCount = 2;

            Assert.That(extendedDB.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Remove_ThrowsException_WhenDBIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => extendedDB.Remove());
        }

        [Test]
        public void Remove_RemoveElementFromDB()
        {
            int n = 5;
            for (int i = 0; i < n; i++)
            {
                extendedDB.Add(new Person(i, $"Username{i}"));
            }

            extendedDB.Remove();

            Assert.That(extendedDB.Count, Is.EqualTo(n - 1));

            Assert.Throws<InvalidOperationException>(() => extendedDB.FindById(n - 1));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void FindByUserName_ThrowsExeption_WhenArgumentIsNotValid(string username)
        {
            Assert.Throws<ArgumentNullException>(() => extendedDB.FindByUsername(username));
        }

        [Test]
        public void FindByUserName_ThrowsExeption_WhenUsernameNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => extendedDB.FindByUsername("Username"));
        }

        [Test]
        public void FindByUserName_ReternExpectedUser_WhenUsertExist()
        {
            Person person = new Person(1, "SU");
            extendedDB.Add(person);

            Person dbPerson = extendedDB.FindByUsername(person.UserName);

            Assert.That(person, Is.EqualTo(dbPerson));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-25)]
        public void FindById_ThrowsExeption_WhenIdLessThanZero(int id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => extendedDB.FindById(id));
        }

        [Test]
        public void FindById_ThrowsExeption_WhenUserWithIdNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => extendedDB.FindById(100));
        }

        [Test]
        public void FindId_ReturnsExpecteduser_WhenUserExists()
        {
            Person person = new Person(1, "SU");
            extendedDB.Add(person);

            Person dbPerson = extendedDB.FindById(person.Id);

            Assert.That(person, Is.EqualTo(dbPerson));
        }
    }
}
