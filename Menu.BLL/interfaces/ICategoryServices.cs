using Menu.Domain.DataTransferObject;
using Menu.Domain.Entities;

namespace Menu.BLL.interfaces
{
    internal class ICategoryServices
    {
        public Task<CategoryDto> CreateAsync(CategoryDto entity);
        public Task<CategoryDto> DeleteAsync(int id);
        public Task<CategoryDto> UpdateAsync(CategoryDto entity);
        public Task<IEnumerable<CategoryDto>> GetAsync();
        public Task<CategoryDto> GetAsync(int id);
        public Task<CategoryDto> RemoveFromDishesAsync(CategoryDto category, List<int> dishesId);
    }
}
