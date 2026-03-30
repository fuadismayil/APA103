public class UserNotFoundException : Exception
{
    public UserNotFoundException() : base("Bele bir istifadeci tapilmadi!") { }

    public UserNotFoundException(string username) : base($"Sistemde '{username}' istifadecisi tapilmadi!") { }
}