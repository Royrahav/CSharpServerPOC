using MyServer.Application.DTOs;

namespace MyServer.Application.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<ReadTodoDto>> GetAllAsync();
        Task<ReadTodoDto?> GetByIdAsync(Guid id);
        Task<ReadTodoDto> CreateAsync(CreateTodoDto dto);
        Task UpdateAsync(Guid id, UpdateTodoDto dto);
        Task DeleteAsync(Guid id);
    }
}
