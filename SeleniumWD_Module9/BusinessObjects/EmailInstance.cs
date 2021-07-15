using SeleniumWebDriver.Utils;

namespace SeleniumWebDriver.BusinessObjects
{
    public class EmailInstance
    {
        private readonly string _sender;
        private readonly string _email;
        private readonly string _subject;
        private readonly string _content;

        public EmailInstance(string sender, string email, string subject, string content)
        {
            this. _sender = sender;
            this._email = email;
            this._subject = subject;
            this._content = content;
        }

        public string Sender => _sender;
        public string Email => _email;
        public string Subject => _subject;
        public string Content => _content;

        public static EmailInstance getInstanceWithRandomSubjectAndContent(string sender, string email)
        {
            string randomSubject = RandomUtil.getRandomText(5);
            string randomContent = RandomUtil.getRandomText(10);
            return new EmailInstance(sender, email, randomSubject, randomContent);
        }
    }
}
