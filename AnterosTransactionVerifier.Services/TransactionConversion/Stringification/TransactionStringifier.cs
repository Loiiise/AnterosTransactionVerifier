using AnterosTransactionVerifier.Logic;
using AnterosTResultVerifier.Services.Generic;
using System.Diagnostics.CodeAnalysis;

namespace AnterosTransactionVerifier.Services.TransactionConversion.Stringification;

public class TransactionStringifier : SimplifiedConverter<Transaction, string>, ITransactionStringifier
{
    public const string Format = "DATE;AMOUNT;DESCRIPTION";
    protected override bool ConvertSafe(Transaction sourceItem, [MaybeNullWhen(false), NotNullWhen(true)] out string result, [MaybeNullWhen(true), NotNullWhen(false)] out Exception exception)
    {
        result = string.Join(';', new string[]{ sourceItem.Date.ToString(), sourceItem.Amount.ToString(), sourceItem.Description });
        exception = null;
        return true;
    }
}
