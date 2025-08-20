using AnterosTransactionVerifier.Services.TransactionReading;
using AnterosTransactionVerifier.Services.TransactionWriting;
using Microsoft.Extensions.Hosting;

namespace AnterosTransactionVerifier.CLI;

internal class TransactionVerificator : BackgroundService
{
    private readonly ITransactionReader _bankTransactionReader;
    private readonly ITransactionReader _bookkeepingTransactionReader;
    private readonly ITransactionWriter _transactionWriter;

    public TransactionVerificator(
        ITransactionReader bankTransactionReader,
        ITransactionReader bookkeepingTransactionReader,
        ITransactionWriter transactionWriter
        )
    {
        _bankTransactionReader = bankTransactionReader;
        _bookkeepingTransactionReader = bookkeepingTransactionReader;
        _transactionWriter = transactionWriter;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        throw new NotImplementedException();
    }
}
