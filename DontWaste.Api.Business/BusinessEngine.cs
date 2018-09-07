using Dontwaste.Api.Data.Repositories;
using Dontwaste.Api.Data.ViewModel;
using DontWaste.Api.Business.Contracts;
using DontWaste.Api.Core.Contracts;
using DontWaste.Api.Data.Contracts.IDataRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DontWaste.Api.Business
{
    public class BusinessEngine: IBusinessEngine
    {
        private readonly IDataRepositoryFactory _DataRepositoryFactory;
        private readonly IUserRepository _UserRepository;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        public BusinessEngine(IDataRepositoryFactory dataRepositoryFactory, IUserRepository UserRepository, UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            _DataRepositoryFactory = dataRepositoryFactory;
            _UserRepository = UserRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }
        public void Test()
        {
            var data=_DataRepositoryFactory.GetDataRepository<UserRepository>();
            _UserRepository.Get();
        }

        public async Task<object> Login(LoginModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (result.Succeeded)
            {
                var appUser = _userManager.Users.SingleOrDefault(r => r.Email == model.Email);
                return await GenerateJwtToken(model.Email, appUser);
            }

            throw new ApplicationException("INVALID_LOGIN_ATTEMPT");
        }
        public bool UserExists(string UserEmail)
        {
            var user = _userManager.Users.SingleOrDefault(r => r.Email == UserEmail);
            if (user != null)
            {
                return false;
            }
            return true;
        }
        public async Task<object> Register(RegisterModel model)
        {
            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return await GenerateJwtToken(model.Email, user);
            }

            throw new ApplicationException("UNKNOWN_ERROR");
        }

        public async Task<object> GenerateJwtToken(string email, IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
