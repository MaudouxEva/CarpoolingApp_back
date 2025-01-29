using CarpoolingApp.TOOLS.GenericRepositories;

namespace CarpoolingApp.TOOLS.GenericServices
{
    /// <summary>
    /// Classe de base pour factoriser le IRepository<TEntity> dans les services.
    /// </summary>
    public abstract class Service<TEntity> : IService<TEntity>
        where TEntity : class
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly Func<TEntity, bool> _predicate;
        
        protected Service(IRepository<TEntity> repository, Func<TEntity, bool> predicate)
        {
            _repository = repository;
            _predicate = predicate;
        }
    
        public virtual IEnumerable<TEntity> Find()
        {
            // On délègue simplement au _repository
            return _repository.Find();
        }

        public virtual TEntity FindById(int id)
        {
            return _repository.FindById(id);
        }

        public virtual TEntity Add(TEntity entity)
        {
            // Ici, on peut faire de la logique avant/après
            // (ex. validations) puis déléguer au repo
            return _repository.Add(entity);
        }

        public virtual TEntity Update(TEntity entity)
        {
            return _repository.Update(entity);
        }

        public virtual IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return _repository.Find(predicate);
        }

        public virtual TEntity? FindOne(Func<TEntity, bool> predicate)
        {
            return _repository.FindOne(predicate);
        }

        public virtual bool Any(Func<TEntity, bool> predicate)
        {
            return _repository.Any(predicate);
        }

        public virtual int Count()
        {
            return _repository.Count();
        }

        public virtual int Count(Func<TEntity, bool> predicate)
        {
            return _repository.Count(predicate);
        }
    }
}

/**
 * ServiceBase<TEntity> est une classe abstraite qui sert de base pour factoriser le IRepository<TEntity> dans les services.
 * Comme pour le RepoisotyrBase, on y met le le champ protégé _repository
 * Service<TEntity> est une classe abstraite qui hérite de ServiceBase<TEntity> et implémente IService<TEntity>.
*/