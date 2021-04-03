using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault vault;
        private Item item;

        [SetUp]
        public void Setup()
        {
            vault = new BankVault();
            item = new Item("me", "1");
        }

        //--Ctor tests--
        [Test]
        public void Ctor_WhenVaultIsInitialised_ShouldHaveCorrectCells()
        {
            var initialValue = new Dictionary<string, Item>
            {
                {"A1", null},
                {"A2", null},
                {"A3", null},
                {"A4", null},
                {"B1", null},
                {"B2", null},
                {"B3", null},
                {"B4", null},
                {"C1", null},
                {"C2", null},
                {"C3", null},
                {"C4", null},
            };

            //create a list with key:value pairs from initialDictionary
            var initialValuesAsList = initialValue.ToImmutableDictionary().ToList();

            var vaultValuesAsList = vault.VaultCells.ToList();

            for (int i = 0; i < initialValuesAsList.Count; i++)
            {
                Assert.AreEqual(initialValuesAsList[i].Key, vaultValuesAsList[i].Key);
                Assert.AreEqual(initialValuesAsList[i].Value, vaultValuesAsList[i].Value);
            }
        }

        //--Methods tests--
        [Test]
        public void WhenCellNotExist_ShouldTrhrowException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                vault.AddItem("missing1", item);
            });
            Assert.AreEqual(ex.Message, "Cell doesn't exists!");
        }

        [Test]
        public void WhenCellIsAlredyExistNotNull_ShouldTrhrowException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                vault.AddItem("A2", item);
                vault.AddItem("A2", new Item("Pesho", "3"));
            });
            Assert.AreEqual(ex.Message, "Cell is already taken!");
        }

        [Test]
        public void WhenItemAlreadyExcist_ShouldThrowExceprion()
        {
            Exception ex = Assert.Throws<InvalidOperationException>(() =>
            {
                vault.AddItem("A2", item);
                vault.AddItem("B3", item);
            });
            Assert.AreEqual(ex.Message, "Item is already in cell!");
        }

        [Test]
        public void WhenItemIsAdded_ShouldReturnCorrectMessage()
        {
            string result = vault.AddItem("A2", item);

            Assert.AreEqual(result, $"Item:{item.ItemId} saved successfully!");
        }

        [Test]
        public void WhenItemIsAdded_ShouldSetItemCorrectly()
        {
            vault.AddItem("A2", item);

            Assert.AreEqual(item, vault.VaultCells["A2"]);
        }

        [Test]
        public void WhenRemoveAndCellNotExist_ShouldTrhrowException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                vault.RemoveItem("missing1", item);
            });
            Assert.AreEqual(ex.Message, "Cell doesn't exists!");
        }

        [Test]
        public void WhenRemoveAndItemNotExist_ShouldTrhrowException()
        {
            Exception ex = Assert.Throws<ArgumentException>(() =>
            {
                vault.RemoveItem("A2", item);
            });
            Assert.AreEqual(ex.Message, $"Item in that cell doesn't exists!");
        }

        [Test]
        public void WhenItemIsRemoved_ShouldReturnCorrectMessage()
        {
            vault.AddItem("A2", item);
            string result = vault.RemoveItem("A2", item);

            Assert.AreEqual(result, $"Remove item:{item.ItemId} successfully!");
        }

        [Test]
        public void WhenItemIsRemoved_ShouldMakeCellNull()
        {
            vault.AddItem("A2", item);

            vault.RemoveItem("A2", item);

            Assert.AreEqual(null, vault.VaultCells["A2"]);
        }
    }
}