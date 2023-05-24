using Menu.DLL.Data;
using Menu.DLL.Interface;
using Menu.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Menu.DLL.Repositories
{
    public class MenuListRepository : IRepository<MenuList>
    {
        private readonly AppDBContext _db;

        public MenuListRepository(AppDBContext db)
        {
            _db = db;
        }

        public async Task<MenuList> CreateAsync(MenuList entity)
        {
            try
            {
                await _db.MenuList.AddAsync(entity);
                await _db.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MenuList> DeleteAsync(MenuList entity)
        {
            try
            {
                var MenuList = await _db.MenuList.FindAsync(entity);
                if (MenuList == null)
                    throw new Exception();

                _db.MenuList.Remove(MenuList);
                await _db.SaveChangesAsync();
                return MenuList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MenuList> GetAsync(int id)
        {
            try
            {
                return await _db.MenuList
                    .AsNoTracking()
                    .Include(x => x.MenuDishes)
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<IEnumerable<MenuList>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MenuList> UpdateAsync(MenuList entity)
        {
            throw new NotImplementedException();
        }
    }
}