namespace Planefall.Common.EmailSender
{
    using MailKit.Net.Smtp;
    using Microsoft.Extensions.Options;
    using MimeKit;

    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration options;

        public EmailSender(IOptions<EmailConfiguration> options)
        {
            this.options = options.Value;
        }

        public bool SendEmail(string recipient, string subject, string body)
            => this.SendEmail(this.options.From, recipient, subject, body);

        public bool SendEmail(string sender, string recipient, string subject, string body)
        {
            try
            {
                var emailMessage = new MimeMessage();
                emailMessage.From.Add(new MailboxAddress(this.options.From));
                emailMessage.To.Add(new MailboxAddress(recipient));
                emailMessage.Subject = subject;

                emailMessage.Body = new TextPart("plain")
                {
                    Text = body
                };

                using (var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    client.Connect(this.options.SmtpServer, this.options.SmtpPort, true);

                    client.Authenticate(this.options.SmtpUsername, this.options.SmtpPassword);

                    client.Send(emailMessage);
                    client.Disconnect(true);
                }

                return true;
            }
            catch
            {
                // Ignored
                return false;
            }
        }
    }
}