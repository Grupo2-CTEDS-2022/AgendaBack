using System.Security.Claims;
using System.Text;
using System.Reflection.Metadata;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AgendaBack.Models;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using AgendaBack.Services;
using AgendaBack.Repositories;
using Microsoft.AspNet.Identity;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace AgendaBack.Controllers
{
    [Route("v1/account")]
    public class HomeController : Controller
    {

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody]User model)
        {
            try
            {
                var user = UserRepository.Get(model.Email, model.Password);
                Console.WriteLine("Meu name");
                Console.WriteLine(model.Name);
                Console.WriteLine(model.Password);
                if (user == null)
                    return NotFound(new { message = "Usuário ou senha inválidos" });

                var token = TokenService.GenerateToken(user);
                user.Password = "";
                return new
                {
                    user = user,
                    token = token
                };                
            }
            catch (System.Exception Error)
            {
                Console.WriteLine("Erro no login");
                Console.WriteLine(Error);
                return StatusCode(500, new { message = "Erro no servidor" });
            }
        }

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public async Task<ActionResult<dynamic>> Authentication([FromHeader] string authorization)
        {
            try
            {
                var key = Encoding.ASCII.GetBytes(Settings.Secret);
                var handler = new JwtSecurityTokenHandler();
                var validations = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
                var claims = handler.ValidateToken(authorization.Replace("Bearer ", ""), validations, out var tokenSecure);
                string email = claims.FindFirst(ClaimTypes.Email).Value;
                var user = UserRepository.GetByEmail(email);
                user.Password = "";
                return new
                {
                    user = user,
                };                
            }
            catch (System.Exception Error)
            {
                Console.WriteLine("Erro no login");
                Console.WriteLine(Error);
                return StatusCode(500, new { message = "Erro no servidor" });
            }
        }        

        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anônimo";

        // [HttpGet]
        // [Route("authenticated")]
        // [Authorize]
        // public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);

        [HttpGet]
        [Route("employee")]
        [Authorize(Roles = "employee,manager")]
        public string Employee() => "Funcionário";

        [HttpGet]
        [Route("manager")]
        [Authorize(Roles = "manager")]
        public string Manager() => "Gerente";

        [HttpGet]
        [Route("test")]
        public async Task<string> TestPage()
        {
            return "Apenas um teste";
        }


    }
}