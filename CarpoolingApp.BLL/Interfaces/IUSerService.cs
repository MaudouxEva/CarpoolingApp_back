using CarpoolingApp.DB.Entities;
using CarpoolingApp.TOOLS.GenericServices;

namespace CarpoolingApp.BLL.Interfaces;

public interface IUSerService : IService<User>
{
    
}

/** NOTES
 * Interface spécialisée pour la gestion des users.
 * Hérite du service générique pour avoir les méthodes CRUD de base. On peut ajouter des méthodes spécifiques si besoin.
*/