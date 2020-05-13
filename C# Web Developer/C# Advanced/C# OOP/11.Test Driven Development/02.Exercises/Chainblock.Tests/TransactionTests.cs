using Chainblock.Common;
using Chainblock.Contracts;
using Chainblock.Models;
using NUnit.Framework;

namespace Chainblock.Tests
{
    [TestFixture]

    public class TransactionTests
    {

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            var id = 1;
            var ts = TransactionStatus.Successfull;
            var from = "Pesho";
            var to = "Gosho";
            var amount = 15;

            ITransaction transaction = new Transaction(id, ts, from, to, amount);

            Assert.AreEqual(id, transaction.Id);
            Assert.AreEqual(ts, transaction.Status);
            Assert.AreEqual(from, transaction.From);
            Assert.AreEqual(to, transaction.To);
            Assert.AreEqual(amount, transaction.Amount);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-10)]
        public void TestIfWithLikeInvalidId(int id)
        {
            var ts = TransactionStatus.Successfull;
            var from = "Pesho";
            var to = "Gosho";
            var amount = 15;

            Assert.That(() =>
            {
                ITransaction transaction = new Transaction(id, ts, from, to, amount);
            }, Throws.ArgumentException.With.Message.EqualTo(ExceptionMessages.InvalidMessage));
        }

        [Test]
        [TestCase("")]
        [TestCase("          ")]
        [TestCase(null)]
        public void TestIfWithLikeInvalidSenderName(string from)
        {
            var id = 1;
            var ts = TransactionStatus.Successfull;
            var to = "Gosho";
            var amount = 15;
            
            Assert.That(() =>
            {
                ITransaction transaction = new Transaction(id, ts, from, to, amount);
            }, Throws.ArgumentException.With.Message.EqualTo(ExceptionMessages.InvalidSenderUsernameMessage));
        }

        [Test]
        [TestCase("")]
        [TestCase("          ")]
        [TestCase(null)]
        public void TestIfWithLikeInvalidReceiverName(string to)
        {
            var id = 1;
            var ts = TransactionStatus.Successfull;
            var from = "Pesho";
            var amount = 15;

            Assert.That(() =>
            {
                ITransaction transaction = new Transaction(id, ts, from, to, amount);
            }, Throws.ArgumentException.With.Message.EqualTo(ExceptionMessages.InvalidReceiverUsernameMessage));
        }

        [Test]
        [TestCase(-5.0)]
        [TestCase(-0.00000000)]
        [TestCase(0.0)]
        public void TestIfWithLikeInvalidAmount(double amount)
        {
            var id = 1;
            var ts = TransactionStatus.Successfull;
            var from = "Pesho";
            var to = "Gosho";

            Assert.That(() =>
            {
                ITransaction transaction = new Transaction(id, ts, from, to, amount);
            }, Throws.ArgumentException.With.Message.EqualTo(ExceptionMessages.InvalidTransactionAmountMessage));
        }
    }
}
