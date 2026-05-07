namespace _27_FrontToBackSqlConnection.Services
{
    public class EmailService: IEmailService
    {
        public string OffEmail { get; set; }
        public void SendEmail()
        {
            Console.WriteLine("Email Sent!");
        }
    }
}
