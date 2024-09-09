using CsvHelper.Configuration.Attributes;

namespace JuniorFactory.Lesson10;

internal class LocalizeString(string key, string value)
{
    [Index(0)]
    public string Key { get; } = key;

    [Index(1)]
    public string Value { get; } = value;
}
