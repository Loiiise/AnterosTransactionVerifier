using AnterosTransactionVerifier.Logic;
using System.Diagnostics.CodeAnalysis;

namespace AnterosTransactionVerifier.Services.TransactionConversion.Parsing;

internal abstract class TransactionParser : ITransactionParser
{
    public Transaction Convert(string sourceItem)
        => ParseSafe(sourceItem, out var result, out var exception) ? 
        result : 
        throw exception;

    public IEnumerable<Transaction> Convert(IEnumerable<string> sourceItems)
        => sourceItems.Select(Convert);

    public bool TryConvert(string sourceItem, [MaybeNullWhen(false), NotNullWhen(true)] out Transaction result)
        => ParseSafe(sourceItem, out result, out var _);

    public bool TryConvertAll(string[] sourceItems, out Transaction[] result)
    {
        result = new Transaction[sourceItems.Length];

        for (int i = 0; i < sourceItems.Length; ++i)
        {
            if (!ParseSafe(sourceItems[i], out var transaction, out var exception))
            {
                result = Array.Empty<Transaction>();
                return false;
            }
            result[i] = transaction;
        }

        return true;
    }

    public abstract bool ParseSafe(string sourceItem, [MaybeNullWhen(false), NotNullWhen(true)] out Transaction result, [MaybeNullWhen(true), NotNullWhen(false)] out Exception exception);
}
