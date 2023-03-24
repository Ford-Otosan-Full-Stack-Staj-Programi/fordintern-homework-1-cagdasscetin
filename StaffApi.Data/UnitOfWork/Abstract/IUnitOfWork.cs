namespace StaffApi.Data;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Staff> StaffRepository { get; }
    void Complete();
}
