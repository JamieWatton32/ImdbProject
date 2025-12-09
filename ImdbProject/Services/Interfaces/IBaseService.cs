using System.Linq.Expressions;

namespace ImdbProject.Services.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        public Task<IEnumerable<TEntity>> GetAllAsync();
        public Task<TEntity?> GetByIdAsync(object id);
        public Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
