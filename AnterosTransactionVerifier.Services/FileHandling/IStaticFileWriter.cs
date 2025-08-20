namespace AnterosTransactionVerifier.Services.FileHandling;

public interface IStaticFileWriter
{
    void WriteAllLines(IEnumerable<string> lines);
}
