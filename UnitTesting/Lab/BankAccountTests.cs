using NUnit.Framework;
using System;

namespace Bank.Tests
{
    [TestFixture]
    public class BankAccountTests
    {
        [Test]
        public void WhenAccountInitialiedWithPossitiveValue_AmountChanged()
        {
            decimal amount = 5;

            BankAccount bankAccount = new BankAccount(amount);

            Assert.That(bankAccount.Amount, Is.EqualTo(amount));
            Assert.AreEqual(bankAccount.Amount, amount);
            Assert.IsTrue(bankAccount.Amount == amount);
        }
    }
}
