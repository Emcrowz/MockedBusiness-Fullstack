using Web.Backend.Domain.DTO.Users;

namespace Web.Backend.Domain.Repositories.Contracts;

public interface IStudentsRepository
{
    Task<IEnumerable<StudentReadDto>> GetAsync();
    Task<StudentReadDto> GetAsync(string id);
    Task<bool> AddAsync(StudentCreateDto dto);
    Task<bool> UpdateAsync(string id, StudentUpdateDto updateDto);
    Task<bool> DeleteAsync(string id);
}