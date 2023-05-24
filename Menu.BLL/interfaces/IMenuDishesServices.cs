using Menu.Domain.DataTransferObject;
using Menu.Domain.Entities;

namespace Menu.BLL.interfaces
{
    internal class IMenuDishesServices
    {
        public Task<MenuDishesDto> CreateAsync(MenuDishesDto entity);
        public Task<MenuDishesDto> DeleteAsync(int id);
        public Task<MenuDishesDto> UpdateAsync(MenuDishesDto entity);
        public Task<IEnumerable<MenuDishesDto>> GetAsync();
        public Task<MenuDishesDto> GetAsync(int id);
    }
}
