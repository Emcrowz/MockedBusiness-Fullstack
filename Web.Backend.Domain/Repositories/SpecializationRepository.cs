using Web.Backend.Domain.Data;
using Web.Backend.Domain.Models.SpecializationDetails;
using Web.Backend.Domain.Repositories.Contracts;

namespace Web.Backend.Domain.Repositories;

public class SpecializationRepository : ISpecializationRepository
{
    private readonly IGenericRepository<Specialization> _genericRepo;
    public SpecializationRepository(EducationDbContext context)
    {
        _genericRepo = new GenericRepository<Specialization>(context);
    }

    public async Task<List<Specialization>> GetAsync()
    {
        return await _genericRepo.GetAllAsync();
    }

    public async Task<Specialization> GetAsync(string id)
    {
        return await _genericRepo.GetSingleAsync(id);
    }

    public async Task<bool> AddAsync(Specialization addModel)
    {
        try
        {
            await _genericRepo.AddAsync(addModel);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> UpdateAsync(string id, Specialization updateModel)
    {
        try
        {
            await _genericRepo.UpdateAsync(updateModel);

            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> DeleteAsync(string id)
    {
        try
        {
            await _genericRepo.DeleteAsync(id);
            return true;
        }
        catch
        {
            return false;
        }
    }
}