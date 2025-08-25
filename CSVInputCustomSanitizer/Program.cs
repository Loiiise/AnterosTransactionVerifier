// This project merely exists because the provided csv data files were so stupid
// This one just converts it very customly to a sensible format

using AnterosTransactionVerifier.Logic;
using CSVInputCustomSanitizer;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Text;


var fullConfig = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();
var configuration = fullConfig.Get<InputCustomSanitizerConfiguration>()!;
var inputConfiguration = configuration.InputConfiguration;
var outputConfiguration = configuration.OutputConfiguration;


var lastSeenDateString = string.Empty;
var stringBuilder = new StringBuilder();
string? partialLine = null;

if (outputConfiguration.SkipFirstLine)
{
    // Check if input and output have the same configuration
    if (inputConfiguration.SkipFirstLine &&
        inputConfiguration.AmountColumn == outputConfiguration.AmountColumn &&
        inputConfiguration.DateColumn == outputConfiguration.DateColumn &&
        inputConfiguration.DescriptionColumn == outputConfiguration.DescriptionColumn)
    {
        stringBuilder.AppendLine(File.ReadLines(inputConfiguration.TransactionFileLocation).Take(1).First());
    }
    else
    {
        // Otherwise write dummyline
        stringBuilder.AppendLine("Skipping unknown header line. Please check config files.");
    }
}

foreach (var line in inputConfiguration.SkipFirstLine ?
    File.ReadLines(inputConfiguration.TransactionFileLocation).Skip(1) :
    File.ReadLines(inputConfiguration.TransactionFileLocation))
{
    if (line == string.Empty || line == "") continue;

    var currentLine = PrependIfNotNull(partialLine, line);

    if (!TryFromCSV(currentLine, out var lineParts))
    {
        partialLine = PrependIfNotNull(partialLine, line);
        continue;
    }

    Debug.Assert(lineParts.Length == 3);

    if (DateTime.TryParse(lineParts[inputConfiguration.DateColumn], out var _))
    {
        lastSeenDateString = lineParts[inputConfiguration.DateColumn];
    }

    partialLine = null;
    var generated = ToOutputLine(
        lastSeenDateString,
        lineParts[inputConfiguration.DescriptionColumn],
        lineParts[inputConfiguration.AmountColumn]);

    Console.WriteLine(generated);
    stringBuilder.AppendLine(generated);
}

File.WriteAllText(outputConfiguration.TransactionFileLocation, stringBuilder.ToString());

bool TryFromCSV(string inputLine, out string[] parts)
{
    try
    {
        parts = inputLine.ItemsFromCSVLine(inputConfiguration.Separator);
        return true;
    }
    catch (Exception e)
    {
        parts = Array.Empty<string>();
        return false;
    }
}

string PrependIfNotNull(string? prependingString, string postpendingString)
    => prependingString == null ? postpendingString : prependingString + postpendingString;

string ToOutputLine(string date, string description, string amount)
{
    int highestOutputIndex = Math.Max(outputConfiguration.DateColumn, Math.Max(outputConfiguration.DescriptionColumn, outputConfiguration.AmountColumn));
    var stringBuilder = new StringBuilder();

    for (int i = 0; i <= highestOutputIndex; ++i)
    {
        stringBuilder.Append(
            i == outputConfiguration.DateColumn ? date :
            i == outputConfiguration.DescriptionColumn ? description :
            i == outputConfiguration.AmountColumn ? amount :
            string.Empty);
        stringBuilder.Append(outputConfiguration.Separator);
    }
    return stringBuilder.ToString().TrimEnd(outputConfiguration.Separator.ToCharArray());
}
