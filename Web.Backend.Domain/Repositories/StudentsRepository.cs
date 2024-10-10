using AutoMapper;
using Web.Backend.Domain.Data;
using Web.Backend.Domain.DTO.Users;
using Web.Backend.Domain.Models.Users;
using Web.Backend.Domain.Repositories.Contracts;

namespace Web.Backend.Domain.Repositories;

public class StudentsRepository : IStudentsRepository
{
    private readonly EducationDbContext _context;
    private readonly IGenericRepository<Student> _genericRepo;
    private readonly IMapper _mapper;
    public StudentsRepository(EducationDbContext context)
    {
        _context = context;
        _genericRepo = new GenericRepository<Student>(context);

        MapperConfiguration config = new(cfg => {
            cfg.CreateMap<Student, StudentReadDto>();
            cfg.CreateMap<StudentCreateDto, Student>();
            cfg.CreateMap<StudentUpdateDto, Student>();
        });
        _mapper = config.CreateMapper();
    }

    public async Task<IEnumerable<StudentReadDto>> GetAsync()
    {
        IEnumerable<StudentReadDto> dtos = _mapper.Map<IEnumerable<StudentReadDto>>(await _genericRepo.GetAllAsync());
        if (dtos.Any())
            return dtos;
        else
            return [];
    }

    public async Task<StudentReadDto> GetAsync(string id)
    {
        StudentReadDto? dto = _mapper.Map<StudentReadDto>(await _genericRepo.GetSingleAsync(id));
        if (dto is null)
            return null;
        else
            return dto;
    }

    public async Task<bool> AddAsync(StudentCreateDto dto)
    {
        Student newStudent = _mapper.Map<Student>(dto);
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

    public async Task<bool> UpdateAsync(string id, StudentUpdateDto updateDto)
    {
        try
        {
            Student? updated = _mapper.Map<Student>(updateDto);

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

    private Student CreateStudentRecord()
    {
        string[] names = ["John", "Jane", "Peter", "Anna", "Ema", "Richard"];
        Random rnd = new Random();

        return new Student()
        {
            Id = Guid.NewGuid().ToString(),
            FirstName = names[rnd.Next(0, names.Length)],
            LastName = "Doe",
            Age = rnd.Next(18, 60)
        };
    }
}