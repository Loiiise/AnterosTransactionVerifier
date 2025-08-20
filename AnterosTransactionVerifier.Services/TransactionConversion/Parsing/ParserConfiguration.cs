using AnterosTransactionVerifier.Logic;

namespace AnterosTransactionVerifier.Services.TransactionConversion.Parsing;

public record ParserConfiguration
{
    public required string Separator { get; set; }
    public required int AmountIndex { get; set; }
    public required int DateIndex { get; set; }
    public required int DescriptionIndex { get; set; }
}

public static class TransactionConfigurationExtensions
{
    public static ParserConfiguration ToParserConfiguration(this TransactionConfiguration transactionConfiguration)
        => new ParserConfiguration
        {
            Separator = transactionConfiguration.Separator,
            AmountIndex = transactionConfiguration.AmountColumn,
            DateIndex = transactionConfiguration.DateColumn,
            DescriptionIndex = transactionConfiguration.DescriptionColumn,
        };    
}