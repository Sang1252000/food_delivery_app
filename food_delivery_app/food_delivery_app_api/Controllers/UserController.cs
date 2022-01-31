using Food_Delivery_App_API.Entities;
using Food_Delivery_App_API.Model;
using Food_Delivery_App_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Food_Delivery_App_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository UserRepository;



        public UserController(IUserRepository repository)
        {
            this.UserRepository = repository;
        }
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string emailId, string password)
        {
            UserModule model = null;
            User user = UserRepository.ValidateUser(emailId, password);
            if (user != null)
            {
                string token = GetToken(user);
                model = new UserModule() { UserId = user.UserId, Token = token, Role = user.UserRole };
            }
            else
            {
                model = new UserModule() { UserId = 0, Token = "", Role = "Invalid Role" };
            }



            return Ok(model);
        }

        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(User user)
        {
            try
            {
                UserRepository.AddUser(user);
                return Ok("Your userID is: " + user.UserId);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        private string GetToken(User user)
        {
            var _config = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json").Build();
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var expiry = DateTime.Now.AddMinutes(120);
            var securityKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials
        (securityKey, SecurityAlgorithms.HmacSha256);



            //    var token = new JwtSecurityToken(issuer: issuer,
            //audience: audience,



            //expires: DateTime.Now.AddMinutes(120),
            //signingCredentials: credentials);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                   {
                    new Claim(ClaimTypes.Name, user.UserId.ToString()),
                    new Claim(ClaimTypes.Role, user.UserRole.ToString())
                   }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };



            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }
    }
}