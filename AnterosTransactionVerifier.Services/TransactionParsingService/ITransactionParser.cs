using AnterosTransactionVerifier.Logic;
using System.Diagnostics.CodeAnalysis;

namespace AnterosTransactionVerifier.Services.TransactionParsingService;

public interface ITransactionParser
{
    Transaction Parse(string rawTransaction, TransactionConfiguration configuration);
    IEnumerable<Transaction> Parse(IEnumerable<string> rawTransactions, TransactionConfiguration configuration);

    bool TryParse(string rawTransaction, TransactionConfiguration configuration, [MaybeNullWhen(false), NotNullWhen(true)] out Transaction result);
    bool TryParse(IEnumerable<string> rawTransactions, TransactionConfiguration configuration, [MaybeNullWhen(false), NotNullWhen(true)] out IEnumerable<Transaction> result);
}
