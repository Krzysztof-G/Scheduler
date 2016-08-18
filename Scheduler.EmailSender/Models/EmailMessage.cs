using Scheduler.Service.Models;

namespace Scheduler.EmailSender.Models
{
    /// <summary>
    /// Email message use for email sending.
    /// </summary>
    public class EmailMessage
    {
        public UserDTO Recipent { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
