using AnterosTransactionVerifier.Services.Generic;
using System.Diagnostics.CodeAnalysis;

namespace AnterosTResultVerifier.Services.Generic;


public abstract class SimplifiedConverter<TSource, TResult> : IConverter<TSource, TResult>
{
    public TResult Convert(TSource sourceItem)
        => ConvertSafe(sourceItem, out var result, out var exception) ?
        result :
        throw exception;

    public IEnumerable<TResult> Convert(IEnumerable<TSource> sourceItems)
        => sourceItems.Select(Convert);

    public bool TryConvert(TSource sourceItem, [MaybeNullWhen(false), NotNullWhen(true)] out TResult result)
        => ConvertSafe(sourceItem, out result, out var _);

    public bool TryConvertAll(TSource[] sourceItems, out TResult[] result)
    {
        result = new TResult[sourceItems.Length];

        for (int i = 0; i < sourceItems.Length; ++i)
        {
            if (!ConvertSafe(sourceItems[i], out var TResult, out var exception))
            {
                result = Array.Empty<TResult>();
                return false;
            }
            result[i] = TResult;
        }

        return true;
    }

    protected abstract bool ConvertSafe(TSource sourceItem, [MaybeNullWhen(false), NotNullWhen(true)] out TResult result, [MaybeNullWhen(true), NotNullWhen(false)] out Exception exception);
}
