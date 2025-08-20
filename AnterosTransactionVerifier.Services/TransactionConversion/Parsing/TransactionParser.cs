using AnterosTransactionVerifier.Logic;
using AnterosTResultVerifier.Services.Generic;
using System.Diagnostics.CodeAnalysis;

namespace AnterosTransactionVerifier.Services.TransactionConversion.Parsing;

internal class TransactionParser : SimplifiedConverter<string, Transaction>, ITransactionParser
{
    private readonly TransactionConfiguration _transactionConfiguration;

    protected TransactionParser(TransactionConfiguration transactionConfiguration)
    {
        _transactionConfiguration = transactionConfiguration;
    }

    protected override bool ConvertSafe(string sourceItem, [MaybeNullWhen(false), NotNullWhen(true)] out Transaction result, [MaybeNullWhen(true), NotNullWhen(false)] out Exception exception)
    {
        throw new NotImplementedException();
    }
}
