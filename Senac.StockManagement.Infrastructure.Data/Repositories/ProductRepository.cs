using Senac.StockManagement.Domain.Entities;
using Senac.StockManagement.Domain.Interfaces.Repositories;
using Senac.StockManagement.Infrastructure.Context;

namespace Senac.StockManagement.Infrastructure.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(StockDbContext context) : base(context)
    {
    }
}