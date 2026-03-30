public class InvalidUsernameException : Exception
{
    public InvalidUsernameException() : base("Yanlis istifadeci adi yazilisi!") { }

    public InvalidUsernameException(string message) : base(message) { }
}