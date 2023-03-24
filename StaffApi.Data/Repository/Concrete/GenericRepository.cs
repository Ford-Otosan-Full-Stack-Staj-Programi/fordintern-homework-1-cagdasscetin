using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace StaffApi.Data;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly AppDbContext _context;
    private DbSet<TEntity> _entities;
	public GenericRepository(AppDbContext context)
	{
        _context = context;
        _entities = context.Set<TEntity>();
	}

    public void Add(TEntity entity)
    {
        entity.GetType().GetProperty("CreatedAt").SetValue(entity, DateTime.Now);
        entity.GetType().GetProperty("CreatedBy").SetValue(entity, "AddedByUser");
        _entities.Add(entity);
    }

    public List<TEntity> GetAll()
    {
        return _entities.ToList();
    }

    public TEntity GetById(int id)
    {
        return _entities.Find(id);
    }

    public List<TEntity> WhereFilter(Expression<Func<TEntity, bool>> exp)
    {
        var filtered = _entities.Where(exp).ToList();
        return filtered;
    }

    public void Remove(int id)
    {
        var entity = GetById(id);
        _entities.Remove(entity);
    }

    public void Update(TEntity entity)
    {
        _entities.Update(entity);
    }
}
