namespace UserManaging.Model.Regexes
{
    public class EmailValidator
    {
        public static bool IsValidEmail(string address)
        {
            var email = new System.Net.Mail.MailAddress(address);
            return email.Address == address;
        }
    }
}
