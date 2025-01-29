// BLL/Security/PasswordUtils.cs (optionnel, si on veut un wrapper)
using BCrypt.Net;

namespace CarpoolingApp.BLL.Security
{
    public static class PasswordUtils
    {
        public static string HashPassword(string plainPassword)
        {
            // La méthode la plus simple
            return BCrypt.Net.BCrypt.HashPassword(plainPassword);
        }

        public static bool VerifyPassword(string hashedPassword, string plainPassword)
        {
            return BCrypt.Net.BCrypt.Verify(plainPassword, hashedPassword);
        }
    }
}

/** NOTES
 * Ce fichier contient des méthodes pour hasher et vérifier des mots de passe.
 * Dans AuthService, j'appelerai PasswordUtils.HashPassword(password) et PasswordUtils.VerifyPassword(user.PasswordHash, password) pour hasher et vérifier les mots de passe.
*/