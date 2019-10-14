using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectDb.EF;
using ProjectDb.Storage;

namespace Users.Controllers
{
    [Route("api/users")]
    public class HomeController : Controller
    {
        private EFUnitOfWork repository;

        public HomeController(ApplicationContext context)
        {
            if (context != null)
            {
                repository = new EFUnitOfWork(context);
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            List<User> users = (List<User>) await repository.Users.GetAllAsync();
            return users;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]User user)
        {
            if (ModelState.IsValid)
            {
                await repository.Users.Update(user);
                return Ok(user);
            }
            return BadRequest(ModelState);
        }



    }
}