using System.Text.RegularExpressions;

namespace cs_lab_work.lab5
{
    public class EmailEntry
    {
        public string Email { get; private set; }
        public string Nickname { get; private set; }

        public EmailEntry(string email, string nickname)
        {
            if (!IsValidEmail(email))
                throw new ArgumentException("Неверный формат email.");

            if (string.IsNullOrWhiteSpace(nickname))
                throw new ArgumentException("Никнейм не может быть пустым.");

            Email = email;
            Nickname = nickname;
        }

        public override string ToString()
        {
            return $"{Nickname} <{Email}>";
        }

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
    }
}