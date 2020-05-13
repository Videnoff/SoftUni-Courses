using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Chainblock.Common;
using Chainblock.Contracts;
using Chainblock.Models;
using NUnit.Framework;
using Chainblock = Chainblock.Core.Chainblock;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainblockTests
    {
        private IChainblock chainblock;
        private ITransaction testTransaction;

        [SetUp]
        public void SetUp()
        {
            this.chainblock = new Core.Chainblock();
            this.testTransaction = new Transaction(1, TransactionStatus.Unauthorized, "Pesho", "Gosho", 10);
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            int expectedInitialCount = 0;

            IChainblock chainblock = new Core.Chainblock();

            Assert.AreEqual(expectedInitialCount, chainblock.Count);
        }

        [Test]
        public void AddShouldIncreaseCountWhenSuccess()
        {
            int expectedCount = 1;

            ITransaction transaction = new Transaction(1, TransactionStatus.Successfull, "Pesho", "Gosho", 10);

            this.chainblock.Add(transaction);

            Assert.AreEqual(expectedCount, this.chainblock.Count);
        }

        [Test]
        public void AddingExistingTransactionShouldThrowAnException()
        {
            int expectedCount = 1;

            ITransaction transaction = new Transaction(1, TransactionStatus.Successfull, "Pesho", "Gosho", 10);

            this.chainblock.Add(transaction);

            Assert.That(() => { this.chainblock.Add(transaction); },
                Throws.InvalidOperationException.With.Message.EqualTo(
                    ExceptionMessages.AddingExistingTransactionMessage));
        }

        [Test]
        public void AddingSameTransactionWithAnotherIdShouldPass()
        {
            var expectedCount = 2;

            var ts = TransactionStatus.Successfull;
            var from = "Pesho";
            var to = "Gosho";
            var amount = 10;

            ITransaction transaction = new Transaction(1, ts, from, to, amount);

            ITransaction transactionCopy = new Transaction(2, ts, from, to, amount);

            this.chainblock.Add(transaction);
            this.chainblock.Add(transactionCopy);

            Assert.AreEqual(expectedCount, this.chainblock.Count);
        }

        [Test]
        public void ContainsByTransactionShouldReturnTrueWithExistingTransaction()
        {
            var id = 1;
            var ts = TransactionStatus.Failed;
            var from = "Pesho";
            var to = "Gosho";
            var amount = 10;

            ITransaction transaction = new Transaction(id, ts, from, to, amount);

            this.chainblock.Add(transaction);

            Assert.IsTrue(this.chainblock.Contains(transaction));
        }

        [Test]
        public void ContainsByTransactionShouldReturnFalseWithNonExistingTransaction()
        {
            var id = 1;
            var ts = TransactionStatus.Failed;
            var from = "Pesho";
            var to = "Gosho";
            var amount = 10;

            ITransaction transaction = new Transaction(id, ts, from, to, amount);

            //this.chainblock.Add(transaction);

            Assert.IsFalse(this.chainblock.Contains(transaction));
        }

        [Test]
        public void ContainsByIdShouldReturnTrueWithExistingTransaction()
        {
            var id = 1;
            var ts = TransactionStatus.Failed;
            var from = "Pesho";
            var to = "Gosho";
            var amount = 10;

            ITransaction transaction = new Transaction(id, ts, from, to, amount);

            this.chainblock.Add(transaction);

            Assert.IsTrue(this.chainblock.Contains(id));
        }

        [Test]
        public void ContainsByIdShouldReturnFalseWithNonExistingTransaction()
        {
            var id = 1;
            var ts = TransactionStatus.Failed;
            var from = "Pesho";
            var to = "Gosho";
            var amount = 10;

            ITransaction transaction = new Transaction(id, ts, from, to, amount);

            //this.chainblock.Add(transaction);

            Assert.IsFalse(this.chainblock.Contains(id));
        }

        [Test]
        public void TestChangingTransactionStatusOfExistingTransaction()
        {
            var id = 1;
            var ts = TransactionStatus.Unauthorized;
            var from = "Pesho";
            var to = "Gosho";
            var amount = 10;

            var newStatus = TransactionStatus.Successfull;

            ITransaction transaction = new Transaction(id, ts, from, to, amount);

            this.chainblock.Add(transaction);

            this.chainblock.ChangeTransactionStatus(id, newStatus);

            Assert.AreEqual(newStatus, transaction.Status);
        }

        [Test]
        public void TestChangingTransactionStatusOfNonExistingTransactionShouldThrowException()
        {
            var id = 1;
            var ts = TransactionStatus.Unauthorized;
            var from = "Pesho";
            var to = "Gosho";
            var amount = 10;

            var fakeId = 13;

            var newStatus = TransactionStatus.Successfull;

            ITransaction transaction = new Transaction(id, ts, from, to, amount);

            this.chainblock.Add(transaction);

            Assert.That(() => { this.chainblock.ChangeTransactionStatus(fakeId, newStatus); },
                Throws.ArgumentException.With.Message.EqualTo(ExceptionMessages
                    .ChangingStatusOfNonExistingTransactionMessage));
        }

        [Test]
        public void GetByIdShouldReturnCorrectTransaction()
        {
            var id = 2;
            var ts = TransactionStatus.Successfull;
            var from = "Sender";
            var to = "Receiver";
            var amount = 20;

            ITransaction transaction = new Transaction(id, ts, from, to, amount);

            this.chainblock.Add(transaction);
            this.chainblock.Add(testTransaction);

            ITransaction returnedTransaction = this.chainblock.GetById(id);

            Assert.AreEqual(transaction, returnedTransaction);
        }

        [Test]
        public void GetByIdShouldThrowExceptionWhenTryingToFindNonExistingTransaction()
        {
            var id = 2;
            var ts = TransactionStatus.Successfull;
            var from = "Sender";
            var to = "Receiver";
            var amount = 20;

            var fakeId = 13;

            ITransaction transaction = new Transaction(id, ts, from, to, amount);

            this.chainblock.Add(transaction);
            this.chainblock.Add(testTransaction);

            Assert.That(() => { this.chainblock.GetById(fakeId); },
                Throws.InvalidOperationException.With.Message.EqualTo(ExceptionMessages.NonExistingTransactionMessage));
        }

        [Test]
        public void RemovingTransactionShouldDecreaseCount()
        {
            var id = 2;
            var ts = TransactionStatus.Successfull;
            var from = "Gosho";
            var to = "Pesho";
            var amount = 250;

            var expectedCount = 1;

            ITransaction transaction = new Transaction(id, ts, from, to, amount);

            this.chainblock.Add(transaction);
            this.chainblock.Add(testTransaction);

            this.chainblock.RemoveTransactionById(id);

            Assert.AreEqual(expectedCount, this.chainblock.Count);
        }

        [Test]
        public void RemovingTransactionShouldPhysicallyRemoveTheTransaction()
        {
            var id = 2;
            var ts = TransactionStatus.Successfull;
            var from = "Gosho";
            var to = "Pesho";
            var amount = 250;

            ITransaction transaction = new Transaction(id, ts, from, to, amount);

            this.chainblock.Add(transaction);
            this.chainblock.Add(testTransaction);

            this.chainblock.RemoveTransactionById(id);

            Assert.That(() => { this.chainblock.GetById(id); },
                Throws.InvalidOperationException.With.Message.EqualTo(ExceptionMessages.NonExistingTransactionMessage));
        }

        [Test]
        public void RemovingNonExistingTransactionShouldThrowException()
        {
            var id = 2;
            var ts = TransactionStatus.Successfull;
            var from = "Gosho";
            var to = "Pesho";
            var amount = 250;

            var fakeId = 13;

            ITransaction transaction = new Transaction(id, ts, from, to, amount);

            this.chainblock.Add(transaction);
            this.chainblock.Add(testTransaction);

            this.chainblock.RemoveTransactionById(id);

            Assert.That(() => { this.chainblock.RemoveTransactionById(fakeId); },
                Throws.InvalidOperationException.With.Message.EqualTo(ExceptionMessages
                    .RemovingNonExistingTransactionMessage));
        }

        [Test]
        public void GetByTransactionStatusShouldReturnOrderedCollectionWithRightTransactions()
        {
            ICollection<ITransaction> transactions = new List<ITransaction>();

            for (int i = 0; i < 4; i++)
            {
                var id = i + 1;
                var ts = (TransactionStatus) i;
                var from = "Pesho" + i;
                var to = "Gosho" + i;
                var amount = 10;

                ITransaction currentTransaction = new Transaction(id, ts, from, to, amount);

                if (ts == TransactionStatus.Successfull)
                {
                    transactions.Add(currentTransaction);
                }

                this.chainblock.Add(currentTransaction);
            }

            ITransaction succTransaction = new Transaction(5, TransactionStatus.Successfull, "Pesho4", "Gosho4", 15);

            transactions.Add(succTransaction);

            this.chainblock.Add(succTransaction);

            IEnumerable<ITransaction> actTransactions =
                this.chainblock.GetByTransactionStatus(TransactionStatus.Successfull);

            transactions = transactions.OrderByDescending(tx => tx.Amount).ToList();

            CollectionAssert.AreEqual(transactions, actTransactions);
        }

        [Test]
        public void GettingTransactionWithNoExistingStatus()
        {
            ICollection<ITransaction> transactions = new List<ITransaction>();

            for (int i = 0; i < 4; i++)
            {
                var id = i + 1;
                var ts = TransactionStatus.Failed;
                var from = "Pesho" + i;
                var to = "Gosho" + i;
                var amount = 10 * (i + 1);

                ITransaction currentTransaction = new Transaction(id, ts, from, to, amount);
            }

            Assert.That(() => { this.chainblock.GetByTransactionStatus(TransactionStatus.Successfull); },
                Throws.InvalidOperationException.With.Message.EqualTo(
                    ExceptionMessages.EmptyStatusTransactionCollection));
        }

        [Test]
        public void AllSendersByStatusShouldReturnOrderedCollection()
        {
            ICollection<ITransaction> transactions = new List<ITransaction>();

            for (int i = 0; i < 4; i++)
            {
                var id = i + 1;
                var ts = (TransactionStatus) i;
                var from = "Pesho" + i;
                var to = "Gosho" + i;
                var amount = 10;

                ITransaction currentTransaction = new Transaction(id, ts, from, to, amount);

                if (ts == TransactionStatus.Successfull)
                {
                    transactions.Add(currentTransaction);
                }

                this.chainblock.Add(currentTransaction);
            }

            ITransaction succTransaction = new Transaction(5, TransactionStatus.Successfull, "Pesho4", "Gosho4", 15);

            transactions.Add(succTransaction);

            this.chainblock.Add(succTransaction);

            IEnumerable<string> actTransactionsOutput = this.chainblock
                .GetAllSendersWithTransactionStatus(TransactionStatus.Successfull);

            IEnumerable<string> expTransactionsOutput = transactions
                .OrderByDescending(tx => tx.Amount)
                .Select(tx => tx.From);


            CollectionAssert.AreEqual(expTransactionsOutput, actTransactionsOutput);
        }

        [Test]
        public void AllSendersByStatusShouldThrowAnExceptionWhenThereAreNoTransactionWithGivenStatus()
        {
            ICollection<ITransaction> transactions = new List<ITransaction>();

            for (int i = 0; i < 10; i++)
            {
                var id = i + 1;
                var ts = TransactionStatus.Failed;
                var from = "Pesho" + i;
                var to = "Gosho" + i;
                var amount = 10 * (i + 1);

                ITransaction currentTransaction = new Transaction(id, ts, from, to, amount);

                this.chainblock.Add(currentTransaction);
            }

            Assert.That(() =>
            {
                this.chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull);
            }, Throws.InvalidOperationException.With.Message.EqualTo(ExceptionMessages.EmptyStatusTransactionCollection));
        }

        [Test]
        public void AllReceiversByStatusShouldReturnOrderedCollection()
        {
            ICollection<ITransaction> transactions = new List<ITransaction>();

            for (int i = 0; i < 4; i++)
            {
                var id = i + 1;
                var ts = (TransactionStatus)i;
                var from = "Pesho" + i;
                var to = "Gosho" + i;
                var amount = 10;

                ITransaction currentTransaction = new Transaction(id, ts, from, to, amount);

                if (ts == TransactionStatus.Successfull)
                {
                    transactions.Add(currentTransaction);
                }

                this.chainblock.Add(currentTransaction);
            }

            ITransaction succTransaction = new Transaction(5, TransactionStatus.Successfull, "Pesho4", "Gosho4", 15);

            transactions.Add(succTransaction);

            this.chainblock.Add(succTransaction);

            IEnumerable<string> actTransactionsOutput = this.chainblock
                .GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull);

            IEnumerable<string> expTransactionsOutput = transactions
                .OrderByDescending(tx => tx.Amount)
                .Select(tx => tx.To);


            CollectionAssert.AreEqual(expTransactionsOutput, actTransactionsOutput);
        }

        [Test]
        public void AllReceiversByStatusShouldThrowAnExceptionWhenThereAreNoTransactionWithGivenStatus()
        {
            ICollection<ITransaction> transactions = new List<ITransaction>();

            for (int i = 0; i < 10; i++)
            {
                var id = i + 1;
                var ts = TransactionStatus.Failed;
                var from = "Pesho" + i;
                var to = "Gosho" + i;
                var amount = 10 * (i + 1);

                ITransaction currentTransaction = new Transaction(id, ts, from, to, amount);

                this.chainblock.Add(currentTransaction);
            }

            Assert.That(() =>
            {
                this.chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull);
            }, Throws.InvalidOperationException.With.Message.EqualTo(ExceptionMessages.EmptyStatusTransactionCollection));
        }

        [Test]
        public void GetAllOrderedByAmountThenByIdWithNoDuplicatedAmounts()
        {
            ICollection<ITransaction> expTransactions = new List<ITransaction>();

            for (int i = 0; i < 10; i++)
            {
                var id = i + 1;
                var ts = (TransactionStatus)(i % 4);
                var from = "Pesho" + i;
                var to = "Gosho" + i;
                var amount = 10 + i;

                ITransaction currentTransaction = new Transaction(id, ts, from, to, amount);

                this.chainblock.Add(currentTransaction);
                expTransactions.Add(currentTransaction);
            }

            IEnumerable<ITransaction> actualTransactions = this.chainblock.GetAllOrderedByAmountDescendingThenById();

            expTransactions = expTransactions
                .OrderByDescending(tx => tx.Amount)
                .ThenBy(tx => tx.Id)
                .ToList();

            CollectionAssert.AreEqual(expTransactions, actualTransactions);
        }

        [Test]
        public void GetAllOrderedByAmountThenByIdWithDuplicatedAmounts()
        {
            ICollection<ITransaction> expTransactions = new List<ITransaction>();

            for (int i = 0; i < 10; i++)
            {
                var id = i + 1;
                var ts = (TransactionStatus)(i % 4);
                var from = "Pesho" + i;
                var to = "Gosho" + i;
                var amount = 10 + i;

                ITransaction currentTransaction = new Transaction(id, ts, from, to, amount);

                this.chainblock.Add(currentTransaction);
                expTransactions.Add(currentTransaction);
            }

            ITransaction transaction = new Transaction(11, TransactionStatus.Successfull, "Gosho11", "Pesho11", 10);

            this.chainblock.Add(transaction);

            expTransactions.Add(transaction);

            IEnumerable<ITransaction> actualTransactions = this.chainblock.GetAllOrderedByAmountDescendingThenById();

            expTransactions = expTransactions
                .OrderByDescending(tx => tx.Amount)
                .ThenBy(tx => tx.Id)
                .ToList();

            CollectionAssert.AreEqual(expTransactions, actualTransactions);
        }

        [Test]
        public void GetAllOrderedByAmountThenByIdWithEmptyCollection()
        {
            IEnumerable<ITransaction> actualTransactions = this.chainblock.GetAllOrderedByAmountDescendingThenById();

            CollectionAssert.IsEmpty(actualTransactions);
        }

        [Test]
        public void TestIfGetBySenderOrderedByAmountDescendingWorksCorrectly()
        {
            ICollection<ITransaction> expTransactions = new List<ITransaction>();

            var wantedSender = "Pesho";

            for (int i = 0; i < 4; i++)
            {
                var id = i + 1;
                var ts = TransactionStatus.Successfull;
                var from = wantedSender;
                var to = "Gosho" + i;
                var amount = 10 + i;

                ITransaction currentTransaction = new Transaction(id, ts, from, to, amount);

                this.chainblock.Add(currentTransaction);
                expTransactions.Add(currentTransaction);
            }

            for (int i = 4; i < 10; i++)
            {
                var id = i + 1;
                var ts = TransactionStatus.Successfull;
                var from = "Pesho" + i;
                var to = "Gosho" + i;
                var amount = 20 + i;

                ITransaction currentTransaction = new Transaction(id, ts, from, to, amount);

                this.chainblock.Add(currentTransaction);
            }

            IEnumerable<ITransaction> actualTransactions = this.chainblock
                .GetBySenderOrderedByAmountDescending(wantedSender);

            expTransactions = expTransactions
                .OrderByDescending(tx => tx.Amount)
                .ToList();

            CollectionAssert.AreEqual(expTransactions, actualTransactions);
        }

        [Test]
        public void TestGetAllByNonExistingSenderDescendingByAmount()
        {
            ICollection<ITransaction> expTransactions = new List<ITransaction>();

            for (int i = 0; i < 4; i++)
            {
                var id = i + 1;
                var ts = TransactionStatus.Successfull;
                var from = "Pesho" + i;
                var to = "Gosho" + i;
                var amount = 10 + i;

                ITransaction currentTransaction = new Transaction(id, ts, from, to, amount);

                this.chainblock.Add(currentTransaction);
            }

            var wantedSender = "Pesho";

            Assert.That(() =>
            {
                this.chainblock.GetBySenderOrderedByAmountDescending(wantedSender);
            }, Throws.InvalidOperationException.With.Message.EqualTo(ExceptionMessages.NoTransactionForGivenSenderMessage));
        }

        [Test]
        public void TestIfGetByReceiverDescendingByAmountThenByIdWorksCorrectlyWithNoDuplicatedAmounts()
        {
            ICollection<ITransaction> expTransactions = new List<ITransaction>();

            var wantedReceiver = "Gosho";

            for (int i = 0; i < 4; i++)
            {
                var id = i + 1;
                var ts = TransactionStatus.Successfull;
                var from = "Pesho" + i;
                var to = wantedReceiver;
                var amount = 10 + i;

                ITransaction currentTransaction = new Transaction(id, ts, from, to, amount);

                this.chainblock.Add(currentTransaction);
                expTransactions.Add(currentTransaction);
            }

            for (int i = 4; i < 10; i++)
            {
                var id = i + 1;
                var ts = TransactionStatus.Successfull;
                var from = "Pesho" + i;
                var to = "Gosho" + i;
                var amount = 20 + i;

                ITransaction currentTransaction = new Transaction(id, ts, from, to, amount);

                this.chainblock.Add(currentTransaction);
            }

            IEnumerable<ITransaction> actTransactions = this.chainblock.GetByReceiverOrderedByAmountThenById(wantedReceiver);

            expTransactions = expTransactions
                .OrderByDescending(tx => tx.Amount)
                .ThenBy(tx => tx.Id)
                .ToList();

            CollectionAssert.AreEqual(expTransactions, actTransactions);
        }

        [Test]
        public void TestIfGetByReceiverDescendingByAmountThenByIdWorksCorrectlyWithDuplicatedAmounts()
        {
            ICollection<ITransaction> expTransactions = new List<ITransaction>();

            var wantedReceiver = "Gosho";

            for (int i = 0; i < 4; i++)
            {
                var id = i + 1;
                var ts = TransactionStatus.Successfull;
                var from = "Pesho" + i;
                var to = wantedReceiver;
                var amount = 10 + i;

                ITransaction currentTransaction = new Transaction(id, ts, from, to, amount);

                this.chainblock.Add(currentTransaction);
                expTransactions.Add(currentTransaction);
            }

            for (int i = 4; i < 10; i++)
            {
                var id = i + 1;
                var ts = TransactionStatus.Successfull;
                var from = "Pesho" + i;
                var to = "Gosho" + i;
                var amount = 20 + i;

                ITransaction currentTransaction = new Transaction(id, ts, from, to, amount);

                this.chainblock.Add(currentTransaction);
            }

            ITransaction transaction = new Transaction(11, TransactionStatus.Successfull, "Pesho11", wantedReceiver, 10);

            IEnumerable<ITransaction> actTransactions = this.chainblock.GetByReceiverOrderedByAmountThenById(wantedReceiver);

            expTransactions = expTransactions
                .OrderByDescending(tx => tx.Amount)
                .ThenBy(tx => tx.Id)
                .ToList();

            CollectionAssert.AreEqual(expTransactions, actTransactions);
        }

        [Test]
        public void GetByReceiverDescendingByAmountThenByIdShouldThrowExceptionWhenNotransactionsFound()
        {
            ICollection<ITransaction> expTransactions = new List<ITransaction>();

            var wantedReceiver = "Gosho";

            for (int i = 0; i < 4; i++)
            {
                var id = i + 1;
                var ts = TransactionStatus.Successfull;
                var from = "Pesho" + i;
                var to = "Gosho" + i;
                var amount = 10 + i;

                ITransaction currentTransaction = new Transaction(id, ts, from, to, amount);

                this.chainblock.Add(currentTransaction);
            }

            Assert.That(() =>
            {
                this.chainblock.GetByReceiverOrderedByAmountThenById(wantedReceiver);
            }, Throws.InvalidOperationException.With.Message.EqualTo(ExceptionMessages.NoTransactionForGivenReceiverMessage));
        }

        [Test]
        public void TestChainblockEnumerator()
        {
            ICollection<ITransaction> addTr = new List<ITransaction>();

            ICollection<ITransaction> actTr = new List<ITransaction>();

            for (int i = 0; i < 4; i++)
            {
                var id = i + 1;
                var ts = TransactionStatus.Successfull;
                var from = "Pesho" + i;
                var to = "Gosho" + i;
                double amount = 10 + i;

                ITransaction currTr = new Transaction(id, ts, from, to, amount);
                addTr.Add(currTr);

                this.chainblock.Add(currTr);
            }

            foreach (var tr in this.chainblock)
            {
                actTr.Add(tr);
            }

            CollectionAssert.AreEqual(addTr, actTr);
        }
    }
}