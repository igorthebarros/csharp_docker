using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly Context _context;
        public BaseRepository(Context context)
        {
            _context = context;
        }
        public async Task AddAsync(TEntity entity)
        {
            try
            {
                await _context.Set<TEntity>().AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("Class: BaseRepository | Method: AddAsync | Error: " + e.Message);
                throw;
            }
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            try
            {
                await _context.Set<TEntity>().AddRangeAsync(entities);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("Class: BaseRepository | Method: AddRangeAsync | Error: " + e.Message);
                throw;
            }
        }

        public async Task DeleteAsync(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("Class: BaseRepository | Method: DeleteAsync | Error: " + e.Message);
                throw;
            }
        }

        public async Task DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
            try
            {
                _context.Set<TEntity>().RemoveRange(entities);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("Class: BaseRepository | Method: DeleteRangeAsync | Error: " + e.Message);
                throw;
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            try
            {
                return await _context.Set<TEntity>().ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("Class: BaseRepository | Method: GetAllAsync | Error: " + e.Message);
                throw;
            }
        }

        public async Task<TEntity> GetAsync(uint id)
        {
            try
            {
                return await _context.Set<TEntity>().FindAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine("Class: BaseRepository | Method: GetAsync | Error: " + e.Message);
                throw;
            }
        }

        public async Task Update(TEntity entity)
        {
            try
            {
                 _context.Set<TEntity>().Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("Class: BaseRepository | Method: UpdateAsync | Error: " + e.Message);
                throw;
            }
        }

        public async Task UpdateRange(IEnumerable<TEntity> entities)
        {
            try
            {
                _context.Set<TEntity>().UpdateRange(entities);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("Class: BaseRepository | Method: UpdateRangeAsync | Error: " + e.Message);
                throw;
            }
        }
    }
}
