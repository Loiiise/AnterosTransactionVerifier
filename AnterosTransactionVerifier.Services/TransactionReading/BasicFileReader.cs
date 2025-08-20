using AnterosTransactionVerifier.Logic;
using AnterosTransactionVerifier.Services.FileHandling;
using AnterosTransactionVerifier.Services.TransactionParsingService;

namespace AnterosTransactionVerifier.Services.TransactionReading;

public class BasicFileReader : ITransactionReader
{
    private readonly IFileReader _fileReader;
    private readonly ITransactionParser _parser;

    public BasicFileReader(IFileReader fileReader, ITransactionParser parser)
    {
        _fileReader = fileReader ?? throw new ArgumentNullException(nameof(fileReader));
        _parser = parser ?? throw new ArgumentNullException(nameof(parser));
    }

    public Task<IEnumerable<Transaction>> ReadAllTransactions()
        => Task.Run(() => _fileReader.ReadAllLines().Select(_parser.Parse));
}
