using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.BLL.interfaces
{
    internal class IMenuListServices
    {
        public Task<MenuListDto> CreateAsync(MenuListDto entity);
        public Task<MenuListDto> DeleteAsync(int id);
        public Task<MenuListDto> UpdateAsync(MenuListDto entity);
        public Task<IEnumerable<MenuListDto>> GetAsync();
        public Task<MenuListDto> GetAsync(int id);
    }
}
