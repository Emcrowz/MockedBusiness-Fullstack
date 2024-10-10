using Web.Backend.Domain.DTO.Education;

namespace Web.Backend.Domain.Repositories.Contracts;

public interface ICoursesRepository
{
    Task<bool> AddAsync(CourseCreateDto dto);
    Task<bool> DeleteAsync(string id);
    Task<IEnumerable<CourseReadDto>> GetAsync();
    Task<CourseReadDto> GetAsync(string id);
    Task<bool> UpdateAsync(string id, CourseUpdateDto updateDto);
}