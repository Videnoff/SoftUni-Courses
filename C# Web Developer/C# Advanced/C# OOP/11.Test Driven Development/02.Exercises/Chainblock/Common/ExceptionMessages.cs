namespace Chainblock.Common
{
    public static class ExceptionMessages
    {
        public static string InvalidMessage = $"IDs cannot be zero or negative!";

        public static string InvalidSenderUsernameMessage = $"Sender name cannot be empty or whitespace!";

        public static string InvalidReceiverUsernameMessage = $"Receiver name cannot be empty or whitespace!";

        public static string InvalidTransactionAmountMessage = $"Transaction amount should be greater than 0!";

        public static string AddingExistingTransactionMessage = $"Transaction already exists in our records!";

        public static string ChangingStatusOfNonExistingTransactionMessage = $"You can't change the status of non existing transaction!";

        public static string NonExistingTransactionMessage = $"Transaction with given ID not found!";

        public static string RemovingNonExistingTransactionMessage = $"You cannot remove non existing transaction!";

        public static string EmptyStatusTransactionCollection = $"There are not transactions matching provided transaction status!";

        public static string NoTransactionForGivenSenderMessage= $"There are no corresponding transactions to given sender name!";

        public static string NoTransactionForGivenReceiverMessage= $"There are no corresponding transactions to given receiver name!";
    }
}