using Microsoft.EntityFrameworkCore;

namespace StaffApi.Data;

public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{

	}

	public DbSet<Staff> Staff { get; set; }

    //protected override void OnModelCreating(ModelBuilder builder)
    //{
    //    base.OnModelCreating(builder);
    //    builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    //}
}
