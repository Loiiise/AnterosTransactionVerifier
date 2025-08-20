using Microsoft.Extensions.Configuration;

namespace AnterosTransactionVerifier;

internal class Program
{
    static void Main(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var configuration = config.Get<Configuration>()!;

        Console.WriteLine($"Bank file: {configuration.BankTransactionFileLocation}");
        Console.WriteLine($"Bookkeeping file: {configuration.BookkeepingTransactionFileLocation}");
        Console.WriteLine($"Output file: {configuration.OutputFileLocation}");
    }
}
