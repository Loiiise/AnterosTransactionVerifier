using AnterosTransactionVerifier.Logic;
using AnterosTResultVerifier.Services.Generic;
using System.Diagnostics.CodeAnalysis;

namespace AnterosTransactionVerifier.Services.TransactionConversion.Stringification;

public class TransactionStringifier : SimplifiedConverter<Transaction, string>, ITransactionStringifier
{
    protected override bool ConvertSafe(Transaction sourceItem, [MaybeNullWhen(false), NotNullWhen(true)] out string result, [MaybeNullWhen(true), NotNullWhen(false)] out Exception exception)
    {
        throw new NotImplementedException();
    }
}
