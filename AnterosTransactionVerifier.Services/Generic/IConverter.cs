using System.Diagnostics.CodeAnalysis;

namespace AnterosTransactionVerifier.Services.Generic;

public interface IConverter<TSource, TResult>
{
    TResult Convert(TSource sourceItem);
    IEnumerable<TResult> Convert(IEnumerable<TSource> sourceItems);

    bool TryConvert(TSource sourceItem, [MaybeNullWhen(false), NotNullWhen(true)] out TResult result);
    bool TryConvertAll(TSource[] sourceItems, out TResult[] result);
}
