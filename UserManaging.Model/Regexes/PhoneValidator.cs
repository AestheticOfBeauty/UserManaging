using System.Text.RegularExpressions;

namespace UserManaging.Model.Regexes
{
    public class PhoneValidator
    {
        private static readonly Regex _regex = new Regex(@"^\+79[0-9]{9}");

        public static bool IsValidPhone(string value) => _regex.IsMatch(value);
    }
}
