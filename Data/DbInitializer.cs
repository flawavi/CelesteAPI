using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Celeste.Models;

/*
Author: Fletcher Watson
*/

namespace Celeste.Data
{
    //The DbInitializer class is used to seed the database (CelesteContext)
    public static class DbInitializer
    {
        //Method: The initialize method creates a scoped variable "context," which represents a session with the database. 
        //If there are any QandA currently in the database, then it will not be seeded.
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CelesteContext(serviceProvider.GetRequiredService<DbContextOptions<CelesteContext>>()))
            {
                // Look for any QandA.
                if (context.QandA.Any())
                {
                    return;
                }

                var QA = new QandA[]
                {
                  new QandA {
                      QandAID = 1,
                      Category = "Planet",
                      Question = "Carson",
                      Answer = "Alexander",
                      Point = null
                  },
                  new QandA {
                      QandAID = 1,
                      Category = "Planet",
                      Question = "Carson",
                      Answer = "Alexander",
                      Point = null
                  },
                  new QandA {
                      QandAID = 1,
                      Category = "Planet",
                      Question = "Carson",
                      Answer = "Alexander",
                      Point = null
                  },
                  new QandA {
                      QandAID = 1,
                      Category = "Planet",
                      Question = "Carson",
                      Answer = "Alexander",
                      Point = null
                  },
                  new QandA {
                      QandAID = 1,
                      Category = "Planet",
                      Question = "Carson",
                      Answer = "Alexander",
                      Point = null
                  },
                };

                foreach (QandA qa in QA)
                {
                    context.QandA.Add(qa);
                }
                context.SaveChanges();


                var celesteHost = new CelesteHost[]
                {
                  new CelesteHost {
                      Lesson = "Electronics",
                      Greeting = ""
                  },
                  new CelesteHost {
                      Lesson = "Appliances",
                      Greeting = ""
                  },
                  new CelesteHost {
                      Lesson = "Housewares",
                      Greeting = ""
                  },
                };

                foreach (CelesteHost ch in celesteHost)
                {
                    context.CelesteHost.Add(ch);
                }
                context.SaveChanges();

                var user = new User[]
                {
                  new User {
                      UserID = 1,
                      FirstName = "Jerry",
                      LastName = "Jones",
                      UserName = "Gjere1",
                      Age = 20,
                      Email = "Jerry@Jerry.com",
                      DateCreated = new DateTime()
                  },
                 new User {
                      UserID = 2,
                      FirstName = "Jeremy",
                      LastName = "Jones",
                      UserName = "Gjere2",
                      Age = 20,
                      Email = "Jeremy@Jeremy.com",
                      DateCreated = new DateTime()
                  },
                  new User {
                      UserID = 3,
                      FirstName = "Gerald",
                      LastName = "Jones",
                      UserName = "Gjere3",
                      Age = 20,
                      Email = "Gerald@Gerald.com",
                      DateCreated = new DateTime()
                  },
                };

                foreach (User u in user)
                {
                    context.User.Add(u);
                }
                context.SaveChanges();
            }
        }
    }
}