public class InvalidPasswordException : Exception
{
    public InvalidPasswordException() : base("Yanlis sifre yazilisi!") { }

    public InvalidPasswordException(string message) : base(message) { }
}