
using System.Text;

namespace AnterosTransactionVerifier.Services.FileHandling;

public class BasicFileWriter : IStaticFileWriter
{
    private readonly string _filePath;
    private readonly string? _firstLine;

    public BasicFileWriter(string filePath, string? firstLine)
    {
        _filePath = filePath;
        _firstLine = firstLine;
    }

    public void WriteAllLines(IEnumerable<string> lines)
    {
        if (!File.Exists(_filePath))
        {
            File.Create(_filePath).Dispose();
        }

        var stringBuilder = new StringBuilder();
        
        if (!string.IsNullOrEmpty(_firstLine))
        {
            stringBuilder.AppendLine(_firstLine);
        }

        stringBuilder.Append(string.Join(Environment.NewLine, lines));

        File.WriteAllText(_filePath, stringBuilder.ToString(), Encoding.UTF8);
    }
}
