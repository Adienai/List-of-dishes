using Menu.DLL.Data;
using Menu.DLL.Interface;
using Menu.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Menu.DLL.Repositories
{
    public class DishesRepository : IRepository<Dishes>
    {
        private readonly AppDBContext _db;

        public DishesRepository(AppDBContext db)
        {
            _db = db;
        }

        public async Task<Dishes> CreateAsync(Dishes entity)
        {
            try
            {
                await _db.Dishes.AddAsync(entity);
                await _db.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Dishes> DeleteAsync(Dishes entity)
        {
            try
            {
                var dishes = await _db.Dishes.FindAsync(entity);
                if (dishes == null)
                    throw new Exception();

                _db.Dishes.Remove(dishes);
                await _db.SaveChangesAsync();
                return dishes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Dishes> GetAsync(int id)
        {
            try
            {
                return await _db.Dishes
                    .AsNoTracking()
                    .Include(x => x.Category)
                    .Include(x => x.MenuDishes)
                    .Include(x => x.Rating)
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<IEnumerable<Dishes>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Dishes> UpdateAsync(Dishes entity)
        {
            throw new NotImplementedException();
        }
    }
}
