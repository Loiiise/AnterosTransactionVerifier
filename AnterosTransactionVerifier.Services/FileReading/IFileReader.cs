namespace AnterosTransactionVerifier.Services.FileReading;

public interface IFileReader
{
    Task<IEnumerable<string>> ReadAllLines(string path, bool skipFirstLine);
}
