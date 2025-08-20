namespace AnterosTransactionVerifier.Services.FileReading;

public class BasicFileReader : IFileReader
{
    public Task<IEnumerable<string>> ReadAllLines(string path, bool skipFirstLine)
    {
        if (!File.Exists(path))
        {
            throw new ArgumentException($"File does not exist: {path}");
        }

        return Task.Run(() => skipFirstLine ?
            File.ReadAllLines(path).Skip(1) :
            File.ReadAllLines(path));
    }
}
