using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using ProjectDb.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDb.Repositories
{
    /// <summary>
    /// This repository works with users in database
    /// </summary>
    public sealed class UserRepository : IRepository<User>
    {
        private ApplicationContext db;  // Database context.

        public UserRepository(ApplicationContext context)
        {
            if(context != null)
            {
                db = context;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        /// <summary>
        /// Getting users
        /// </summary>
        /// <returns>Users</returns>
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await db.Users.ToListAsync();
        }
    }
}
