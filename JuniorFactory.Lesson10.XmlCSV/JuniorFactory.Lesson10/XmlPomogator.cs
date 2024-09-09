using System.Xml.Linq;

namespace JuniorFactory.Lesson10;

internal static class XmlPomogator
{
    public static List<LocalizeString> ParseLocalizeResource(string path)
    {
        string input = File.ReadAllText(path);
        XDocument doc = XDocument.Parse(input);
        List<LocalizeString> localize = [];
        IEnumerable<XElement> dataList = doc.Descendants("data");

        foreach (XElement data in dataList)
        {
            string? localizeKey = data.Attribute("name")?.Value;

            if (localizeKey == null)
            {
                throw new Exception("key not found: " + data);
            }

            string? type = data.Attribute("type")?.Value;

            if (type != null && type.StartsWith("System.Resources"))
            {
                Console.WriteLine("skip: " + localizeKey);
                continue;
            }

            IEnumerable<XElement> values = data.Descendants("value");

            if (values.Count() == 0)
            {
                throw new Exception("zero values: " + data);
            }

            if (values.Count() > 1)
            {
                throw new Exception("not single values: " + data);
            }

            string localizeValue = values.First().Value;
            localize.Add(new LocalizeString(localizeKey, localizeValue));
        }

        return localize;
    }

    internal static void Write(List<LocalizeString> resourceList2, string path)
    {
        string input = File.ReadAllText(path);
        XDocument doc = XDocument.Parse(input);
        IEnumerable<XElement> dataList = doc.Descendants("data");
        string[] asd = resourceList2.GroupBy(x => x.Key).Where(x => x.Count() > 1).Select(x => x.Key).ToArray();
        Dictionary<string, string> dict = resourceList2.ToDictionary(x => x.Key, x => x.Value);

        foreach (XElement data in dataList)
        {
            string? localizeKey = data.Attribute("name")?.Value;

            if (localizeKey == null)
            {
                throw new Exception("key not found: " + data);
            }

            string? type = data.Attribute("type")?.Value;

            if (type != null && type.StartsWith("System.Resources"))
            {
                Console.WriteLine("skip: " + localizeKey);
                continue;
            }

            IEnumerable<XElement> values = data.Descendants("value");

            if (values.Count() == 0)
            {
                throw new Exception("zero values: " + data);
            }

            if (values.Count() > 1)
            {
                throw new Exception("not single values: " + data);
            }

            XElement localizeValue = values.First();

            if (!dict.ContainsKey(localizeKey))
            {
                Console.WriteLine("key not found in localize scv file: " + localizeKey);
                continue;
            }

            string value = dict[localizeKey];
            localizeValue.Value = value;
        }

        doc.Save(path);
    }
}
