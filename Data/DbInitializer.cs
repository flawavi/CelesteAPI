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
                      Category = "Planet/Moon",
                      Question = "Test Question",
                      Answer = "Test Answer",
                      Point = null
                  },
                  new QandA {
                      QandAID = 2,
                      Category = "Star",
                      Question = "Test Question",
                      Answer = "Test Answer",
                      Point = null
                  },
                  new QandA {
                      QandAID = 3,
                      Category = "Black Hole",
                      Question = "Test Question",
                      Answer = "Test Answer",
                      Point = null
                  },
                  new QandA {
                      QandAID = 1,
                      Category = "Galaxy",
                      Question = "Test Question",
                      Answer = "Test Answer",
                      Point = null
                  },
                  new QandA {
                      QandAID = 1,
                      Category = "CMB",
                      Question = "Test Question",
                      Answer = "Test Answer",
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
                      CelesteHostID = 1,
                      Lesson = "This is a test Lesson",
                      Greeting = "This is a test Greeting",
                      Name = "Celeste",
                      Category = "Planet",
                      ImageURL = "https://s-media-cache-ak0.pinimg.com/564x/48/4c/34/484c347c62cbb2d7759adcac763a6994.jpg"
                  }
                };

                foreach (CelesteHost ch in celesteHost)
                {
                    context.CelesteHost.Add(ch);
                }
                context.SaveChanges();

                var journey = new Journey[]
                {
                    new Journey {
                        JourneyID = 1, 
                        Name = "BlastOff",
                        FromXToY = "Earth to Moon"
                    },
                    new Journey {
                        JourneyID = 2, 
                        Name = "Fourth Rock",
                        FromXToY = "Moon to Mars"
                    },new Journey {
                        JourneyID = 3, 
                        Name = "The Jewel",
                        FromXToY = "Mars to Saturn"
                    },
                    new Journey {
                        JourneyID = 4, 
                        Name = "The Defender",
                        FromXToY = "Saturn to Jupiter"
                    },
                    new Journey {
                        JourneyID = 5, 
                        Name = "Sol",
                        FromXToY = "Jupiter to Sun"
                    },
                    new Journey {
                        JourneyID = 6, 
                        Name = "The Big Belt",
                        FromXToY = "Sun to Kuiper Belt/Pluto"
                    },
                    new Journey {
                        JourneyID = 7, 
                        Name = "Borderlands",
                        FromXToY = "Kuiper Belt/Pluto to Oort Cloud"
                    },
                    new Journey {
                        JourneyID = 8, 
                        Name = "Far From Home",
                        FromXToY = "Oort Cloud to Voyager"
                    },
                    new Journey {
                        JourneyID = 9, 
                        Name = "Our Trinary Neighbor",
                        FromXToY = "Voyager to Alpha Centauri"
                    },
                    new Journey {
                        JourneyID = 10, 
                        Name = "Another World",
                        FromXToY = "Alpha Centauri to Proxima B"
                    },
                    new Journey {
                        JourneyID = 11, 
                        Name = "The Hole",
                        FromXToY = "Proxima B to Milky Way Black Hole"
                    },
                    new Journey {
                        JourneyID = 12, 
                        Name = "Intergalactic",
                        FromXToY = "Milk Way Black Hole to Andromeda"
                    },
                    new Journey {
                        JourneyID = 13, 
                        Name = "The Unbounded Perimeter",
                        FromXToY = "Andromeda to Cosmic Microwave Background"
                    }
                };

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
                      Age = 30,
                      Email = "Jeremy@Jeremy.com",
                      DateCreated = new DateTime()
                  },
                  new User {
                      UserID = 3,
                      FirstName = "Gerald",
                      LastName = "Jones",
                      UserName = "Gjere3",
                      Age = 40,
                      Email = "Gerald@Gerald.com",
                      DateCreated = new DateTime()
                  }
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