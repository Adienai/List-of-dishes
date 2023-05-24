using Menu.BLL.interfaces;
using Menu.DLL.Interface;
using Menu.Domain.DataTransferObject;
using Menu.Domain.Entities;
using Menu.BLL.interfaces;
using System.Net;

namespace Menu.BLL.Services
{
    public class DishesServices : IDishesServices
    {
        private readonly IDishesServices _repository;
        private readonly IMenuDishesRepository _menudishesRepository;
        public CategoryServices(ICategoryRepository repository, IMenuDishesRepository menudishesRepository)
        {
            _repository = repository;
            _menudishesRepository = menudishesRepository;
        }

        public async Task<DishesDto> CreateAsync(DishesDto entity)
        {
            var dishes = new Dishes
            {
                Id = entity.Id,
                Roast = entity.Roast,
                Ragout = entity.Ragout,
                Price = entity.Price,
                CategoryId = entity.CategoryId,
                RatingId = entity.RatingId,
            };
            var result = await _repository.CreateAsync(dishes);
            return new DishesDto
            {
                Id = result.Id,
                Roast = result.Roast,
                Ragout = result.Ragout,
                Price = result.Price,
                CategoryId = result.CategoryId,
                RatingId = result.RatingId,
            };
        }

        public async Task<DishesDto> DeleteAsync(int id)
        {
            var result = await _repository.DeleteAsync(id);
            return new DishesDto
            {
                Id = result.Id,
                Roast = result.Roast,
                Ragout = result.Ragout,
                Price = result.Price,
                CategoryId = result.CategoryId,
                RatingId = result.RatingId,
            };
        }

        public async Task<IEnumerable<DishesDto>> GetAsync()
        {
            var results = await _repository.GetAsync();
            return (from result in results
                    select
                   new DishesDto
                   {
                       Id = results.Id,
                       Roast = results.Roast,
                       Ragout = results.Ragout,
                       Price = results.Price,
                       CategoryId = results.CategoryId,
                       RatingId = results.RatingId,
                   }).ToList();
        }

        public async Task<DishesDto> GetAsync(int id)
        {
            var result = await _repository.GetAsync(id);
            return new DishesDto
            {
                Id = result.Id,
                Roast = result.Roast,
                Ragout = result.Ragout,
                Price = result.Price,
                CategoryId = result.CategoryId,
                RatingId = result.RatingId,
                MenuDishes = (from results in result.MenuDishes
                          select
                          new MenuDishesDto
                          {
                              Id = results.Id,
                              DishesId = results.DishesId,
                              MenuId = results.MenuId,
                          }).ToList(),
            };
        }

        public async Task<DishesDto> UpdateAsync(DishesDto entity)
        {
            var dishes = new Dishes
            {
                Id = entity.Id,
                Roast = entity.Roast,
                Ragout = entity.Ragout,
                Price = entity.Price,
                CategoryId = entity.CategoryId,
                RatingId = entity.RatingId,
            };
            var result = await _repository.UpdateAsync(dishes);
            return new DishesDto
            {
                Id = result.Id,
                Roast = result.Roast,
                Ragout = result.Ragout,
                Price = result.Price,
                CategoryId = result.CategoryId,
                RatingId = result.RatingId,
            };
        }
    }
}