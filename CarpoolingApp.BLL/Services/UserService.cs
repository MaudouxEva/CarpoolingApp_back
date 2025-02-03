using CarpoolingApp.BLL.Interfaces;
using CarpoolingApp.DB.Entities;
using CarpoolingApp.DAL.Interfaces;
using CarpoolingApp.TOOLS.GenericServices;

namespace CarpoolingApp.BLL.Services
{
    public class UserService : Service<User>, IUserService
    
    {
        private readonly IUserRepository _repository;
        // On injecte un IUserRepository
        public UserService(IUserRepository repository) : base(repository)
        {
            _repository = repository;
        }

        // Méthode custom
        public User? GetByEmail(string email)
        {
            return _repository.FindOne(u => u.Email == email);
        }
    }
}