namespace AnterosTransactionVerifier.Services.File;

public interface IFileWriter
{
    public Task WriteToFileAsync(string filePath, string content);
}
