using Web.Backend.Domain.Models.SpecializationDetails;

namespace Web.Backend.Domain.Repositories.Contracts;

public interface ISpecializationRepository
{
    Task<List<Specialization>> GetAsync();
    Task<Specialization> GetAsync(string id);
    Task<bool> AddAsync(Specialization addModel);
    Task<bool> UpdateAsync(string id, Specialization updateModel);
    Task<bool> DeleteAsync(string id);
}