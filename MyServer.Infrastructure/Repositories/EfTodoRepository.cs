using Microsoft.EntityFrameworkCore;
using MyServer.Application.Interfaces;
using MyServer.Domain.Entities;
using MyServer.Infrastructure.Persistence;

namespace MyServer.Infrastructure.Repositories
{
    public class EfTodoRepository : ITodoRepository
    {
        private readonly AppDbContext _context;

        public EfTodoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TodoItem>> GetAllAsync()
        {
            return await _context.Todos.AsNoTracking().ToListAsync();
        }

        public async Task<TodoItem?> GetByIdAsync(Guid id)
        {
            return await _context.Todos.FindAsync(id);
        }

        public async Task AddAsync(TodoItem item)
        {
            await _context.Todos.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TodoItem item)
        {
            _context.Todos.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Todos.FindAsync(id);
            if (entity != null)
            {
                _context.Todos.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
