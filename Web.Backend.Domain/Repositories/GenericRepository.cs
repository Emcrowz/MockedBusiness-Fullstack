using Microsoft.EntityFrameworkCore;
using Web.Backend.Domain.Data;
using Web.Backend.Domain.Repositories.Contracts;

namespace Web.Backend.Domain.Repositories;

public class GenericRepository<T>(EducationDbContext context) : IGenericRepository<T> where T : class
{
    /// <summary>
    /// GET | Request to get all records of the T type
    /// </summary>
    /// <returns>List of records of T type</returns>
    public async Task<List<T>> GetAllAsync()
    {
        return await context.Set<T>().ToListAsync();
    }

    /// <summary>
    /// GET | Request to get single records of the T type with specified id
    /// </summary>
    /// <param name="id">GUID string of the record</param>
    /// <returns>Single record of T type</returns>
    public async Task<T> GetSingleAsync(string? id)
    {
        if (id == null)
        {
            return null!;
        }

        return await context.Set<T>().FindAsync(id);
    }

    /// <summary>
    /// PUT | Create a single record of T type
    /// </summary>
    /// <param name="entity">Model to create a record instance</param>
    /// <returns>Model of the created record</returns>
    public async Task<T> AddAsync(T entity)
    {
        await context.AddAsync(entity);
        await context.SaveChangesAsync();

        return entity;
    }

    /// <summary>
    /// POST | Update a single record of T type
    /// </summary>
    /// <param name="entity">Model of the record to update with new data</param>
    public async Task UpdateAsync(T entity)
    {
        context.Update(entity);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// DELETE | Delete a single record of T type
    /// </summary>
    /// <param name="id">GUID string of the record</param>
    public async Task DeleteAsync(string? id)
    {
        T? entity = await GetSingleAsync(id);
        context.Set<T>().Remove(entity);
        await context.SaveChangesAsync();
    }

    /// <summary>
    /// Checks the record existence in the DB
    /// </summary>
    /// <param name="id">GUID string of the record</param>
    /// <returns>true/false if record exists in the DB</returns>
    public async Task<bool> Exists(string? id)
    {
        if (id != null)
        {
            var entity = await GetSingleAsync(id);
            return entity is not null;
        }

        return false;
    }
}
