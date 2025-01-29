namespace CarpoolingApp.TOOLS.GenericServices
{
    /// <summary>
    /// Interface générique pour les Services métier.
    /// Reprend la même logique (CRUD, recherches) que le Repo, 
    /// mais côté "Service".
    /// </summary>
    public interface IService<TEntity> where TEntity : class
    {
        /// <summary>
        /// Récupère toutes les entités.
        /// </summary>
        IEnumerable<TEntity> Find();

        /// <summary>
        /// Récupère une entité par son Id unique.
        /// </summary>
        TEntity FindById(int id);

        /// <summary>
        /// Ajoute une nouvelle entité (logique métier).
        /// </summary>
        TEntity Add(TEntity entity);

        /// <summary>
        /// Met à jour une entité existante.
        /// </summary>
        TEntity Update(TEntity entity);

        /// <summary>
        /// Trouve les entités qui satisfont un prédicat.
        /// </summary>
        IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);

        /// <summary>
        /// Trouve une entité unique qui satisfait un prédicat.
        /// </summary>
        TEntity? FindOne(Func<TEntity, bool> predicate);

        /// <summary>
        /// Vérifie si au moins une entité satisfait un prédicat.
        /// </summary>
        bool Any(Func<TEntity, bool> predicate);

        /// <summary>
        /// Compte le nombre total d'entités.
        /// </summary>
        int Count();

        /// <summary>
        /// Compte le nombre d'entités qui satisfont un prédicat.
        /// </summary>
        int Count(Func<TEntity, bool> predicate);
    }
}

/** NOTES
 * - Ce service est générique, il peut être utilisé pour n'importe quel type d'entité.
 * - Il reprend la même logique que le IRepository, mais côté "Service".
 * - Il est plus orienté métier, il peut contenir des règles de gestion supplémentaires.
    
*/