namespace AnterosTransactionVerifier.Logic;

public record Transaction
{
    public required decimal Amount { get; set; }
    public required DateTime Date { get; set; }
    public required string Description { get; set; }
}
