using Microsoft.EntityFrameworkCore;
using PointS.Api.Entity;

namespace PointS.Api.Context;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<TaskEntity> TaskEntity { get; set; }
}