using AnterosTransactionVerifier.Logic;
using AnterosTransactionVerifier.Services.Generic;

namespace AnterosTransactionVerifier.Services.TransactionConversion.Stringification;

public interface ITransactionStringifier : IConverter<Transaction, string> { }
