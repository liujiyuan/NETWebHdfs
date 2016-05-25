using System.Text.RegularExpressions;

namespace DevZa.Utilities
{
    public class RegularUtils
    {
        public static bool IsVaildEmailAddress(string emailString)
        {
            return Regex.IsMatch(emailString,
                @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
                RegexOptions.IgnoreCase);
        }
    }
}