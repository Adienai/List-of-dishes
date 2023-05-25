using Microsoft.AspNetCore.Mvc;
using Menu.BLL.Interfaces;
using Menu.Domain.DataTransferObject;

namespace Menu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IDishesServices _dishesServices;

        public PersonController(IDishesServices personServices)
        {
            _dishesServices = personServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DishesDtoList>>> Get()
        {
            try
            {
                return Ok(await _dishesServices.GetAsync());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DishesDto>> Get(int id)
        {
            try
            {
                return Ok(await _dishesServices.GetAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<DishesDto>> Post([FromBody] DishesDtoList value)
        {
            try
            {
                return Ok(await _dishesServices.CreateAsync(value));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DishesDto>> Put(int id, [FromBody] DishesDtoList value)
        {
            if (id != value.Id)
                return BadRequest();

            try
            {
                return Ok(await _dishesServices.UpdateAsync(value));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DishesDto>> DeleteAsync(int id)
        {
            try
            {
                return Ok(await _dishesServices.DeleteAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("AddTo")]
        public async Task<ActionResult<DishesDto>> AddTo(CategoryToDishes value)
        {
            try
            {
                return Ok(await _dishesServices.AddToCategoryAsync(value));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}