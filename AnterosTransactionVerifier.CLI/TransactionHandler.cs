using AnterosTransactionVerifier.Logic;
using AnterosTransactionVerifier.Services.FileHandling;
using AnterosTransactionVerifier.Services.TransactionConversion.Parsing;
using AnterosTransactionVerifier.Services.TransactionReading;

namespace AnterosTransactionVerifier.CLI;
internal class TransactionHandler
{
    public List<Transaction> Transactions { get; set; } = new();
    public Dictionary<decimal, List<Transaction>> TransactionByAmount { get; private set; } = new();
    private readonly TransactionConfiguration _transactionConfiguration;
    private readonly ITransactionReader _transactionReader;

    internal TransactionHandler(TransactionConfiguration transactionConfiguration)
    {
        _transactionConfiguration = transactionConfiguration;
        _transactionReader = new FileTransactionReader(
            new BasicFileReader(transactionConfiguration.TransactionFileLocation, transactionConfiguration.SkipFirstLine),
            new TransactionParser(transactionConfiguration.ToParserConfiguration()));
    }

    internal void GenerateDictionairy()
    {
        Transactions = _transactionReader.ReadAllTransactions().ToList();
        TransactionByAmount = Transactions
            .GroupBy(t => t.Amount)
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    public string AnalysisLine() => $"Analysing {Transactions.Count} bank transactions with a total value of {Transactions.Sum(t => t.Amount)} euros";
}
