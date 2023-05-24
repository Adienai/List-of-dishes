using Menu.BLL.interfaces;
using Menu.DLL.Interface;
using Menu.Domain.DataTransferObject;
using Menu.Domain.Entities;
using Menu.BLL.interfaces;
using System.Net;

namespace Menu.BLL.Services
{
    public class MenuListServices : IMenuListServices
    {
        private readonly IMenuListServices _repository;
        private readonly IMenuDishesServices _menuDishesrepository;
        public MenuListServices(IMenuListServices repository, IMenuDishesServices menuDishesrepository)
        {
            _repository = repository;
            _menuDishesrepository = menuDishesrepository;
        }

        public async Task<MenuListDto> CreateAsync(MenuListDto entity)
        {
            var menudishes = new MenuList
            {
                Id = entity.Id,
                Difinition = entity.Difinition,
                Total = entity.Total,
            };
            var result = await _repository.CreateAsync(MenuListDto);
            return new MenuListDto
            {
                Id = result.Id,
                Difinition = result.Difinition,
                Total = result.Total,
            };
        }

        public async Task<MenuListDto> DeleteAsync(int id)
        {
            var result = await _repository.DeleteAsync(id);
            return new MenuListDto
            {
                Id = result.Id,
                Difinition = result.Difinition,
                Total = result.Total,
            };
        }

        public async Task<IEnumerable<MenuListDto>> GetAsync()
        {
            var results = await _repository.GetAsync();
            return (from result in results
                    select
                   new MenuListDto
                   {
                       Id = results.Id,
                       Difinition = results.Difinition,
                       Total = results.Total,
                   }).ToList();
        }

        public async Task<MenuListDto> GetAsync(int id)
        {
            var result = await _repository.GetAsync(id);
            return new MenuListDto
            {
                Id = result.Id,
                Difinition = result.Difinition,
                Total = result.Total,
                MenuDishes = (from results in result.MenuDishes
                              select
                              new MenuDishesDto
                              {
                                  Id = result.Id,
                                  DishesId = result.DishesId,
                                  MenuId = result.MenuId,
                              }).ToList(),
            };
        }

        public async Task<MenuListDto> UpdateAsync(MenuListDto entity)
        {
            var dishes = new MenuList
            {
                Id = entity.Id,
                Difinition = entity.Difinition,
                Total = entity.Total,
            };
            var result = await _repository.UpdateAsync(dishes);
            return new MenuListDto
            {
                Id = result.Id,
                Difinition = result.Difinition,
                Total = result.Total,
            };
        }
    }
}