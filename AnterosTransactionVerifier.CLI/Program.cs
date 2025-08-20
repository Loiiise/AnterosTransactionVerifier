using AnterosTransactionVerifier.CLI;
using AnterosTransactionVerifier.Logic;
using AnterosTransactionVerifier.Services.FileHandling;
using AnterosTransactionVerifier.Services.TransactionConversion.Parsing;
using AnterosTransactionVerifier.Services.TransactionReading;
using AnterosTransactionVerifier.Services.TransactionWriting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

var configuration = config.Get<Configuration>()!;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSingleton<ITransactionWriter, BasicTransactionWriter>();

builder.Services.AddHostedService(services => new TransactionVerificator(
    GenerateTransactionReader(configuration.Bank),
    GenerateTransactionReader(configuration.Bookkeeping),
    services.GetService<ITransactionWriter>()!));

using IHost host = builder.Build();
host.Run();

ITransactionReader GenerateTransactionReader(TransactionConfiguration transactionConfiguration)
    => new BasicTransactionReader(
        new BasicFileReader(transactionConfiguration.TransactionFileLocation, transactionConfiguration.SkipFirstLine),
        new TransactionParser(transactionConfiguration.ToParserConfiguration()));