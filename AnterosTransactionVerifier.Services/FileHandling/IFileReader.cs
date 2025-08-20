namespace AnterosTransactionVerifier.Services.FileHandling;

public interface IFileReader
{
    IEnumerable<string> ReadAllLines();
}
