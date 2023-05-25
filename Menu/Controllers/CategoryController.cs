using Microsoft.AspNetCore.Mvc;
using Menu.BLL.interfaces;
using Menu.Domain.DataTransferObject;

namespace Menu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _services;

        public CategoryController(ICategoryServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> Get()
        {
            try
            {
                return Ok(await _services.GetAsync());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> Get(int id)
        {
            try
            {
                return Ok(await _services.GetAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> Post([FromBody] CategoryDto value)
        {
            try
            {
                return Ok(await _services.CreateAsync(value));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryDto>> Put(int id, [FromBody] CategoryDto value)
        {
            if (id != value.Id)
                return BadRequest();

            try
            {
                return Ok(await _services.UpdateAsync(value));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryDto>> Delete(int id)
        {
            try
            {
                return Ok(await _services.DeleteAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("AddTo")]
        public async Task<ActionResult<CategoryDto>> AddTo(CategoryToDishes value)
        {
            try
            {
                return Ok(await _services.AddToDishesAsync(value));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("CreateWithPersons")]
        public async Task<ActionResult<CategoryDto>> CreateWithPersons(CategoryDto value)
        {
            try
            {
                return Ok(await _services.CreateWithDishesAsync(value));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("RemovePersons")]
        public async Task<ActionResult<CategoryDto>> RemovePersons(CategoryDishesDto value)
        {
            try
            {
                return Ok(await _services.RemoveFromCategoryAsync(value.CategoryId, value.DishessId));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("AddRangeDishess")]
        public async Task<ActionResult<CategoryDto>> AddRangePersons(CategoryDishesDto value)
        {
            try
            {
                return Ok(await _services.AddDishessRangeAsync(value.CategoryId, value.DishessId));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
