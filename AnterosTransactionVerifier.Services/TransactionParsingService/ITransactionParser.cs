using AnterosTransactionVerifier.Logic;
using System.Diagnostics.CodeAnalysis;

namespace AnterosTransactionVerifier.Services.TransactionParsingService;

public interface ITransactionParser
{
    Transaction Parse(string rawTransaction);
    IEnumerable<Transaction> Parse(IEnumerable<string> rawTransactions);

    bool TryParse(string rawTransaction, [MaybeNullWhen(false), NotNullWhen(true)] out Transaction result);
    bool TryParse(IEnumerable<string> rawTransactions, [MaybeNullWhen(false), NotNullWhen(true)] out IEnumerable<Transaction> result);
}
