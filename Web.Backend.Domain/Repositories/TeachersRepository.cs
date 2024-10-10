using AutoMapper;
using Web.Backend.Domain.Data;
using Web.Backend.Domain.DTO.Users;
using Web.Backend.Domain.Models.Users;
using Web.Backend.Domain.Repositories.Contracts;

namespace Web.Backend.Domain.Repositories;

public class TeachersRepository : ITeachersRepository
{
    private readonly EducationDbContext _context;
    private readonly IGenericRepository<Teacher> _genericRepo;
    private readonly IMapper _mapper;
    public TeachersRepository(EducationDbContext context)
    {
        _context = context;
        _genericRepo = new GenericRepository<Teacher>(context);

        MapperConfiguration config = new(cfg => {
            cfg.CreateMap<Teacher, TeacherReadDto>();
            cfg.CreateMap<TeacherCreateDto, Teacher>();
            cfg.CreateMap<TeacherUpdateDto, Teacher>();
        });
        _mapper = config.CreateMapper();
    }

    public async Task<IEnumerable<TeacherReadDto>> GetAsync()
    {
        IEnumerable<TeacherReadDto> dtos = _mapper.Map<IEnumerable<TeacherReadDto>>(await _genericRepo.GetAllAsync());
        if (dtos.Any())
            return dtos;
        else
            return [];
    }

    public async Task<TeacherReadDto> GetAsync(string id)
    {
        TeacherReadDto? dto = _mapper.Map<TeacherReadDto>(await _genericRepo.GetSingleAsync(id));
        if (dto is null)
            return null;
        else
            return dto;
    }

    public async Task<bool> AddAsync(TeacherCreateDto dto)
    {
        Teacher newStudent = _mapper.Map<Teacher>(dto);
        newStudent.Id = Guid.NewGuid().ToString();

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

    public async Task<bool> UpdateAsync(string id, TeacherUpdateDto updateDto)
    {
        try
        {
            Teacher? updated = _mapper.Map<Teacher>(updateDto);

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