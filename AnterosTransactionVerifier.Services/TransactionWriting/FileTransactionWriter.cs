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

    public void Write(Transaction transaction) => Write(new[] { transaction });
    public void Write(IEnumerable<Transaction> transactions)
    {
        _fileWriter.WriteAllLines(transactions.Select(_transactionStringifier.Convert));
    }
}
