using AnterosTransactionVerifier.Logic;

namespace AnterosTransactionVerifier.Services.TransactionReading;

public interface ITransactionReader
{
    IEnumerable<Transaction> ReadAllTransactions();
}
