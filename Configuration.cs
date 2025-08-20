namespace AnterosTransactionVerifier;

internal class Configuration
{
    public required string BankTransactionFileLocation { get; set; }
    public required string BookkeepingTransactionFileLocation { get; set; }
    public required string OutputFileLocation { get; set; } 
}
