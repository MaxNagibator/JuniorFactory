namespace Domiki.Web.Business
{
    public static class DateTimeHelper
    {
        public static DateTime GetNowDate()
        {
            var d = DateTime.UtcNow;
            var date = new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second);
            return date;
        }
    }
}
