namespace AnterosTransactionVerifier.Logic;

public record TransactionConfiguration
{
    public required string TransactionFileLocation { get; set; }
    public required string Name { get; set; }
    public required bool SkipFirstLine { get; set; }
    public required int AmountColumn { get; set; }
    public required int DateColumn { get; set; }
    public required int DescriptionColumn { get; set; }
}
