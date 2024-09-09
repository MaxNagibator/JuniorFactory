using JuniorFactory.Lesson10;

Console.WriteLine("Hello, World!");

string dir = @"E:\bobgroup\repo\Solyanka\ResourceTransformator\ExampleFiles";

bool toCsv = true;

if (toCsv)
{
    List<LocalizeString> resourceList = XmlPomogator.ParseLocalizeResource(Path.Combine(dir, "Resource.resx"));
    CsvPomogator.WriteCsv(resourceList, Path.Combine(dir, "Resource.csv"));

    resourceList = XmlPomogator.ParseLocalizeResource(Path.Combine(dir, "Resource.en.resx"));
    CsvPomogator.WriteCsv(resourceList, Path.Combine(dir, "Resource.en.csv"));
}
else
{
    List<LocalizeString> resourceList2 = CsvPomogator.ParseLocalizeResource(Path.Combine(dir, "Resource.csv"));
    XmlPomogator.Write(resourceList2, Path.Combine(dir, "Resource.resx"));

    resourceList2 = CsvPomogator.ParseLocalizeResource(Path.Combine(dir, "Resource.en.csv"));
    XmlPomogator.Write(resourceList2, Path.Combine(dir, "Resource.resx"));
}
