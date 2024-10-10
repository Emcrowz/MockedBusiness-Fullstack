using Web.Backend.Domain.DTO.Users;
using Web.Backend.Domain.Models.Users;

namespace Web.Backend.Domain.Repositories.Contracts;

public interface ITeachersRepository
{
    Task<bool> AddAsync(TeacherCreateDto dto);
    Task<bool> DeleteAsync(string id);
    Task<IEnumerable<TeacherReadDto>> GetAsync();
    Task<TeacherReadDto> GetAsync(string id);
    Task<bool> UpdateAsync(string id, TeacherUpdateDto updateDto);
}