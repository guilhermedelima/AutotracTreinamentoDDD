

namespace IdentityAccess.Domain.Users.Services
{
    internal static class PasswordServices
    {
        public static string CryptographyPassword(string password)
        {
            return password + "@" + password;
        }
    }
}