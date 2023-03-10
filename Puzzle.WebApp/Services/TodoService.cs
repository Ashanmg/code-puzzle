using System.Collections.Generic;
using System.Threading.Tasks;
using Puzzle.WebApp.Models;
using Puzzle.WebApp.Repositories.Interfaces;
using Puzzle.WebApp.Services.Interfaces;

namespace Puzzle.WebApp.Services
{
    public class TodoService : IBaseService<Todo>
    {
        private readonly IRepository<Todo> _repository;

        public TodoService(IRepository<Todo> repository)
        {
            _repository = repository;
        }
        public async Task<Todo> CreateAsync(Todo entity)
        {
            return await _repository.CreateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Todo todo = await _repository.GetByIdAsync(id);
            if (todo != null)
            {
                return await _repository.DeleteAsync(todo);
            }

            return false;
        }

        public async Task<List<Todo>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Todo> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Todo> UpdateAsync(Todo entity)
        {
            return await _repository.UpdateAsync(entity);
        }
    }
}