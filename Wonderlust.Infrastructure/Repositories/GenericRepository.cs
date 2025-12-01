using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Wonderlust.Application.Common.Interfaces;
using Wonderlust.Infrastructure.Persistence;

namespace Wonderlust.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly AppDbContext _context;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<T?> GetByIdAsync(int id)
        => await _context.Set<T>().FindAsync(id);

    public async Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>>? filter = null)
    {
        IQueryable<T> query = _context.Set<T>();

        if (filter is not null)
        {
            query = query.Where(filter);
        }

        return await query.ToListAsync();
    }

    public async Task AddAsync(T entity)
        => await _context.Set<T>().AddAsync(entity);

    public void Update(T entity)
        => _context.Set<T>().Update(entity);

    public void Delete(T entity)
        => _context.Set<T>().Remove(entity);
}
