using System.Linq.Expressions;

namespace ImdbProject.Repositories.Interfaces
{
    // Base repository interface defining common data access methods
    // TEntity represents the type of entity the repository will manage

    // Each entity repository will inherit this interface to ensure to ensure these interface methods are available to each. 
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(object id);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
