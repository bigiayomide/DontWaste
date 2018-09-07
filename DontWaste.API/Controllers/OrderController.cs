using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DontWaste.Api.Data.Contracts.IDataRepositories;
using DontWaste.Api.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DontWaste.API.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        IOrderRepository _IOrderRepository;

        public OrderController(IOrderRepository IOrderRepository)
        {
            _IOrderRepository = IOrderRepository;
        }

        [Route("GetOrders")]
        [HttpGet]
        public IActionResult GetOrders()
        {
            return Ok(_IOrderRepository.Get());
        }

        [Route("GetOrder")]
        [HttpGet("{Id}")]
        public IActionResult GetOrder(string Id)
        {
            return Ok(_IOrderRepository.Get());
        }

        [Route("CreateOrder")]
        [HttpPost]
        public IActionResult Index(Order order)
        {
            return Ok(_IOrderRepository.Add(order));
        }
    }
}