namespace Domiki.Web.Extentions
{
    public static class StringExtensions
    {
        public static double ToDouble(this string str)
        {
            str = str.Replace(".", ",");
            return double.Parse(str);
        }
    }
}
