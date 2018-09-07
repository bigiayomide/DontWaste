using Dontwaste.Api.Data.ViewModel;
using DontWaste.Api.Core.Common.Attributes;
using DontWaste.Api.Data.Contracts.IDataRepositories;
using DontWaste.Api.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using DontWaste.Api.Business.Contracts;

namespace DontWaste.API.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        IUserRepository _UserRepository;
        IBusinessEngine _BusinessEngine;
        public UserController(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }
        [Route("GetUsers")]
        [HttpGet]
        [Authorize(Policy = "Admin")]
        public IActionResult GetUsers()
        {
            return View(_UserRepository.Get());
        }

        [Route("GetUserByLogin")]
        [HttpPost]
        [AllowAnonymous]
        public IActionResult GetUserByLogin(LoginModel model)
        {
            return View(_BusinessEngine.Login(model));
        }

        [Route("CreateOrder")]
        [HttpPost]
        public IActionResult CreateOrder(Order model)
        {
            _UserRepository.CreateOrder(model, User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Ok();
        }
    }
}