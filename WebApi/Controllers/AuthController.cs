using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApi.Modelos;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [ActionName("login")]
        [AllowAnonymous]
        public IActionResult Login([FromForm] Login model)
        {

            if (model.UsuarioId == "usuario" && model.Contrasenia == "1234")
            {
                model.Nombre = "Hola Mundo";
                var tokenHandler = new JwtSecurityTokenHandler();

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.NameIdentifier, model.UsuarioId.ToString()),
                    new Claim(ClaimTypes.Name, model.Nombre)
                }),
                    Expires = DateTime.Now.AddDays(7),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes("H0l4MunDO-CoronaV1RuS")),
                        SecurityAlgorithms.HmacSha512Signature),
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                return Ok(new
                {
                    token = tokenHandler.WriteToken(token),
                    expiration = token.ValidTo 
                });
            }
            return Unauthorized();
        }

    }
}