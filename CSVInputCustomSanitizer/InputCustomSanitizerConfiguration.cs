using AnterosTransactionVerifier.Logic;

namespace CSVInputCustomSanitizer;

internal record InputCustomSanitizerConfiguration
{
    public required TransactionConfiguration InputConfiguration { get; set; }
    public required TransactionConfiguration OutputConfiguration { get; set; }
}
