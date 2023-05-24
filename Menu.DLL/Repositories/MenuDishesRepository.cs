using Menu.DLL.Data;
using Menu.DLL.Interface;
using Menu.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Menu.DLL.Repositories
{
    public class MenuDishesRepository : IRepository<MenuDishes>
    {
        private readonly AppDBContext _db;

        public MenuDishesRepository(AppDBContext db)
        {
            _db = db;
        }

        public async Task<MenuDishes> CreateAsync(MenuDishes entity)
        {
            try
            {
                await _db.MenuDishes.AddAsync(entity);
                await _db.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MenuDishes> DeleteAsync(MenuDishes entity)
        {
            try
            {
                var MenuDishes = await _db.MenuDishes.FindAsync(entity);
                if (MenuDishes == null)
                    throw new Exception();

                _db.MenuDishes.Remove(MenuDishes);
                await _db.SaveChangesAsync();
                return MenuDishes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MenuDishes> GetAsync(int id)
        {
            try
            {
                return await _db.MenuDishes
                    .AsNoTracking()
                    .Include(x => x.Dishes)
                    .Include(x => x.Menu)
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<IEnumerable<MenuDishes>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MenuDishes> UpdateAsync(MenuDishes entity)
        {
            throw new NotImplementedException();
        }
    }
}

