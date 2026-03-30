public class IncorrectPasswordException : Exception
{
    public int AttemptsLeft { get; }

    public IncorrectPasswordException(int attemptsLeft)
        : base($"Yanlis sifre! {attemptsLeft} cehdiniz qaldi!")
    {
        AttemptsLeft = attemptsLeft;
    }
}