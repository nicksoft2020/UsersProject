using Domain.Entities;
using ProjectDb.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectDb.Initial
{
    public sealed class InitDb
    {
        public static void Initial(ApplicationContext db)
        {
            if (!db.Users.Any())
            {
                db.Users.AddRange(
                    new User
                    {
                        Name = "Kolia",
                        Active = false
                    },
                    new User
                    {
                        Name = "Vika",
                        Active = false
                    },
                    new User
                    {
                        Name = "Serhii",
                        Active = false
                    },
                    new User
                    {
                        Name = "Katia",
                        Active = false
                    },
                    new User
                    {
                        Name = "Nastya",
                        Active = false
                    }
                    );
                db.SaveChanges();
            }
        }
    }
}
