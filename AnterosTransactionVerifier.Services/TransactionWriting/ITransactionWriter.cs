using AnterosTransactionVerifier.Logic;

namespace AnterosTransactionVerifier.Services.TransactionWriting;

public interface ITransactionWriter
{
    public void Write(Transaction transaction);
    public void Write(IEnumerable<Transaction> transactions);
}
