using CarpoolingApp.BLL.Interfaces;
using CarpoolingApp.DB.Entities;
using CarpoolingApp.DAL.Interfaces;
using System.Security.Authentication;
using CarpoolingApp.BLL.Security;

namespace CarpoolingApp.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtManager _jwtManager;

        // MODIFICATION ICI: On injecte le userRepo + jwtManager
        public AuthService(IUserRepository userRepository, IJwtManager jwtManager)
        {
            _userRepository = userRepository;
            _jwtManager = jwtManager;
        }

        public string Register(object dto)
        {
            // 1) On cast le dto
            // On suppose c'est RegisterDTO
            dynamic registerDto = dto;
            
            string email = registerDto.Email;
            string password = registerDto.Password;
            string firstName = registerDto.FirstName;
            string lastName = registerDto.LastName;
            int institutionId = registerDto.InstitutionId;
            bool isAdmin = registerDto.IsAdmin;

            // 2) Vérif si email existe
            if(_userRepository.Any(u => u.Email == email))
            {
                throw new Exception("Cet email est déjà pris !");
            }

            // 3) Hash pass
            string hashedPwd = PasswordUtils.HashPassword(password);

            // 4) Créer l'user en DB
            User newUser = new User
            {
                Email = email,
                PasswordHash = hashedPwd,
                FirstName = firstName,
                LastName = lastName,
                InstitutionId = institutionId,
                IsActive = true
            };
            // On insère
            _userRepository.Create(newUser);

            // si isAdmin => on associe le role "Admin" dans la table userRole
            // ex. si tu as un RoleRepository, on ajoute. 
            // simplifions: on skip.

            // 5) Génère un token
            string role = isAdmin ? "Admin" : "Member";
            string token = _jwtManager.CreateToken(
                newUser.Id.ToString(),
                newUser.Email,
                role
            );

            return token;
        }

        public string Login(string email, string password)
        {
            var user = _userRepository.FindOne(u => u.Email == email && u.IsActive == true);
            if (user == null)
            {
                throw new InvalidCredentialException("User not found or inactive");
            }

            // comparer pass
            if(!PasswordUtils.VerifyPassword(user.PasswordHash, password))
            {
                throw new AuthenticationException("Mot de passe invalide");
            }

            // role
            string role = "Member";
            // si user a un userRole "Admin", role = "Admin"
            // etc.

            // token
            string token = _jwtManager.CreateToken(user.Id.ToString(), user.Email, role);
            return token;
        }
    }
}
