namespace JuniorFactory.Lesson5
{
    public class UserManager
    {
        private ISender _sender;

        public UserManager(ISender sender)
        {
            _sender = sender;
        }

        public bool Registration(string email)
        {
            // чето там сделали
            // в бд добавили
            _sender.SendMail(email, "Вы успешно зарегистрированы");
            return true;
        }
    }

    public interface ISender
    {
        int SendMail(string email, string message);
    }

    public class Sender : ISender
    {
        public int SendMail(string email, string message)
        {
            // отправили реальное письмо
            return 1;
        }
    }

    public class DebugSender : ISender
    {
        public int SendMail(string email, string message)
        {
            File.WriteAllText(email, message);
            return 2;
        }
    }
}
