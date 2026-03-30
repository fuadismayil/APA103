public class AccountLockedException : Exception
{
    public AccountLockedException() : base("Hesab tahlukesizlik sebeblerine gore bloklandi!") { }
}