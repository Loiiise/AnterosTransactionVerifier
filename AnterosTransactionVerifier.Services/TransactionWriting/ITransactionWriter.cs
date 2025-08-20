using AnterosTransactionVerifier.Logic;

namespace AnterosTransactionVerifier.Services.TransactionWriting;

public interface ITransactionWriter
{
    public Task Write(Transaction transaction);
    public Task Write(IEnumerable<Transaction> transactions);
}
