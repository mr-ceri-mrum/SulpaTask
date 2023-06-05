using Microsoft.EntityFrameworkCore;
using SulpakTask.Models;

namespace SulpakTask.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
    
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Order> Order { get; set; }


}