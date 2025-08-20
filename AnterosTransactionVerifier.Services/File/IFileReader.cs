namespace AnterosTransactionVerifier.Services.File;

public interface IFileReader
{
    Task<IEnumerable<string>> ReadAllLines(string path);
}
