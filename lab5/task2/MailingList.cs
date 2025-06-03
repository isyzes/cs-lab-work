using System.Text;

namespace cs_lab_work.lab5
{
    public class MailingList
    {
        public DateTime CreatedAt { get; private set; }
        private List<EmailEntry> emails = new List<EmailEntry>();

        public MailingList()
        {
            CreatedAt = DateTime.Now;
        }

        public MailingList(DateTime createdAt, List<EmailEntry> initialList)
        {
            CreatedAt = createdAt;
            emails = initialList ?? new List<EmailEntry>();
        }

        public EmailEntry this[string nickname]
        {
            get => emails.Find(e => e.Nickname.Equals(nickname, StringComparison.OrdinalIgnoreCase));
        }

        public static MailingList operator +(MailingList list, EmailEntry entry)
        {
            if (list.emails.Exists(e => e.Email == entry.Email || e.Nickname == entry.Nickname))
                throw new InvalidOperationException("Такой email или никнейм уже существует.");

            list.emails.Add(entry);
            return list;
        }

        public static MailingList operator -(MailingList list, EmailEntry entry)
        {
            list.emails.RemoveAll(e => e.Email == entry.Email);
            return list;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Список создан: {CreatedAt}");
            foreach (var entry in emails)
            {
                sb.AppendLine(entry.ToString());
            }
            return sb.ToString();
        }
    }
}