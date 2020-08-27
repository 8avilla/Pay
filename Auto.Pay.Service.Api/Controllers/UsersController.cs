using Blastic.Skylu.Infraestructura.Entities;
using Blastic.Skylu.Servicio.Api.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Blastic.Skylu.Servicio.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUsersApplication _usersApplication; 
        private readonly AppSettings _appSettings;

        public UsersController(IUsersApplication usersApplication, IOptions<AppSettings> appSettings)
        {
            _usersApplication = usersApplication;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate(string userName, string password)
        {
            Respuesta<Users> response = _usersApplication.Authenticate(userName, password);
            if (!response.TieneErrores)
            {
                if (response.Datos != null)
                {
                    response.Datos.Token = Builken(response);
                    return Ok(response);
                }
                else
                    return BadRequest(response);
            }

            return BadRequest(response);
        }

        [HttpPost]
        public IActionResult LogOut(string token, string UserName)
        {
            Respuesta<TokenBlackList> response = _usersApplication.LogOut(token, UserName);
            if (response.TieneErrores)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        private string Builken(Respuesta<Users> users)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, users.Datos.UserName)
                }),
                Expires = DateTime.UtcNow.AddDays(365),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.Audience
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            string tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }

    }
}