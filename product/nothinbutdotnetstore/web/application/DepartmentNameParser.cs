namespace nothinbutdotnetstore.web.application
{
    public class DepartmentNameParser
    {
        public static string parse(string url)
        {
            var index = url.IndexOf("?dept=");
            return url.Substring(index + 5);
        }
    }
}