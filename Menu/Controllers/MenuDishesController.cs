using Microsoft.AspNetCore.Mvc;
using Menu.Domain.DataTransferObject;
using Menu.BLL.interfaces;
using System;
using Microsoft.AspNetCore.Http.HttpResults;


namespace Menu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuDishesController : ControllerBase
    {
        private readonly IMenuDishesServices _menuDishesServices;

        public MenuDishesController(IMenuDishesServices menuDishesServices)
        {
            _menuDishesservices = menuDishesServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuDishesDto>>> Get()
        {
            try
            {
                return Ok(await _menuDishesServices.GetAsync());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<IEnumerable<MenuDishesDto>>> Get(int Id)
        {
            try
            {
                return Ok(await _menuDishesServices.GetAsync(Id));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<MenuDishesDto>> Post([FromBody] MenuDishesDto value)
        {
            try
            {
                return Ok(await _menuDishesServices.CreateAsync(value));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<MenuDishesDto>> Put(int Id, [FromBody] MenuDishesDto value)
        {
            if (Id != value.Id)
                return BadRequest();

            try
            {
                return Ok(await _menuDishesServices.UpdateAsync(value));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<MenuDishesDto>> DeleteAsync(int Id)
        {
            try
            {
                return Ok(await _menuDishesServices.DeleteAsync(Id));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}