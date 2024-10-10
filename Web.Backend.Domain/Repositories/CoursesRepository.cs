using AutoMapper;
using Web.Backend.Domain.Data;
using Web.Backend.Domain.DTO.Education;
using Web.Backend.Domain.Models.Education;
using Web.Backend.Domain.Models.Users;
using Web.Backend.Domain.Repositories.Contracts;

namespace Web.Backend.Domain.Repositories;

public class CoursesRepository : ICoursesRepository
{
    private readonly EducationDbContext _context;
    private readonly IGenericRepository<Course> _genericRepo;
    private readonly IMapper _mapper;
    public CoursesRepository(EducationDbContext context)
    {
        _context = context;
        _genericRepo = new GenericRepository<Course>(context);

        MapperConfiguration config = new(cfg =>
        {
            cfg.CreateMap<Course, CourseReadDto>();
            cfg.CreateMap<CourseCreateDto, Course>();
            cfg.CreateMap<CourseUpdateDto, Course>();
        });
        _mapper = config.CreateMapper();
    }

    public async Task<IEnumerable<CourseReadDto>> GetAsync()
    {
        IEnumerable<CourseReadDto> dtos = _mapper.Map<IEnumerable<CourseReadDto>>(await _genericRepo.GetAllAsync());
        if (dtos.Any())
            return dtos;
        else
            return [];
    }

    public async Task<CourseReadDto> GetAsync(string id)
    {
        CourseReadDto? dto = _mapper.Map<CourseReadDto>(await _genericRepo.GetSingleAsync(id));
        if (dto is null)
            return null;
        else
            return dto;
    }

    public async Task<bool> AddAsync(CourseCreateDto dto)
    {
        Course newStudent = _mapper.Map<Course>(dto);
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

    public async Task<bool> UpdateAsync(string id, CourseUpdateDto updateDto)
    {
        try
        {
            Course? updated = _mapper.Map<Course>(updateDto);

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
