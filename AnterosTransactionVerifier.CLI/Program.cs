using AnterosTransactionVerifier.CLI;
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




