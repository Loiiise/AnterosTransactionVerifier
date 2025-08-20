namespace AnterosTransactionVerifier.Services.TransactionParsing;

public record ParserConfiguration
{
    public required int AmountIndex { get; set; }
    public required int DateIndex { get; set; }
    public required int DescriptionIndex { get; set; }
}
