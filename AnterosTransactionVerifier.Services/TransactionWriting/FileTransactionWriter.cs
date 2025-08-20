using AnterosTransactionVerifier.Logic;
using AnterosTransactionVerifier.Services.FileHandling;
using AnterosTransactionVerifier.Services.TransactionConversion.Stringification;

namespace AnterosTransactionVerifier.Services.TransactionWriting;

public class FileTransactionWriter : ITransactionWriter
{
    private readonly IStaticFileWriter _fileWriter;
    private readonly ITransactionStringifier _transactionStringifier;

    public FileTransactionWriter(IStaticFileWriter fileWriter, ITransactionStringifier transactionStringifier)
    {
        _fileWriter = fileWriter ?? throw new ArgumentNullException(nameof(fileWriter));
        _transactionStringifier = transactionStringifier ?? throw new ArgumentNullException(nameof(transactionStringifier));
    }

    public Task Write(Transaction transaction)
    {
        throw new NotImplementedException();
    }

    public Task Write(IEnumerable<Transaction> transactions)
    {
        throw new NotImplementedException();
    }
}
