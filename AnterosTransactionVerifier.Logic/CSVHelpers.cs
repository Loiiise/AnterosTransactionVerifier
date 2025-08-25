using Microsoft.VisualBasic.FileIO;

namespace AnterosTransactionVerifier.Logic;

public static class CSVHelpers
{
    public static string[] ItemsFromCSVLine(this string inputLine, string separator)
    {
        using var reader = new StringReader(inputLine);
        using var parser = new TextFieldParser(reader);

        parser.TextFieldType = FieldType.Delimited;
        parser.SetDelimiters(separator);

        return parser.ReadFields()!;
    }
}
