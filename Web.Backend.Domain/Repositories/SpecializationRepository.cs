using Web.Backend.Domain.Data;
using Web.Backend.Domain.Models.SpecializationDetails;
using Web.Backend.Domain.Repositories.Contracts;

namespace Web.Backend.Domain.Repositories;

public class SpecializationRepository(EducationDbContext context) : GenericRepository<Specialization>(context), ISpecializationRepository
{
    
}