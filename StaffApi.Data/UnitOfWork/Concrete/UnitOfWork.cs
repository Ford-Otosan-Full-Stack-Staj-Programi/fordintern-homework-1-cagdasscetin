namespace StaffApi.Data;

public class UnitOfWork : IUnitOfWork
{
    public IGenericRepository<Staff> StaffRepository { get; private set; }

    private readonly AppDbContext _context;
    
    public UnitOfWork(AppDbContext context)
    {
        _context = context;

        StaffRepository = new GenericRepository<Staff>(context);
    }

    public void Complete()
    {
        _context.SaveChanges();
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
