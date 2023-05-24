using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.BLL.interfaces
{
    internal class IDishesServices
    {
        public Task<DishesDto> CreateAsync(DishesDto entity);
        public Task<DishesDto> DeleteAsync(int id);
        public Task<DishesDto> UpdateAsync(CategoryDto entity);
        public Task<IEnumerable<DishesDto>> GetAsync();
        public Task<DishesDto> GetAsync(int id);
        public Task<DishesDto> RemoveFromDishesAsync(DishesDto dishes, List<int> Id);
    }
}
