using AnterosTransactionVerifier.Logic;

namespace AnterosTransactionVerifier.Services.TransactionReading;

public interface ITransactionReader
{
    Task<IEnumerable<Transaction>> ReadAllTransactions();
}
