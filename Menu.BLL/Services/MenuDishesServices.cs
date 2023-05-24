using Menu.BLL.interfaces;
using Menu.DLL.Interface;
using Menu.Domain.DataTransferObject;
using Menu.Domain.Entities;
using Menu.BLL.interfaces;
using System.Net;

namespace Menu.BLL.Services
{
    public class MenuDishesServices : IMenuDishesServices
    {
        private readonly IDishesServices _repository;
        public CategoryServices(IMenuDishesRepository repository)
        {
            _repository = repository;
        }

        public async Task<MenuDishesDto> CreateAsync(MenuDishesDto entity)
        {
            var menudishes = new MenuDishes
            {
                Id = entity.Id,
                DishesId = entity.DishesId,
                MenuId = entity.MenuId,
            };
            var result = await _repository.CreateAsync(MenuDishesDto);
            return new MenuDishesDto
            {
                Id = result.Id,
                DishesId = result.DishesId,
                MenuId = result.MenuId,
            };
        }

        public async Task<MenuDishesDto> DeleteAsync(int id)
        {
            var result = await _repository.DeleteAsync(id);
            return new MenuDishesDto
            {
                Id = result.Id,
                DishesId = result.DishesId,
                MenuId = result.MenuId,
            };
        }

        public async Task<IEnumerable<MenuDishesDto>> GetAsync()
        {
            var results = await _repository.GetAsync();
            return (from result in results
                    select
                   new MenuDishesDto
                   {
                       Id = results.Id,
                       DishesId = results.DishesId,
                       MenuId = results.MenuId,
                   }).ToList();
        }

        public async Task<MenuDishesDto> GetAsync(int id)
        {
            var result = await _repository.GetAsync(id);
            return new MenuDishesDto
            {
                Id = result.Id,
                DishesId = result.DishesId,
                MenuId = result.MenuId,
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

        public async Task<MenuDishesDto> UpdateAsync(MenuDishesDto entity)
        {
            var dishes = new MenuDishes
            {
                Id = result.Id,
                DishesId = result.DishesId,
                MenuId = result.MenuId,
            };
            var result = await _repository.UpdateAsync(dishes);
            return new MenuDishesDto
            {
                Id = result.Id,
                DishesId = result.DishesId,
                MenuId = result.MenuId,
            };
        }
    }
}