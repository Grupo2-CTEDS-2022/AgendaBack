using System.Buffers.Text;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Text;
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
    [Route("v1/events")]
    public class EventsController : Controller
    {
        public static User getUserFromHeader(string authorization){
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
            return user;

        }

        public class Teste{
            public string Name { get; set; }
            public string Description { get; set; }
            public string Start { get; set; }
            public string End { get; set; }

        }

        [HttpPost]
        [Route("create")]
        [Authorize]
        public async Task<ActionResult<dynamic>> EventCreation([FromBody] Event eventCreate, [FromHeader] string authorization){ 
            try
            {
                User user = getUserFromHeader(authorization);
                EventRepository.CreateEvent(
                    user.Id, eventCreate.Name,
                    eventCreate.Description, eventCreate.Start,
                    eventCreate.End
                );
                return StatusCode(200, new { message = "Evento Criado" });
            }
            catch (System.Exception Error)
            {
                Console.WriteLine(Error);                
                return StatusCode(500, new { message = "Erro na criação do evento" });
            }
        }

        [HttpPost]
        [Route("delete")]
        [Authorize]
        public async Task<ActionResult<dynamic>> EventDelete([FromBody]Event deleteEvent, [FromHeader] string authorization){ 
            try
            {
                User user = getUserFromHeader(authorization);
                Console.WriteLine("Delete Event");
                Console.WriteLine(user.Id);
                Console.WriteLine(deleteEvent.Id);
                EventRepository.DeleteEvent(deleteEvent.Id, user.Id);
                return StatusCode(200, new { message = "Evento Deletado" });
            }
            catch (System.Exception Error)
            {                
                return StatusCode(500, new { message = "Erro ao deletar o evento" });
            }
        }

        [HttpPost]
        [Route("update")]
        [Authorize]
        public async Task<ActionResult<dynamic>> EventUpdate([FromBody] Event editEvent, [FromHeader] string authorization){ 
            try
            {
                Console.WriteLine("Update Event");
                User user = getUserFromHeader(authorization);
                EventRepository.EditEvent(editEvent.Id, editEvent.Name, editEvent.Description, editEvent.Start, editEvent.End, user.Id);
                return StatusCode(200, new { message = "Evento editado" });
                
            }
            catch (System.Exception Error)
            {                
                Console.WriteLine(Error);
                return StatusCode(500, new { message = "Erro no update do evento" });
            }
        }

        class PartialEvent{
            public string Id { get; set; }
            public string Start { get; set; }
            public string End { get; set; }

        }

        [HttpPost]
        [Route("get")]
        [Authorize]
        public async Task<ActionResult<dynamic>> EventGet([FromBody]Event getEvent, [FromHeader] string authorization){
            try
            {
                Console.WriteLine("Get Event");
                User user = getUserFromHeader(authorization);
                Console.WriteLine(getEvent.Start);
                Console.WriteLine(getEvent.End);
                List<Event> eventList = EventRepository.ReadInInterval(user.Id ,getEvent.Start, getEvent.End);
                return StatusCode(200, eventList);
                
            }
            catch (System.Exception Error)
            {
                Console.WriteLine(Error);
                return StatusCode(500, new { message = "Erro na busca do evento" });
            }
        }

    }
}