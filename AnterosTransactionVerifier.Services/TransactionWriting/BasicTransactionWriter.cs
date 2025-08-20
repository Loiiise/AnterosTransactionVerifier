using AnterosTransactionVerifier.Logic;

namespace AnterosTransactionVerifier.Services.TransactionWriting;

public class BasicTransactionWriter : ITransactionWriter
{
    public Task Write(Transaction transaction)
    {
        throw new NotImplementedException();
    }

    public Task Write(IEnumerable<Transaction> transactions)
    {
        throw new NotImplementedException();
    }
}
