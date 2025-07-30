using MyServer.Application.Interfaces;
using MyServer.Domain.Entities;
using System.Collections.Concurrent;

namespace MyServer.Infrastructure.Repositories
{
    public class InMemoryTodoRepository : ITodoRepository
    {
        private readonly ConcurrentDictionary<Guid, TodoItem> _storage = new();

        public Task<IEnumerable<TodoItem>> GetAllAsync()
        {             
            return Task.FromResult(_storage.Values.AsEnumerable());
        }

        public Task<TodoItem?> GetByIdAsync(Guid id)
        {
            _storage.TryGetValue(id, out var item);
            return Task.FromResult(item);
        }

        public Task AddAsync(TodoItem item)
        {
            _storage[item.Id] = item;
            return Task.CompletedTask;
        }

        public Task UpdateAsync(TodoItem item)
        {
            _storage[item.Id] = item;
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid id)
        {
            _storage.TryRemove(id, out _);
            return Task.CompletedTask;
        }
    }
}
