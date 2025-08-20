namespace AnterosTransactionVerifier.Services.FileWriting;

public interface IFileWriter
{
    public Task WriteToFileAsync(string filePath, string content);
}
