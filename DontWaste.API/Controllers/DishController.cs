using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DontWaste.Api.Data.Contracts.IDataRepositories;
using DontWaste.Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DontWaste.API.Controllers
{    public class DishController : Controller
    {
        IDishRepository _IDishRepository;
        public DishController(IDishRepository IDishRepository)
        {
            _IDishRepository = IDishRepository;
        }
        [Route("GetDish")]
        [HttpGet]
        public IActionResult GetDishies()
        {
            return Ok(_IDishRepository.Get());
        }
        [Route("GetDishbyId")]
        [HttpPut("{Id}")]
        [HttpGet]
        public IActionResult GetDishbyId(string Id)
        {
            return Ok(_IDishRepository.Get(Id));
        }

        [Route("DeleteDishId")]
        [HttpPut("{Id}")]
        public IActionResult DeleteDishId(string Id)
        {
            _IDishRepository.Remove(Id);
            return Ok();
        }

        [Route("UpdateDishbyId")]
        [HttpPut("{Id}")]
        public IActionResult UpdateDishbyId(Dish dish)
        {
            return Ok(_IDishRepository.Update(dish));
        }

        [Route("CreateDish")]
        [HttpPut("{Id}")]
        public IActionResult CreateDish(Dish dish)
        {
            if (ModelState.IsValid)
                return Ok(_IDishRepository.Add(dish));

            return NotFound();
        }
    }
}