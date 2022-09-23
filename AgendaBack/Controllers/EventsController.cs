using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AgendaBack.Models;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using AgendaBack.Services;
using AgendaBack.Repositories;

namespace AgendaBack.Controllers
{
    [Route("v1/events")]
    public class EventsController : Controller
    {
        [HttpPost]
        [Route("create")]
        [Authorize]
        public async Task<string> EventCreation([FromBody]User model){ 
            Console.WriteLine("Create");
            return "Generatinf";
        }
        [HttpPost]
        [Route("delete")]
        [Authorize]
        public async Task<string> EventDelete([FromBody]User model){ 
            Console.WriteLine("Create");
            return "Generatinf";

        }
        [HttpPost]
        [Route("update")]
        [Authorize]
        public async Task<string> EventUpdate([FromBody]User model){ 
            Console.WriteLine("Create");
            return "Generatinf";
        }

        [HttpPost]
        [Route("get")]
        [Authorize]
        public async Task<string> EventGet([FromBody]User model){
            Console.WriteLine("Create");
            return "Generatinf";
        }

    }
}