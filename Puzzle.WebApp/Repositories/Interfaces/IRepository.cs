using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle.WebApp.Repositories.Interfaces
{
    public interface IRepository<Entity>
    {
        Task<List<Entity>> GetAllAsync();
        Task<Entity> GetByIdAsync(int id);
        Task<Entity> CreateAsync(Entity entity);
        Task<Entity> UpdateAsync(Entity entity);
        Task<bool> DeleteAsync(Entity entity);
    }
}
