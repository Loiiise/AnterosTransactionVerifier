using AnterosTransactionVerifier.Logic;
using AnterosTransactionVerifier.Services.FileHandling;
using AnterosTransactionVerifier.Services.TransactionConversion.Parsing;
using AnterosTransactionVerifier.Services.TransactionReading;

namespace AnterosTransactionVerifier.CLI;
internal class TransactionHandler
{
    private readonly TransactionConfiguration _transactionConfiguration;
    private readonly ITransactionReader _transactionReader;

    internal TransactionHandler(TransactionConfiguration transactionConfiguration)
    {
        _transactionConfiguration = transactionConfiguration;
        _transactionReader = new FileTransactionReader(
            new BasicFileReader(transactionConfiguration.TransactionFileLocation, transactionConfiguration.SkipFirstLine),
            new TransactionParser(transactionConfiguration.ToParserConfiguration()));
    }
}
