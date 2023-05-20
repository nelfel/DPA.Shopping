using DPA.shopping.DOMIAN.Core.Entities;
using DPA.shopping.DOMIAN.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace DPA.Shopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteRepository _favoriteRepository;

        public FavoriteController(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var result = await _favoriteRepository.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _favoriteRepository.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost()]
        public async Task<IActionResult> Insert([FromBody] Favorite favorite)
        {
            var result = await _favoriteRepository.Insert(favorite);
            if (!result)
            {

                return BadRequest();
            }
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Favorite favorite)
        {
            var result = await _favoriteRepository.Update(favorite);
            if (!result)
            {

                return BadRequest();
            }
            return Ok(result);
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _favoriteRepository.Delete(id);
            if (!result)
            {

                return NotFound(result);
            }
            return Ok(result);
        }

    }
}

