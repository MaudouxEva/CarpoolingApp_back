using CarpoolingApp.TOOLS.GenericRepositories;

namespace CarpoolingApp.TOOLS.GenericServices
{
 public abstract class Service<TEntity> (IRepository<TEntity> _repository) : IService<TEntity>
        where TEntity : class
    {
        // On délègue simplement les méthodes au _repository
        public virtual IEnumerable<TEntity> Find()
        {
            return _repository.Find();
        }
        
        public virtual IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return _repository.Find(predicate);
        }

        public virtual TEntity FindById(int id)
        {
            return _repository.FindById(id);
        }
        
        public virtual TEntity? FindOne(Func<TEntity, bool> predicate)
        {
            return _repository.FindOne(predicate);
        }

        public virtual TEntity Create(TEntity entity)
        {
            // Ici, on peut faire de la logique avant/après
            // (ex. validations) puis déléguer au repo
            return _repository.Create(entity);
        }

        public virtual TEntity Update(TEntity entity)
        {
            return _repository.Update(entity);
        }


        public virtual bool Any(Func<TEntity, bool> predicate)
        {
            return _repository.Any(predicate);
        }
        
        // public virutal bool Delete(int ind)
    }
}

/* NOTES
 - ServiceBase<TEntity> est une classe abstraite qui sert de base pour factoriser le IRepository<TEntity> dans les services.
 - Comme pour le RepoisotyrBase, on y met le le champ protégé _repository
 - Service<TEntity> est une classe abstraite qui hérite de ServiceBase<TEntity> et implémente IService<TEntity>.
*/