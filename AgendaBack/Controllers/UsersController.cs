using Microsoft.VisualBasic.CompilerServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AgendaBack.Models;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using AgendaBack.Services;
using AgendaBack.Repositories;
using AgendaBack.StaticFunction;

namespace AgendaBack.Controllers
{
    [Route("v1/users")]
    public class UsersController : Controller
    {

        [HttpPost]
        [Route("create")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> UserCreation([FromBody]User model){ 
            try
            {
                Console.WriteLine("Create");
                string encryptedPass = UtilsFunctions.Encrypt(model.Password);
                User newUser = new()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Password = encryptedPass,
                };

                UserRepository.addUser(newUser);
                return newUser;
            } catch (System.Exception Error)
            {
                Console.WriteLine("Erro na criação do usuário");
                Console.WriteLine(Error);
                return StatusCode(500, new { message = "Erro no servidor" });
                
            };
        }
        [HttpPost]
        [Route("delete")]
        [Authorize]
        public async Task<string> UserDelete([FromBody]User model){ 
            Console.WriteLine("Create");
            return "Generatinf";

        }
        [HttpPost]
        [Route("update")]
        [Authorize]
        public async Task<string> UserUpdate([FromBody]User model){ 
            Console.WriteLine("Create");
            return "Generatinf";
        }

        [HttpPost]
        [Route("get")]
        [Authorize]
        public async Task<string> UserGet([FromBody]User model){
            Console.WriteLine("Create");
            return "Generatinf";
        }

    }
}