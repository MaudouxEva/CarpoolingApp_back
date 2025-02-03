using CarpoolingApp.DB.Entities;
using CarpoolingApp.TOOLS.GenericServices;

namespace CarpoolingApp.BLL.Interfaces
{
 /// <summary>
 /// Hérite du service générique pour la gestion des Users
 /// + on peut rajouter des méthodes custom
 /// </summary>
 public interface IUserService : IService<User>
 {
  // Ex. si on veut un "GetByEmail"
  User? GetByEmail(string email);
 }
}


/* NOTES
 - Interface spécialisée pour la gestion des users.
 - Hérite du service générique pour avoir les méthodes CRUD de base. On peut ajouter des méthodes spécifiques si besoin.
*/