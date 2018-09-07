using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DontWaste.Api.Data.Contracts.IDataRepositories;
using DontWaste.Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DontWaste.API.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryRepository _CategoryRepository;
        public CategoryController(ICategoryRepository CategoryRepository)
        {
            _CategoryRepository = CategoryRepository;
        }
        [Route("GetCategory")]
        [HttpGet]
        public IActionResult GetCategories()
        {
            return Ok(_CategoryRepository.Get());
        }
        [Route("GetCategorybyId")]
        [HttpPut("{Id}")]
        [HttpGet]
        public IActionResult GetCategorybyId(string Id)
        {
            return Ok(_CategoryRepository.Get(Id));
        }

        [Route("DeleteCategoryId")]
        [HttpPut("{Id}")]
        public IActionResult DeleteCategoryId(string Id)
        {
            _CategoryRepository.Remove(Id);
            return Ok();
        }
        
        [Route("UpdateCategorybyId")]
        [HttpPut("{Id}")]
        public IActionResult UpdateCategorybyId(Category category)
        {
            return Ok(_CategoryRepository.Update(category));
        }

        [Route("CreateCategory")]
        [HttpPut("{Id}")]
        public IActionResult CreateCategory(Category category)
        {
            if(ModelState.IsValid)
            return Ok(_CategoryRepository.Add(category));

            return NotFound();
        }
    }
}