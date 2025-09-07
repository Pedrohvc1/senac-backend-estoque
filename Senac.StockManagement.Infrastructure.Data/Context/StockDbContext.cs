using Microsoft.EntityFrameworkCore;
using Senac.StockManagement.Domain.Entities;
using Senac.StockManagement.Infrastructure.Mappings;

namespace Senac.StockManagement.Infrastructure.Context;

public class StockDbContext : DbContext
{
    public StockDbContext(DbContextOptions<StockDbContext> options)
        : base(options)
    {
    }

    #region Tables

    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductMapping());
        modelBuilder.ApplyConfiguration(new UserMapping());
        base.OnModelCreating(modelBuilder);
    }
}