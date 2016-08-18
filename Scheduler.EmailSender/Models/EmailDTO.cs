using Scheduler.Common.Enums;

namespace Scheduler.EmailSender.Models
{
    /// <summary>
    /// Email DTO
    /// </summary>
    public class EmailDTO
    {
        public EmailTypes Type { get; set; }
        public long RelatedObjectId { get; set; }
    }
}