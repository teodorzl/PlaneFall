namespace Planefall.Common.EmailSender
{
    using System.ComponentModel.DataAnnotations;

    public class EmailConfiguration
    {
        [Required]
        public string From { get; set; }

        [Required]
        public string SmtpServer { get; set; }

        [Required]
        public int SmtpPort { get; set; }

        [Required]
        public string SmtpUsername { get; set; }

        [Required]
        public string SmtpPassword { get; set; }
    }
}