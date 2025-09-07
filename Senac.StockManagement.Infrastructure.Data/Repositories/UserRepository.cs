using Microsoft.EntityFrameworkCore;
using Senac.StockManagement.Domain.Entities;
using Senac.StockManagement.Domain.Interfaces.Repositories;
using Senac.StockManagement.Infrastructure.Context;

namespace Senac.StockManagement.Infrastructure.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly StockDbContext _dbContext;

    public UserRepository(StockDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _dbContext.Users
            .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
    }

    public async Task<bool> EmailExistsAsync(string email)
    {
        return await _dbContext.Users
            .AnyAsync(u => u.Email.ToLower() == email.ToLower());
    }
}