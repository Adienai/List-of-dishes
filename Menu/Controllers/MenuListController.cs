using Microsoft.AspNetCore.Mvc;
using Menu.Domain.DataTransferObject;
using Menu.BLL.interfaces;
using System;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Identity.Client;

namespace Menu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuListController : ControllerBase
    {
        private readonly IMenuListServices _menuListServices;

        public MenuListController(IMenuListServices menuListServices)
        {
            _menuListServices = menuListServices;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuListtDto>>> Get()
        {
            try
            {
                return Ok(await _menuListServices.GetAsync());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<IEnumerable<MenuListtDto>>> Get(int Id)
        {
            try
            {
                return Ok(await _menuListServices.GetAsync(Id));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<MenuListtDto>> Post([FromBody] MenuListtDto value)
        {
            try
            {
                return Ok(await _menuListServices.CreateAsync(value));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<MenuListtDto>> Put(int Id, [FromBody] MenuListtDto value)
        {
            if (Id != value.Id)
                return BadRequest();

            try
            {
                return Ok(await _menuListServices.UpdateAsync(value));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<MenuListtDto>> DeleteAsync(int Id)
        {
            try
            {
                return Ok(await _menuListServices.DeleteAsync(Id));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}