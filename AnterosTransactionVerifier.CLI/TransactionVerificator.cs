using AnterosTransactionVerifier.Services.FileReading;
using AnterosTransactionVerifier.Services.FileWriting;
using AnterosTransactionVerifier.Services.TransactionParsingService;
using Microsoft.Extensions.Hosting;

namespace AnterosTransactionVerifier.CLI;

internal class TransactionVerificator : BackgroundService
{
    private readonly ITransactionParser _parser;
    private readonly IFileReader _fileReader;
    private readonly ITransactionWriter _fileWriter;

    public TransactionVerificator(
        ITransactionParser parser,
        IFileReader fileReader,
        ITransactionWriter fileWriter
        )
    {
        _parser = parser;
        _fileReader = fileReader;
        _fileWriter = fileWriter;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        throw new NotImplementedException();
    }
}
