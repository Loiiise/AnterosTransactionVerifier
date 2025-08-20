using AnterosTransactionVerifier.Logic;
using AnterosTransactionVerifier.Services.Generic;
using System.Diagnostics.CodeAnalysis;

namespace AnterosTransactionVerifier.Services.TransactionConversion.Parsing;

public interface ITransactionParser : IConverter<string, Transaction>
{
    Transaction Parse(string rawTransaction) => Convert(rawTransaction);
    IEnumerable<Transaction> Parse(IEnumerable<string> rawTransactions) => Convert(rawTransactions);

    bool TryParse(string rawTransaction, [MaybeNullWhen(false), NotNullWhen(true)] out Transaction result) => TryConvert(rawTransaction, out result);
    bool TryParseAll(string[] rawTransactions, out Transaction[] result) => TryConvertAll(rawTransactions, out result);
}
