using AnterosTransactionVerifier.Logic;
using AnterosTransactionVerifier.Services.FileHandling;
using AnterosTransactionVerifier.Services.TransactionConversion.Parsing;

namespace AnterosTransactionVerifier.Services.TransactionReading;

public class BasicTransactionReader : ITransactionReader
{
    private readonly IStaticFileReader _fileReader;
    private readonly ITransactionParser _parser;

    public BasicTransactionReader(IStaticFileReader fileReader, ITransactionParser parser)
    {
        _fileReader = fileReader ?? throw new ArgumentNullException(nameof(fileReader));
        _parser = parser ?? throw new ArgumentNullException(nameof(parser));
    }

    public Task<IEnumerable<Transaction>> ReadAllTransactions()
        => Task.Run(() => _fileReader.ReadAllLines().Select(_parser.Parse));
}
