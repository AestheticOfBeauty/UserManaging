using System.Text.RegularExpressions;

namespace UserManaging.Model.Regexes
{
    public class InitialsValidator
    {
        private static readonly Regex _regex = new Regex(@"^[a-zA-zа-яА-я]{1,}");

        public static bool IsValidInitials(string value) => _regex.IsMatch(value);
    }
}
