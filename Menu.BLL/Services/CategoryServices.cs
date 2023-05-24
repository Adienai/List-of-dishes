using Menu.BLL.interfaces;
using Menu.DLL.Interface;
using Menu.Domain.DataTransferObject;
using Menu.Domain.Entities;
using Menu.BLL.interfaces;
using System.Net;

namespace Menu.BLL.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryServices _repository;
        private readonly IDishesRepository _dishesRepository;
        public CategoryServices(ICategoryRepository repository, IDishesRepository dishesRepository)
        {
            _repository = repository;
            _dishesRepository = dishesRepository;
        }

        public async Task<CategoryDto> CreateAsync(CategoryDto entity)
        {
            var category = new Category
            {
                Id = entity.Id,
                Name = entity.Name,
            };
            var result = await _repository.CreateAsync(category);
            return new CategoryDto
            {
                Id = result.Id,
                Street = result.Street,
                Build = result.Build,
            };
        }

        public async Task<CategoryDto> DeleteAsync(int id)
        {
            var result = await _repository.DeleteAsync(id);
            return new CategoryDto
            {
                Id = result.Id,
                Name = result.Name,
            };
        }

        public async Task<IEnumerable<CategoryDto>> GetAsync()
        {
            var results = await _repository.GetAsync();
            return (from result in results
                    select
                   new CategoryDto
                   {
                       Id = result.Id,
                       Name = result.Name,
                   }).ToList();
        }

        public async Task<CategoryDto> GetAsync(int id)
        {
            var result = await _repository.GetAsync(id);
            return new CategoryDto
            {
                Id = result.Id,
                Name = result.Name,
                Dishes = (from results in result.Dishes
                          select
                          new DishesDto
                          {
                              Id = results.Id,
                              Roast = results.Roast,
                              Ragout = results.Ragout,
                              Price = results.Price,
                              CategoryId = results.CategoryId,
                              RatingId = results.RatingId,
                          }).ToList(),
            };
        }

        public async Task<CategoryDto> RemoveFromDishesAsync(CategoryDto category, List<int> dishesId)
        {
            try
            {
                var result = await _repository.RemoveFromDishesAsync(await _repository.GetAsync(category.Id), dishesId);
                return new CategoryDto
                {
                    Id = result.Id,
                    Name = result.Name,
                    Dishes = (from p in result.Dishes
                              select
                              new DishesDto
                              {
                                  Id = p.Id,
                                  Roast = p.Roast,
                                  Ragout = p.Ragout,
                                  Price = p.Price,
                                  CategoryId = p.CategoryId,
                                  RatingId = p.RatingId,
                              }).ToList(),
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CategoryDto> UpdateAsync(CategoryDto entity)
        {
            var Category = new Category
            {
                Id = entity.Id,
                Name = entity.Name,
            };
            var result = await _repository.UpdateAsync(category);
            return new CategoryDto
            {
                Id = result.Id,
                Name = result.Name,
            };
        }
    }
}