namespace CarpoolingApp.TOOLS.GenericServices
{
    public interface IService<TEntity> where TEntity : class
    {
        /// <summary>
        /// Retrieves all entities.
        /// </summary>
        /// <returns>An enumerable collection of entities.</returns>
        IEnumerable<TEntity> Find();
        
        /// <summary>
        /// Finds entities that match the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate to match entities against.</param>
        /// <returns>An enumerable collection of entities that match the predicate.</returns>
        IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);

        /// <summary>
        /// Retrieves an entity by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity.</param>
        /// <returns>The entity with the specified identifier.</returns>
        TEntity FindById(int id);
        
        /// <summary>
        /// Finds a single entity that matches the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate to match the entity against.</param>
        /// <returns>The entity that matches the predicate, or null if no entity matches.</returns>
        TEntity? FindOne(Func<TEntity, bool> predicate);

        /// <summary>
        /// Adds a new entity.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The added entity.</returns>
        TEntity Create(TEntity entity);

        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>The updated entity.</returns>
        TEntity Update(TEntity entity);

        /// <summary>
        /// Checks if any entities match the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate to match entities against.</param>
        /// <returns>True if any entities match the predicate; otherwise, false.</returns>
        bool Any(Func<TEntity, bool> predicate);

        // /// <summary>
        // /// Deletes an entity by its unique identifier.
        // /// </summary>
        // /// <param name="id">The unique identifier of the entity to delete.</param>
        // /// <returns>True if the entity was deleted; otherwise, false.</returns>
        // bool Delete(int id);
    }
}

/* NOTES
 - Ce service est générique, il peut être utilisé pour n'importe quel type d'entité.
 - Il reprend la même logique que le IRepository, mais côté "Service".
 - Il est plus orienté métier, il peut contenir des règles de gestion supplémentaires.   
*/