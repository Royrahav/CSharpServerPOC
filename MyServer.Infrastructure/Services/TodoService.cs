using MyServer.Application.DTOs;
using MyServer.Application.Interfaces;
using MyServer.Application.Services;
using MyServer.Domain.Entities;

namespace MyServer.Infrastructure.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _repository;

        public TodoService(ITodoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ReadTodoDto>> GetAllAsync()
        {
            var items = await _repository.GetAllAsync();
            return items.Select(item => new ReadTodoDto
            {
                Id = item.Id,
                Title = item.Title,
                IsCompleted = item.IsCompleted
            });
        }

        public async Task<ReadTodoDto?> GetByIdAsync(Guid id)
        {
            var item = await _repository.GetByIdAsync(id);
            return item == null ? null : new ReadTodoDto
            {
                Id = item.Id,
                Title = item.Title,
                IsCompleted = item.IsCompleted
            };
        }

        public async Task<ReadTodoDto> CreateAsync(CreateTodoDto dto)
        {
            var newItem = new TodoItem
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                IsCompleted = false
            };

            await _repository.AddAsync(newItem);

            return new ReadTodoDto
            {
                Id = newItem.Id,
                Title = newItem.Title,
                IsCompleted = newItem.IsCompleted
            };
        }

        public async Task UpdateAsync(Guid id, UpdateTodoDto dto)
        {
            var updatedItem = new TodoItem
            {
                Id = id,
                Title = dto.Title,
                IsCompleted = dto.IsCompleted
            };

            await _repository.UpdateAsync(updatedItem);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
