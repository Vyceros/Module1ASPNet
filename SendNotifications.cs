using ITStepRazorApp.Data.Interfaces;

namespace ITStepRazorApp
{
    internal class SendNotifications : ISendEmails
    {
        public void SendEmail(string mail)
        {
            Console.WriteLine("Sending sales notification." + mail);
        }
    }
}