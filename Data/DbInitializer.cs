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
                var journey = new Journey[]
                {
                    new Journey {
                        Name = "BlastOff",
                        Destination = "Moon"
                    },
                    new Journey {
                        Name = "Fourth Rock",
                        Destination = "Mars"
                    },
                    new Journey {
                        Name = "The Jewel",
                        Destination = "Saturn"
                    },
                    new Journey {
                        Name = "The Defender",
                        Destination = "Jupiter"
                    },
                    new Journey {
                        Name = "Sol",
                        Destination = "Sun"
                    },
                    new Journey {
                        Name = "The Big Belt",
                        Destination = "The Kuiper Belt/Pluto"
                    },
                    new Journey {
                        Name = "Borderlands",
                        Destination = "The Oort Cloud"
                    },
                    new Journey {
                        Name = "Far From Home",
                        Destination = "Voyager 1"
                    },
                    new Journey {
                        Name = "Our Trinary Neighbor",
                        Destination = "Alpha Centauri"
                    },
                    new Journey {
                        Name = "Another World",
                        Destination = "Proxima B"
                    },
                    new Journey {
                        Name = "The Hole",
                        Destination = "Milky Way Black Hole"
                    },
                    new Journey {
                        Name = "Intergalactic",
                        Destination = "Andromeda"
                    },
                    new Journey {
                        Name = "The Unbounded Perimeter",
                        Destination = "Cosmic Microwave Background"
                    }
                };

                foreach (Journey j in journey)
                {
                    context.Journey.Add(j);
                }
                context.SaveChanges();

                var Triv = new Trivia[]
                {
                  new Trivia {
                      TriviaID = 1,
                      JourneyID = journey.Single(j => j.Destination == "Moon").JourneyID,
                      Question = "What is the radius of the moon?",
                      Answer = "1,080 miles",
                      Point = 0
                  },
                  new Trivia {
                      TriviaID = 2,
                      JourneyID = journey.Single(j => j.Destination == "Mars").JourneyID,
                      Question = "What is the average distance between the Moon and the Earth?",
                      Answer = "240,000 miles",
                      Point = 0
                  },
                  new Trivia {
                      TriviaID = 3,
                      JourneyID = journey.Single(j => j.Destination == "Saturn").JourneyID,
                      Question = "What is the average distance between the Moon and the Sun?",
                      Answer = "93,205,679 miles",
                      Point = 0
                  },
                  new Trivia {
                      TriviaID = 4,
                      JourneyID = journey.Single(j => j.Destination == "Jupiter").JourneyID,
                      Question = "What is the speed of rotation of the Moon?",
                      Answer = "",
                      Point = 0
                  },
                  new Trivia {
                      TriviaID = journey.Single(j => j.Destination == "Sun").JourneyID,
                      Question = "Test Question",
                      Answer = "Test Answer",
                      Point = 0
                  },
                  new Trivia {
                      TriviaID = journey.Single(j => j.Destination == " The Kuiper Belt/Pluto").JourneyID,
                      Question = "Test Question",
                      Answer = "Test Answer",
                      Point = 0
                  },
                  new Trivia {
                      TriviaID = journey.Single(j => j.Destination == "The Oort Cloud").JourneyID,
                      Question = "Test Question",
                      Answer = "Test Answer",
                      Point = 0
                  },
                  new Trivia {
                      TriviaID = journey.Single(j => j.Destination == "Voyager 1").JourneyID,
                      Question = "Test Question",
                      Answer = "Test Answer",
                      Point = 0
                  },
                  new Trivia {
                      TriviaID = journey.Single(j => j.Destination == "Alpha Centauri").JourneyID,
                      Question = "Test Question",
                      Answer = "Test Answer",
                      Point = 0
                  },
                  new Trivia {
                      TriviaID = journey.Single(j => j.Destination == "Proxima B").JourneyID,
                      Question = "Test Question",
                      Answer = "Test Answer",
                      Point = 0
                  },
                  new Trivia {
                      TriviaID = journey.Single(j => j.Destination == "Milky Way Black Hole").JourneyID,
                      Question = "Test Question",
                      Answer = "Test Answer",
                      Point = 0
                  },
                  new Trivia {
                      TriviaID = journey.Single(j => j.Destination == "Andromeda").JourneyID,
                      Question = "Test Question",
                      Answer = "Test Answer",
                      Point = 0
                  },
                  new Trivia {
                      TriviaID = journey.Single(j => j.Destination == "Cosmic Microwave Background").JourneyID,
                      Question = "Test Question",
                      Answer = "Test Answer",
                      Point = 0
                  }
                };

                foreach (Trivia tr in Triv)
                {
                    context.Trivia.Add(tr);
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