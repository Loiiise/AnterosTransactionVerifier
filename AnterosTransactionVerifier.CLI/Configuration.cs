using AnterosTransactionVerifier.Logic;
using AnterosTransactionVerifier.Services.TransactionReading;

namespace AnterosTransactionVerifier.CLI;

internal class Configuration
{
    public required TransactionConfiguration Bank { get; set; }
    public required TransactionConfiguration Bookkeeping { get; set; }
    public required string OutputFileLocation { get; set; }
}
