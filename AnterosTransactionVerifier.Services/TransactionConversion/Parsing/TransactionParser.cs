using AnterosTransactionVerifier.Logic;
using AnterosTResultVerifier.Services.Generic;
using System.Diagnostics.CodeAnalysis;

namespace AnterosTransactionVerifier.Services.TransactionConversion.Parsing;

public class TransactionParser : SimplifiedConverter<string, Transaction>, ITransactionParser
{
    private readonly ParserConfiguration _transactionConfiguration;

    public TransactionParser(ParserConfiguration transactionConfiguration)
    {
        _transactionConfiguration = transactionConfiguration;
    }

    protected override bool ConvertSafe(string sourceItem, [MaybeNullWhen(false), NotNullWhen(true)] out Transaction result, [MaybeNullWhen(true), NotNullWhen(false)] out Exception exception)
    {
        throw new NotImplementedException();
    }
}
