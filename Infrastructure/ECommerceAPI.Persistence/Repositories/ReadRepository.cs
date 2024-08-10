using System;
using System.Linq.Expressions;
using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities.Common;
using ECommerceAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Persistence.Repositories;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
{
    private readonly ECommerceAPIDbContext _context;

    public ReadRepository(ECommerceAPIDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public IQueryable<T> GetAll(bool tracking = true)
    {
        var query = Table.AsQueryable();
        if (!tracking)
            query.AsNoTracking();
        return query;
    }

    public async Task<T> GetByIdAsync(string id, bool tracking = true)
    //=>await Table.FirstOrDefaultAsync(data=>data.Id==Guid.Parse(id));
    //=> await Table.FindAsync(Guid.Parse(id));
    {
        var query = Table.AsQueryable();
        if (!tracking)
            query.AsNoTracking();
        return await query.FirstOrDefaultAsync(data=>data.Id==Guid.Parse(id)); //burada asnotracking oldugu ucun findasync islemir
    }

    public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
    {
        var query= Table.AsQueryable();
        if (!tracking)
            query.AsNoTracking();
        return await query.FirstOrDefaultAsync(method);
    }

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
    {
        var query= Table.Where(method);
        if (!tracking)
            query.AsNoTracking();
        return query;
    }
}

