using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace JuniorFactory.Lesson10;

internal static class CsvPomogator
{
    private static readonly CsvConfiguration CsvConfig = new(CultureInfo.InvariantCulture)
    {
        HasHeaderRecord = false,
        Delimiter = ";"
    };

    internal static List<LocalizeString> ParseLocalizeResource(string path)
    {
        using StreamReader reader = new(path);
        using CsvReader csv = new(reader, CsvConfig);

        List<LocalizeString> localize = csv.GetRecords<LocalizeString>().ToList();
        return localize;
    }

    internal static void WriteCsv(List<LocalizeString> resourceList, string outputPath)
    {
        using StreamWriter writer = new(outputPath);
        using CsvWriter csv = new(writer, CsvConfig);

        csv.WriteRecords(resourceList);
    }
}
