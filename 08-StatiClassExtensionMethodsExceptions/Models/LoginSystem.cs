public class LoginSystem
{
    private User[] users;
    private const int MaxAttempts = 3;

    public LoginSystem()
    {
        users = new User[]
        {
            new User("admin", "admin123"),
            new User("student", "student123"),
            new User("teacher", "teacher123")
        };
    }

    public void ValidateUsername(string username)
    {
        if (string.IsNullOrEmpty(username))
            throw new InvalidUsernameException("Istifadeci adi bos ola bilmez!");

        if (username.Length < 3)
            throw new InvalidUsernameException("Istifadeci adi en az 3 herfli olmalidir!");
    }

    public void ValidatePassword(string password)
    {
        if (string.IsNullOrEmpty(password))
            throw new InvalidPasswordException("Sifre bos ola bilmez!");

        if (password.Length < 6)
            throw new InvalidPasswordException("Sifreniz en az 6 simvol uzunluqunda olmalidir!");
    }

    private User FindUser(string username)
    {
        for (int i = 0; i < users.Length; i++)
        {
            if (users[i].Username.ToLower() == username.ToLower())
                return users[i];
        }
        return null;
    }

    public bool Login(string username, string password)
    {
        ValidateUsername(username);
        ValidatePassword(password);

        User user = FindUser(username);

        if (user == null)
            throw new UserNotFoundException(username);

        if (user.IsLocked)
            throw new AccountLockedException();

        if (user.Password == password)
        {
            user.FailedAttempts = 0;
            Console.WriteLine($"Ugurlu giris! {user.Username} Xos geldiniz!");
            return true;
        }
        else
        {
            user.FailedAttempts++;
            int attemptsLeft = MaxAttempts - user.FailedAttempts;

            if (attemptsLeft > 0)
            {
                throw new IncorrectPasswordException(attemptsLeft);
            }
            else
            {
                user.IsLocked = true;
                throw new AccountLockedException();
            }
        }
    }
}