namespace Planefall.Common.EmailSender
{
    public interface IEmailSender
    {
        bool SendEmail(string recipient, string subject, string body);
        bool SendEmail(string sender, string recipient, string subject, string body);
    }
}