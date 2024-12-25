﻿using FirstAPI.DTO.Category;
using FirstAPI.Entity;
using FirstAPI.Repositories.Interfaces;
using FirstAPI.Repostories.Implementations;
using FirstAPI.Repostories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {

        private readonly ICategoryRepository _repository;

     
        public CategoriesController(ICategoryRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int take = 3)
        {
            List<Category> categories = await _repository.GetAll().ToListAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id < 1) return BadRequest();

            Category category = await _repository.GetbyIdAsync(id);
            if (category == null) return NotFound();
            return Ok(category);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCategoryDTO categoryDTO)
        {
            Category category = new Category
            {

                Name = categoryDTO.Name
            };
            await _repository.AddAsync(category);
            await _repository.SaveChangesAsync();

            return Created ();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, string name)
        {
            if (id < 1) return BadRequest();
            Category category = await _repository.GetbyIdAsync(id);
            if (category == null) return NotFound();
            category.Name = name;

            _repository.Update(category);
            await _repository.SaveChangesAsync();
            return NoContent();


            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id < 1) return BadRequest();
            Category category = await _repository.GetbyIdAsync(id);
            if (category == null) return NotFound();

            _repository.Delete(category);
            await _repository.SaveChangesAsync();
            return NoContent();
        }
    }
}
