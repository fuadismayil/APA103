namespace _27_FrontToBackSqlConnection
{
    public interface IEmailService
    {
        string OffEmail { get; set; }
        void SendEmail();
    }
}
