using System.Linq.Expressions;

namespace StaffApi.Data;

public interface IGenericRepository<TEntity> where TEntity : class
{
    List<TEntity> GetAll();
    TEntity GetById(int id);
    void Add(TEntity entity);
    void Remove(int id);
    void Update(TEntity entity);
    List<TEntity> WhereFilter(Expression<Func<TEntity, bool>> exp);
}
