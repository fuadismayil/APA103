namespace _08_StatiClassExtensionMethodsExceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LoginSystem loginSystem = new LoginSystem();

            while (true)
            {
                Console.Write("Istifadeci adini daxil edin: ");
                string username = Console.ReadLine();

                try
                {
                    loginSystem.ValidateUsername(username);

                    Console.Write("Sifreni daxil edin: ");
                    string password = Console.ReadLine();

                    if (loginSystem.Login(username, password))
                        break;
                }
                catch (InvalidUsernameException ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message}");
                }
                catch (InvalidPasswordException ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message}");
                }
                catch (UserNotFoundException ex)
                {
                    Console.WriteLine($"ERROR: {ex.Message}");
                    Console.WriteLine("Movcud istifadeciler: admin, student, teacher");
                }
                catch (IncorrectPasswordException ex)
                {
                    Console.WriteLine($"WARNING: {ex.Message}");
                }
                catch (AccountLockedException ex)
                {
                    Console.WriteLine($"CRITICAL: {ex.Message}");
                    Console.WriteLine("Please contact admin.");
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"UNEXPECTED ERROR: {ex.Message}");
                }

                Console.WriteLine();
            }
        }
    }
}
