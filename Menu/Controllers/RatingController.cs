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
    public class RatingController : ControllerBase
    {
        private readonly IRatingServices _ratingServices;

        public RatingController(IRatingServices ratingServices)
        {
            _ratingServices = ratingServices;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<RatingDto>>> Get()
        {
            try
            {
                return Ok(await _ratingServices.GetAsync());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<IEnumerable<RatingDto>>> Get(int Id)
        {
            try
            {
                return Ok(await _ratingServices.GetAsync(Id));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<ActionResult<RatingDto>> Post([FromBody] RatingDto value)
        {
            try
            {
                return Ok(await _ratingServices.CreateAsync(value));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<RatingDto>> Put(int Id, [FromBody] RatingDto value)
        {
            if (Id != value.Id)
                return BadRequest();

            try
            {
                return Ok(await _ratingServices.UpdateAsync(value));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<RatingDto>> DeleteAsync(int Id)
        {
            try
            {
                return Ok(await _ratingServices.DeleteAsync(Id));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}