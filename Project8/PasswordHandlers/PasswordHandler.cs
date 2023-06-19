using Microsoft.AspNetCore.Identity;

namespace Zadanie8.PasswordHandlers
{
    public static class PasswordHandler
    {
        public static readonly PasswordHasher<string> passwordHasher = new PasswordHasher<string>();
        public static string HashPassword(string user, string password)
        {
            string hashedPassword = passwordHasher.HashPassword(user, password);
            return hashedPassword;
        }
        public static bool VerifyPassword(string user, string hashedPassword, string enteredPassword)
        {
            var passwordVerificationResult = passwordHasher.VerifyHashedPassword(user, hashedPassword, enteredPassword);

            if (passwordVerificationResult == PasswordVerificationResult.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
