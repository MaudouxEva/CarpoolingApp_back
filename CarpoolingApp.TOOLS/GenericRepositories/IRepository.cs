namespace CarpoolingApp.TOOLS.GenericRepositories
{
    // TEntity : class => on dit "que TEntity doit être une classe"
    public interface IRepository<TEntity> where TEntity : class
    {
       
        /// <summary>
        /// Retrieves all entities.
        /// </summary>
        /// <returns>An enumerable collection of entities.</returns>
        IEnumerable<TEntity> Find();

        /// <summary>
        /// Retrieves an entity by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        /// <returns>The entity with the specified identifier.</returns>
        TEntity FindById(int id);

        /// <summary>
        /// Adds a new entity.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The added entity.</returns>
        TEntity Add(TEntity entity);

        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>The updated entity.</returns>
        TEntity Update(TEntity entity);

        // /// <summary>
        // /// Deletes an entity by its unique identifier.
        // /// </summary>
        // /// <param name="id">The unique identifier of the entity to delete.</param>
        // /// <returns>True if the entity was deleted; otherwise, false.</returns>
        // bool Delete(int id);

        /// <summary>
        /// Finds entities that match the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate to match entities against.</param>
        /// <returns>An enumerable collection of entities that match the predicate.</returns>
        IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);

        /// <summary>
        /// Finds a single entity that matches the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate to match the entity against.</param>
        /// <returns>The entity that matches the predicate, or null if no entity matches.</returns>
        TEntity? FindOne(Func<TEntity, bool> predicate);

        /// <summary>
        /// Checks if any entities match the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate to match entities against.</param>
        /// <returns>True if any entities match the predicate; otherwise, false.</returns>
        bool Any(Func<TEntity, bool> predicate);

        /// <summary>
        /// Counts the total number of entities.
        /// </summary>
        /// <returns>The total number of entities.</returns>
        int Count();

        /// <summary>
        /// Counts the number of entities that match the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate to match entities against.</param>
        /// <returns>The number of entities that match the predicate.</returns>
        int Count(Func<TEntity, bool> predicate);
    }
}
/** NOTES
 *
 * Ce fichier représente l'interface IRepository<TEntity> qui définit les méthodes de base pour un dépôt générique.
 * C'est une sorte de "contrat" (avec signatures de méthodes) que les classes de dépôt doivent respecter.
*/
