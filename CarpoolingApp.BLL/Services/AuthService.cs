using CarpoolingApp.BLL.Interfaces;
using CarpoolingApp.DB.Entities;
using CarpoolingApp.DAL.Interfaces; // j'imagine que tu as un IUserRepository ?
using System.Security.Authentication;
using CarpoolingApp.BLL.Security;

namespace CarpoolingApp.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtManager _jwtManager;

        public AuthService(IUserRepository userRepository, IJwtManager jwtManager)
        {
            _userRepository = userRepository;
            _jwtManager = jwtManager;
        }

        // MODIFICATION ICI: Register
        public void Register(string email, string password, string firstName, string lastName, bool isAdmin)
        {
            // 1) Vérif si email existe déjà
            if(_userRepository.Any(u => u.Email == email))
            {
                throw new Exception("Cet email est déjà pris !");
            }

            // 2) Hash le pass
            string hashedPwd = PasswordUtils.HashPassword(password);

            // 3) Créer l'user
            User newUser = new User
            {
                Email = email,
                PasswordHash = hashedPwd,
                FirstName = firstName,
                LastName = lastName,
                IsActive = true
            };
            _userRepository.Add(newUser);
            // si isAdmin == true, on lui affecte le rôle Admin (selon comment tu gères les roles)
        }

        // MODIFICATION ICI: Login
        public string Login(string email, string password)
        {
            User? user = _userRepository.FindOne(u => u.Email == email && u.IsActive == true);
            if(user == null)
            {
                throw new InvalidCredentialException("User not found or inactive");
            }

            // On compare le pass
            if(!PasswordUtils.VerifyPassword(user.PasswordHash, password))
            {
                throw new AuthenticationException("Mot de passe invalide");
            }

            // On récupère le role (ex. "Admin", "Member") - à toi de voir comment le stoquer
            string userRole = GetUserRole(user); // ex. "Administrator" ou "Member"

            // On génère le token
            string token = _jwtManager.CreateToken(
                user.Id.ToString(),
                user.Email,
                userRole
            );

            return token;
        }

        private string GetUserRole(User user)
        {
            // ex : si tu stockes le role dans user.UserRoles[0] => "Admin"
            // Ou si c'est multi-rôles, tu prends le premier.
            // Pour l'exemple : 
            var userRole = "Member"; 
            // si user à un userRole "Admin"
            // ...
            return userRole;
        }
    }
}
