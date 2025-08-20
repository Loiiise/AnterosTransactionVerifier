namespace AnterosTransactionVerifier.Services.FileHandling;

public interface IStaticFileReader
{
    IEnumerable<string> ReadAllLines();
}
