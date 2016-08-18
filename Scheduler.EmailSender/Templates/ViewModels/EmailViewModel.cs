using System;

namespace Scheduler.EmailSender.Templates.ViewModels
{
    /// <summary>
    /// Basic email view model class.
    /// </summary>
    public class EmailViewModel
    {
        public string RecipientName { get; set; }
        public DateTime CreationDate { get; set; }
    }
}