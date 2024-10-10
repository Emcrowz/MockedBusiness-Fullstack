using AutoMapper;
using Web.Backend.Domain.Data;
using Web.Backend.Domain.DTO.Education;
using Web.Backend.Domain.Models.Education;
using Web.Backend.Domain.Models.Users;
using Web.Backend.Domain.Repositories.Contracts;

namespace Web.Backend.Domain.Repositories;

public class AssignmentsRepository : IAssignmentsRepository
{
    private readonly EducationDbContext _context;
    private readonly IGenericRepository<Assignment> _genericRepo;
    private readonly IMapper _mapper;
    public AssignmentsRepository(EducationDbContext context)
    {
        _context = context;
        _genericRepo = new GenericRepository<Assignment>(context);

        MapperConfiguration config = new(cfg =>
        {
            cfg.CreateMap<Assignment, AssignmentReadDto>();
            cfg.CreateMap<AssignmentCreateDto, Assignment>();
            cfg.CreateMap<AssignmentUpdateDto, Assignment>();
        });
        _mapper = config.CreateMapper();
    }

    public async Task<IEnumerable<AssignmentReadDto>> GetAsync()
    {
        IEnumerable<AssignmentReadDto> dtos = _mapper.Map<IEnumerable<AssignmentReadDto>>(await _genericRepo.GetAllAsync());
        if (dtos.Any())
            return dtos;
        else
            return [];
    }

    public async Task<AssignmentReadDto> GetAsync(string id)
    {
        AssignmentReadDto? dto = _mapper.Map<AssignmentReadDto>(await _genericRepo.GetSingleAsync(id));
        if (dto is null)
            return null;
        else
            return dto;
    }

    public async Task<bool> AddAsync(AssignmentCreateDto dto)
    {
        Assignment newStudent = _mapper.Map<Assignment>(dto);

        try
        {
            await _genericRepo.AddAsync(newStudent);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> UpdateAsync(string id, AssignmentUpdateDto updateDto)
    {
        try
        {
            Assignment? updated = _mapper.Map<Assignment>(updateDto);

            await _genericRepo.UpdateAsync(updated);

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

    private Teacher CreateTeacherRecord()
    {
        string[] names = ["John", "Jane", "Peter", "Anna", "Ema", "Richard"];
        Random rnd = new Random();

        return new Teacher()
        {
            Id = Guid.NewGuid().ToString(),
            FirstName = names[rnd.Next(0, names.Length)],
            LastName = "Doe",
            Age = rnd.Next(18, 60)
        };
    }
}
