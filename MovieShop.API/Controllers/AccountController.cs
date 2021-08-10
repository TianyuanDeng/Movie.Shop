using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MovieShop.Core.Models.Request;
using MovieShop.Core.Models.Response;
using MovieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public AccountController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserRegisterRequestModel userRegisterRequestModel)
        {
            if (ModelState.IsValid)
            {
                var createdUser = await _userService.CreateUser(userRegisterRequestModel);
                //return CreatedAtRoute(nameof(GetUserById), new { id = createdUser.Id }, null);
                return Ok(createdUser);
            }

            return BadRequest(new { message = "Please correct the input inforrmation" });
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequestModel loginRequest)
        {
           
            var user = await _userService.ValidateUser(loginRequest.Email, loginRequest.Password);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return BadRequest(new { message = "Please correct the input inforrmation" });
            }

            var token = GenerateJWT(user);
            return Ok(new { token });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserDetails(id);

            if (user == null)
                throw new Exception("User Id does not exists!");

            return Ok(user);
        }

        private string GenerateJWT(UserLoginResponseModel userLoginResponseModel)
        {
            var claims = new List<Claim> {
                     new Claim (ClaimTypes.NameIdentifier, userLoginResponseModel.Id.ToString()),
                     new Claim( JwtRegisteredClaimNames.GivenName, userLoginResponseModel.FirstName ),
                     new Claim( JwtRegisteredClaimNames.FamilyName, userLoginResponseModel.LastName ),
                     new Claim( JwtRegisteredClaimNames.Email, userLoginResponseModel.Email )
            };

            if (userLoginResponseModel.Roles != null) claims.AddRange(userLoginResponseModel.Roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["TokenSettings:PrivateKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var expires = DateTime.UtcNow.AddHours(_configuration.GetValue<double>("TokenSettings:ExpirationHours"));
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identityClaims,
                Audience = _configuration["TokenSettings:Audience"],
                Issuer = _configuration["TokenSettings:Issuer"],
                SigningCredentials = credentials,
                Expires = expires
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var encodedToken = tokenHandler.CreateToken(tokenDescriptor);
            
            return tokenHandler.WriteToken(encodedToken);
        }

    }
}
