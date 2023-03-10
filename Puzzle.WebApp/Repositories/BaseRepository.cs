using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;
using Puzzle.WebApp.Infrastructure;
using Puzzle.WebApp.Models;
using Puzzle.WebApp.Repositories.Interfaces;

namespace Puzzle.WebApp.Repositories
{
    public class BaseRepository<Entity> : IRepository<Entity>, IDisposable where Entity : class
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<Entity> dbSet;
        private bool disposed = false;

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
            dbSet = context.Set<Entity>();
        }

        public async Task<Entity> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<Entity> CreateAsync(Entity entity)
        {
            dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Entity> UpdateAsync(Entity entity)
        {
            dbSet.AddOrUpdate(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(Entity entity)
        {
            dbSet.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Entity>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}