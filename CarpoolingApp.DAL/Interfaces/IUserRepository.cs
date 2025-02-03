using CarpoolingApp.DB.Entities;
using CarpoolingApp.TOOLS.GenericRepositories;

namespace CarpoolingApp.DAL.Interfaces
{
 public interface IUserRepository : IRepository<User>
 {
 
 }
}



/* NOTES
 - L'interface de User qui hérite de mon interface générique IRepository<User> qui contient les méthodes CRUD de base.
 - Si j'ai des méthodes spécifiques à ajouter, je les ajoute ici. Exemple : User? GetByEmail(string email);
*/