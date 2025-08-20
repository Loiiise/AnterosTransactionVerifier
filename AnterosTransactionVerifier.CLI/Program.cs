using AnterosTransactionVerifier.CLI;
using AnterosTransactionVerifier.Logic;
using AnterosTransactionVerifier.Services.FileHandling;
using AnterosTransactionVerifier.Services.TransactionConversion.Stringification;
using AnterosTransactionVerifier.Services.TransactionWriting;
using Microsoft.Extensions.Configuration;

var fullConfig = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();
var configuration = fullConfig.Get<Configuration>()!;

var transactionWriter = new FileTransactionWriter(
    new BasicFileWriter(
        configuration.OutputFileLocation,
        TransactionStringifier.Format),
    new TransactionStringifier());

var bank = new TransactionHandler(configuration.Bank);
var bookkeeping = new TransactionHandler(configuration.Bookkeeping);

bank.GenerateDictionairy();
bookkeeping.GenerateDictionairy();

WriteAnalysisLine(bank.Transactions, bank.Name);
WriteAnalysisLine(bookkeeping.Transactions, bookkeeping.Name);

var unmatchedBankTransactions = new List<Transaction>();
var unmatchedBookkeepingTransactions = new List<Transaction>();

foreach (var amount in bank.TransactionByAmount.Keys)
{
    var bankTransactions = bank.TransactionByAmount.GetValueOrDefault(amount) ?? new List<Transaction>();
    var bookkeepingTransactions = bookkeeping.TransactionByAmount.GetValueOrDefault(amount) ?? new List<Transaction>();

    if (bankTransactions.Count == bookkeepingTransactions.Count) continue;

    unmatchedBankTransactions.AddRange(bankTransactions);
}

foreach (var amount in bookkeeping.TransactionByAmount.Keys)
{
    var bookkeepingTransactions = bookkeeping.TransactionByAmount.GetValueOrDefault(amount) ?? new List<Transaction>();
    var bankTransactions = bank.TransactionByAmount.GetValueOrDefault(amount) ?? new List<Transaction>();

    if (bankTransactions.Count == bookkeepingTransactions.Count) continue;

    unmatchedBookkeepingTransactions.AddRange(bookkeepingTransactions);
}

if (!unmatchedBankTransactions.Any() ||
    !unmatchedBookkeepingTransactions.Any())
{
    Console.WriteLine("All transactions match!");
    return;
}

Console.WriteLine("Unable to match all transactions one on one. Attempting multiples matching...");
WriteAnalysisLine(unmatchedBankTransactions, "unmatched " + bank.Name);
WriteAnalysisLine(unmatchedBookkeepingTransactions, "unmatched " + bookkeeping.Name);

// Todo: match batches manually. Needed in datatypes for that

void WriteAnalysisLine(List<Transaction> transactions, string name) => Console.WriteLine($"Analysing {transactions.Count} {name} transactions with a total value of {transactions.Sum(t => t.Amount)} euros");

