using CarpoolingApp.DB.Contexts;
using Microsoft.EntityFrameworkCore;
using CarpoolingApp.TOOLS.GenericRepositories;

namespace CarpoolingApp.TEntityOOLS.GenericRepositories
{
    public abstract class RepositoryBase(DbContext _context)
    {
        protected readonly DbContext _context = _context;
    }
    
    public abstract class Repository<TEntity>(DbContext _context) : RepositoryBase(_context), IRepository<TEntity> where TEntity : class
    {
        protected DbSet<TEntity> Entities => _context.Set<TEntity>();

        /// <summary>
        /// Retrieves all entities.
        /// </summary>
        /// <returns>An enumerable collection of entities.</returns>
        public virtual IEnumerable<TEntity> Find()
        {
            return Entities.ToList();
        }
        
        /// <summary>
        /// Finds entities that match the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate to match entities against.</param>
        /// <returns>An enumerable collection of entities that match the predicate.</returns>
        public virtual IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            // On peut récupérer tout et filtrer en mémoire
            // => ça marche, mais pour de gros volumes c'est pas idéal
            return Entities.Where(predicate);
        }

        /// <summary>
        /// Counts the total number of entities.
        /// </summary>
        /// <returns>The total number of entities.</returns>
        public virtual int Count()
        {
            return Entities.Count();
        }

        /// <summary>
        /// Counts the number of entities that match the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate to match entities against.</param>
        /// <returns>The number of entities that match the predicate.</returns>
        public virtual int Count(Func<TEntity, bool> predicate)
        {
            return Entities.AsEnumerable().Count(predicate);
        }
        
        /// <summary>
        /// Retrieves an entity by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        /// <returns>The entity with the specified identifier.</returns>
        public virtual TEntity FindById(int id)
        {
            // EF => si c'est un int, on peut faire Entities.Find(id)
            return Entities.Find(id);
        }
        
        /// <summary>
        /// Finds a single entity that matches the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate to match the entity against.</param>
        /// <returns>The entity that matches the predicate, or null if no entity matches.</returns>
        public virtual TEntity? FindOne(Func<TEntity, bool> predicate)
        {
            return Entities.FirstOrDefault(predicate);
        }
        
        /// <summary>
        /// Checks if any entities match the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate to match entities against.</param>
        /// <returns>True if any entities match the predicate; otherwise, false.</returns>
        public virtual bool Any(Func<TEntity, bool> predicate)
        {
            return Entities.Any(predicate);
        }

        /// <summary>
        /// Adds a new entity.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The added entity.</returns>
        public virtual TEntity Add(TEntity entity)
        {
            Entities.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>The updated entity.</returns>
        public virtual TEntity Update(TEntity entity)
        {
            Entities.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        // Khun : public virtual TEntity Remove(TEntity entity)
        // {
        //     EntityEntry<TEntity> entry = _context.Remove(entity);
        //     entry.State = EntityState.Deleted;
        //     _context.SaveChanges();
        //     return entry.Entity;
        // }
        //
        // /// <summary>
        // /// Deletes an entity by its unique identifier.
        // /// </summary>
        // /// <param name="id">The unique identifier of the entity to delete.</param>
        // /// <returns>True if the entity was deleted; otherwise, false.</returns>
        // public virtual bool Delete(int id)
        // {
        //     var entity = FindById(id);
        //     if (entity == null) return false;
        //
        //     Entities.Remove(entity);
        //     _context.SaveChanges();
        //     return true;
        // }
    }
}


/** NOTES
 * La classe générique Repository<TEntity> est conçue pour fournir des opérations CRUD (Create, Read, Update, Delete) sur des entités de type TEntit
 * La classe Repository<TEntity> hérite de RepositoryBase pour réutiliser le contexte de la base de données (DbContext). Cela permet de centraliser la gestion du contexte et de le partager entre différentes classes de repository.
 * Le constructeur de RepositoryBase prend un paramètre DbContext pour initialiser le contexte de la base de données. Cela permet à la classe de repository d'interagir avec la base de données via Entity Framework.
 * La classe Repository<TEntity> implémente l'interface IRepository<TEntity>, qui définit les méthodes CRUD de base. Cela garantit que toutes les classes de repository respectent un contrat commun et fournissent les mêmes opérations de base.
 * Je choisis de procéder par initialisation directe pour initialiser les champs au moment de la déclaration de la classe. Je sais que ne rajouterai rien dans le constructeur, donc pas de constructeur explicite.
*/