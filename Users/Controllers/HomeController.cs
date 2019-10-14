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
    /// <summary>
    /// This is a class which manages application
    /// </summary>
    [Route("api/users")]
    public class HomeController : Controller
    {
        private EFUnitOfWork repository;    // Repository value.

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

        /// <summary>
        /// Getting the flist of users from database.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            List<User> users = (List<User>) await repository.Users.GetAllAsync();
            return users;
        }

        /// <summary>
        /// Updating user in database.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
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