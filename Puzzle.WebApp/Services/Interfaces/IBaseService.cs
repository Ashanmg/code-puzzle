using System.Collections.Generic;
using System.Threading.Tasks;

namespace Puzzle.WebApp.Services.Interfaces
{
    public interface IBaseService<Entity> where Entity : class
    {
        Task<List<Entity>> GetAllAsync();
        Task<Entity> GetByIdAsync(int id);
        Task<Entity> CreateAsync(Entity entity);
        Task<Entity> UpdateAsync(Entity entity);
        Task<bool> DeleteAsync(int id);
    }
}
