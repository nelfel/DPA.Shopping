﻿using DPA.shopping.DOMIAN.Core.Entities;
using DPA.shopping.DOMIAN.Core.Interfaces;
using DPA.shopping.DOMIAN.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace DPA.Shopping.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _categoryRepository.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _categoryRepository.GetById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost()]
        public async Task<IActionResult> Insert([FromBody] Category category)
        {
            var result = await _categoryRepository.Insert(category);
            if(!result)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Category category)
        {
            var result = await _categoryRepository.Update(category);
            if (!result)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryRepository.Delete(id);
            if (!result)
                return NotFound(result);
            return Ok(result);
        }
    }
}
