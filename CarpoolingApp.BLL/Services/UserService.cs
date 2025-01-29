using CarpoolingApp.DAL.Interfaces;
using CarpoolingApp.DB.Entities;
using CarpoolingApp.TOOLS.GenericServices;

namespace CarpoolingApp.BLL.Services;

public class UserService(IUserRepository repository) : Service<User>, IUserService
{
    
}