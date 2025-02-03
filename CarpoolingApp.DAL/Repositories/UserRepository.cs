using CarpoolingApp.DAL.Interfaces;
using CarpoolingApp.DB.Contexts;
using CarpoolingApp.DB.Entities;
using CarpoolingApp.TOOLS.GenericRepositories;

namespace CarpoolingApp.DAL.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
     {
         public UserRepository(CarpoolingAppContext context) : base(context)
         {
         }
     
         // Méthodes custom
     }
}



/* NOTES
 - UserRepository hérite de Repository<User> (mon repo générique qui implémente déjà tous les CRUD (Add, Update, etc.).) et implémente IUserRepository (interface spécifique de User)
 - Si j'ai besoin de méthodes custom, je les ajoute ici. Exemple : public User? GetByEmail(string email) => Entities.FirstOrDefault(u => u.Email == email);
*/