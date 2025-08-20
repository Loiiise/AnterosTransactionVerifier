using AnterosTransactionVerifier.Logic;
using AnterosTransactionVerifier.Services.FileHandling;
using AnterosTransactionVerifier.Services.TransactionConversion.Parsing;

namespace AnterosTransactionVerifier.Services.TransactionReading;

public class FileTransactionReader : ITransactionReader
{
    private readonly IStaticFileReader _fileReader;
    private readonly ITransactionParser _parser;

    public FileTransactionReader(IStaticFileReader fileReader, ITransactionParser parser)
    {
        _fileReader = fileReader ?? throw new ArgumentNullException(nameof(fileReader));
        _parser = parser ?? throw new ArgumentNullException(nameof(parser));
    }

    public Task<IEnumerable<Transaction>> ReadAllTransactions()
        => Task.Run(() => _fileReader.ReadAllLines().Select(_parser.Parse));
}
