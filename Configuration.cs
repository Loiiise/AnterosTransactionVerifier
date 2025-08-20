namespace AnterosTransactionVerifier;

internal class Configuration
{
    public required TransactionConfiguration Bank { get; set; }
    public required TransactionConfiguration Bookkeeping { get; set; }
    public required string OutputFileLocation { get; set; }
}

public class TransactionConfiguration
{
    public required string TransactionFileLocation { get; set; }
    public required string Name { get; set; }
    public required bool SkipFirstLine { get; set; }
    public required int AmountColumn { get; set; }
    public required int DateColumn { get; set; }
    public required int DescriptionColumn { get; set; }
}
