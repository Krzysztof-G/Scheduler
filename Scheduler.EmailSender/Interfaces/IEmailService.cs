using Scheduler.EmailSender.Models;

namespace Scheduler.EmailSender.Interfaces
{
	public interface IEmailService
	{
		/// <summary>
		/// Send an email.
		/// </summary>
		/// <param name="email">Email to send.</param>
		void SendEmail(EmailMessage email);
	}
}