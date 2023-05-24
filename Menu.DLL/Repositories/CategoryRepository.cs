using Menu.DLL.Data;
using Menu.DLL.Interface;
using Menu.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Menu.DLL.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly AppDBContext _db;

        public CategoryRepository(AppDBContext db) 
        { 
            _db = db;
        }

        public async Task<Category> CreateAsync(Category entity)
        {
            try 
            {
                await _db.Category.AddAsync(entity);
                await _db.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Category> DeleteAsync(Category entity)
        {
            try
            {
                var category = await _db.Category.FindAsync(entity);
                if (category == null)
                    throw new Exception();

                _db.Category.Remove(category);
                await _db.SaveChangesAsync();
                return category;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Category> GetAsync(int id)
        {
            try
            {
                return await _db.Category
                    .AsNoTracking()
                    .Include(x => x.Menu)
                    .Include(x => x.Dishes)
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<IEnumerable<Category>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Category> UpdateAsync(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
