using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dontwaste.Api.Data.ViewModel;
using DontWaste.Api.Core.Common.Attributes;
using DontWaste.Api.Data.Contracts.IDataRepositories;
using DontWaste.Api.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DontWaste.API.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        IUserRepository _UserRepository;
        public UserController(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }
        [Route("GetUsers")]
        [HttpGet]
        public IActionResult GetUsers()
        {
            return View(_UserRepository.Get());
        }

        [Route("GetUserByLogin")]
        [HttpPost]
        public IActionResult GetUserByLogin(LoginModel model)
        {
            return View(_UserRepository.Get());
        }

        [Route("CreateOrder")]
        [HttpPost]
        public IActionResult CreateOrder(Order model)
        {
            return View(_UserRepository.CreateOrder(model));
        }
    }
}