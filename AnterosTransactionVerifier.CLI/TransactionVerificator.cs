using AnterosTransactionVerifier.Services.File;
using AnterosTransactionVerifier.Services.TransactionParsingService;
using Microsoft.Extensions.Hosting;

namespace AnterosTransactionVerifier.CLI;

internal class TransactionVerificator : BackgroundService
{
    private readonly IParser _parser;
    private readonly IFileReader _fileReader;
    private readonly IFileWriter _fileWriter;

    public TransactionVerificator(
        IParser parser,
        IFileReader fileReader,
        IFileWriter fileWriter
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
