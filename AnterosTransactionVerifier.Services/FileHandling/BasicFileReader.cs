namespace AnterosTransactionVerifier.Services.FileHandling;

public class BasicFileReader : IStaticFileReader
{
    private readonly string _filePath;
    private readonly bool _skipFirstLine;

    public BasicFileReader(string filePath, bool skipFirstLine)
    {
        if (!File.Exists(filePath))
        {
            throw new ArgumentException($"File does not exist: {filePath}");
        }

        _filePath = filePath;
        _skipFirstLine = skipFirstLine;
    }

    public IEnumerable<string> ReadAllLines()
        => _skipFirstLine ?
            File.ReadAllLines(_filePath).Skip(1) :
            File.ReadAllLines(_filePath);
}
