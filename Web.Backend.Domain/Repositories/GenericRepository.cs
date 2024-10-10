using Microsoft.EntityFrameworkCore;
using Web.Backend.Domain.Data;
using Web.Backend.Domain.Repositories.Contracts;

namespace Web.Backend.Domain.Repositories;

public class GenericRepository<T>(EducationDbContext context) : IGenericRepository<T> where T : class
{
    public async Task<T> AddAsync(T entity)
    {
        await context.AddAsync(entity);
        await context.SaveChangesAsync();

        return entity;
    }

    public async Task DeleteAsync(string? id)
    {
        T? entity = await GetSingleAsync(id);
        context.Set<T>().Remove(entity);
        await context.SaveChangesAsync();
    }

    public async Task<T> GetSingleAsync(string? id)
    {
        if (id == null)
            return null;
        else
            return await context.Set<T>().FindAsync(id);
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await context.Set<T>().ToListAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        context.Update(entity);
        await context.SaveChangesAsync();
    }

    public async Task<bool> Exists(string? id)
    {
        if (id != null)
        {
            var entity = await GetSingleAsync(id);
            return entity != null;
        }
        else
            return false;
    }
}
