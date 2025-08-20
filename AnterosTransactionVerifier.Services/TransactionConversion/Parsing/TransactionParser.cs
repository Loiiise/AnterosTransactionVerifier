using AnterosTransactionVerifier.Logic;
using AnterosTResultVerifier.Services.Generic;
using System.Diagnostics.CodeAnalysis;

namespace AnterosTransactionVerifier.Services.TransactionConversion.Parsing;

public class TransactionParser : SimplifiedConverter<string, Transaction>, ITransactionParser
{
    private readonly ParserConfiguration _parserConfiguration;

    public TransactionParser(ParserConfiguration transactionConfiguration)
    {
        _parserConfiguration = transactionConfiguration;
    }

    protected override bool ConvertSafe(string sourceItem, [MaybeNullWhen(false), NotNullWhen(true)] out Transaction result, [MaybeNullWhen(true), NotNullWhen(false)] out Exception exception)
    {
        result = null;
        var items = sourceItem.Split(_parserConfiguration.Separator);

        if (_parserConfiguration.DateIndex >= items.Length ||
            _parserConfiguration.AmountIndex >= items.Length ||
            _parserConfiguration.DescriptionIndex >= items.Length)
        {
            var highestIndex = Math.Max(_parserConfiguration.DateIndex, Math.Max(_parserConfiguration.AmountIndex, _parserConfiguration.DescriptionIndex));
            exception = new ArgumentException($"The input string does not contain enough parts. Expected at least {highestIndex + 1} parts, but got {items.Length}.");
            return false;
        }

        if (!decimal.TryParse(items[_parserConfiguration.AmountIndex], out var amount))
        {
            exception = new ArgumentException($"{items[_parserConfiguration.AmountIndex]} is not a properly formatted amount");
            return false;
        }

        if (!DateTime.TryParse(items[_parserConfiguration.DateIndex], out var dateTime))
        {
            exception = new ArgumentException($"{items[_parserConfiguration.AmountIndex]} is not a properly formatted amount");
            return false;
        }

        result = new Transaction
        {
            Amount = amount,
            Date = dateTime,
            Description = items[_parserConfiguration.DescriptionIndex]
        };
        exception = null;
        return true;
    }
}
