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
        /*
        Method: The initialize method creates a scoped variable "context," which represents a session with the database. 
        If there are any Journies currently in the database, then it will not be seeded.
        The using keyword manages the session with the database, ensuring that the connection opens and closes properly.
        */
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CelesteContext(serviceProvider.GetRequiredService<DbContextOptions<CelesteContext>>()))
            {
                // Look for any Journies.
                if (context.Journey.Any())
                {
                    return;
                }
                var journey = new Journey[]
                {
                    new Journey {
                        Name = "BlastOff",
                        Destination = "Moon",
                    },
                    new Journey {
                        Name = "Rusted Rock",
                        Destination = "Mars"
                    },
                    new Journey {
                        Name = "The Defender",
                        Destination = "Jupiter"
                    },
                    new Journey {
                        Name = "The Jewel",
                        Destination = "Saturn"
                    },
                    new Journey {
                        Name = "Sol",
                        Destination = "Sun"
                    },
                    new Journey {
                        Name = "Solar Shell",
                        Destination = "The Oort Cloud"
                    },
                    new Journey {
                        Name = "The Next Star Neighbor",
                        Destination = "Alpha Centauri"
                    },
                    new Journey {
                        Name = "The Hole",
                        Destination = "Milky Way Black Hole"
                    },
                    new Journey {
                        Name = "Intergalactic",
                        Destination = "Andromeda"
                    }
                };

                foreach (Journey j in journey)
                {
                    context.Journey.Add(j);
                }
                context.SaveChanges();

                var trivia = new Trivia[]
                {
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "Moon").JourneyID,
                      Question = "What is the radius of the moon?",
                      Answer = "1,080 miles",
                      Point = 0
                  },
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "Moon").JourneyID,
                      Question = "What is the average distance between the Moon and the Earth?",
                      Answer = "240,000 miles",
                      Point = 0
                  },
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "Moon").JourneyID,
                      Question = "What is the average distance between the Moon and the Sun?",
                      Answer = "93,205,679 miles",
                      Point = 0
                  },
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "Moon").JourneyID,
                      Question = "About how many Earth days does it take the Moon to rotate on its axis?",
                      Answer = "27",
                      Point = 0
                  },
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "Moon").JourneyID,
                      Question = "What is the approximate age of the Moon?",
                      Answer = "4,500,000,000 years old.",
                      Point = 0
                  },
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "Mars").JourneyID,
                      Question = "What is the average distance between Mars and the Sun?",
                      Answer = "1,420,000 miles",
                      Point = 0
                  },
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "Mars").JourneyID,
                      Question = "What two elements are primarily responsible for Mars' red hue?",
                      Answer = "Iron and Oxygen",
                      Point = 0
                  },
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "Mars").JourneyID,
                      Question = "What is the diameter of Mars?",
                      Answer = "4,200 miles",
                      Point = 0
                  },
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "Mars").JourneyID,
                      Question = "How many moons does Mars have?",
                      Answer = "2",
                      Point = 0
                  },
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "Mars").JourneyID,
                      Question = "What is the name of the giant canyon on Mars?",
                      Answer = "Valles Marineris",
                      Point = 0
                  },
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "Jupiter").JourneyID,
                      Question = "What is the diameter of Jupiter?",
                      Answer = "86,881 miles",
                      Point = 0
                  },
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "Jupiter").JourneyID,
                      Question = "How many moons does Jupiter have?",
                      Answer = "67",
                      Point = 0
                  },
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "Jupiter").JourneyID,
                      Question = "The gas giant Jupiter is composed of 90% ____ and just under 10% ____?",
                      Answer = "Hydrogen Helium",
                      Point = 0
                  },
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "Jupiter").JourneyID,
                      Question = "What is the average distance between Jupiter and the Sun?",
                      Answer = "480,000,000 miles",
                      Point = 0
                  },
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "Jupiter").JourneyID,
                      Question = "How many Earth years are equivalent to one Jovian year?",
                      Answer = "11.86 Earth years",
                      Point = 0
                  },
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "Saturn").JourneyID,
                      Question = "What is the average distance between Saturn and The Sun?",
                      Answer = "888,000,000 miles",
                      Point = 0
                  },
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "Saturn").JourneyID,
                      Question = "What is the approximate diameter of Saturn?",
                      Answer = "72,370 miles",
                      Point = 0
                  },
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "Saturn").JourneyID,
                      Question = "What peculiar shape surrounds Saturn's north pole?",
                      Answer = "Hexagon",
                      Point = 0
                  },
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "Saturn").JourneyID,
                      Question = "Approximately how think are the rings of Saturn?",
                      Answer = "30 feet",
                      Point = 0
                  },
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "Saturn").JourneyID,
                      Question = "Approximately how many Earth years does it take Saturn to revolve around the sun?",
                      Answer = "29",
                      Point = 0
                  },
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "Sun").JourneyID,
                      Question = "What is the diameter of the Sun?",
                      Answer = "865,000 miles",
                      Point = 0
                  },
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "Sun").JourneyID,
                      Question = "What is the average distance between the Sun and Earth?",
                      Answer = "93,000,000 miles",
                      Point = 0
                  },
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "Sun").JourneyID,
                      Question = "What is the surface temperature of the Sun?",
                      Answer = "9,940°F",
                      Point = 0
                  },
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "Sun").JourneyID,
                      Question = "How long does it take light to reach Earth from the Sun?",
                      Answer = "8 minutes 20 seconds",
                      Point = 0
                  },
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "Sun").JourneyID,
                      Question = "Approximately how many Earths would fit inside the Sun?",
                      Answer = "1,300,000",
                      Point = 0
                  },
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "The Oort Cloud").JourneyID,
                      Question = "The Oort cloud defines the boundary of what?",
                      Answer = "The Solar System",
                      Point = 0
                  },
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "The Oort Cloud").JourneyID,
                      Question = "At its closest point, how far away is the Oort Cloud from the center of the Solar System (Sun)? And its farthest?",
                      Answer = ".8 ly, 3.2 ly",
                      Point = 0
                  },
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "The Oort Cloud").JourneyID,
                      Question = "The Oort Cloud is responsible for producing what types of objects that fly by Earth periodically?",
                      Answer = "Comets",
                      Point = 0
                  },
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "The Oort Cloud").JourneyID,
                      Question = "What is the basic shape of the Oort Cloud?",
                      Answer = "A Sphere",
                      Point = 0
                  },
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "The Oort Cloud").JourneyID,
                      Question = "What is the estimated number of objects existing in the Oort Cloud?",
                      Answer = "2,000,000,000,000",
                      Point = 0
                  },
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "Alpha Centauri").JourneyID,
                      Question = "Alpha Centauri is a star system consisting of how many stars?",
                      Answer = "3",
                      Point = 0
                  },
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "Alpha Centauri").JourneyID,
                      Question = "How far away is Alpha Centauri from us?",
                      Answer = "4.37 ly",
                      Point = 0
                  },
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "Alpha Centauri").JourneyID,
                      Question = "Alpha Centauri forms the brightest 'star' in which constellation?",
                      Answer = "Centaurus",
                      Point = 0
                  },
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "Alpha Centauri").JourneyID,
                      Question = "What is the surface temperature of Alpha Centauri?",
                      Answer = "9,940°F",
                      Point = 0
                  },
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "Alpha Centauri").JourneyID,
                      Question = "How many stars are brighter than Alpha Centauri in the night sky?",
                      Answer = "2",
                      Point = 0
                  },
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "Milky Way Black Hole").JourneyID,
                      Question = "Approximately how wide is the Milky Way?",
                      Answer = "100,000 ly",
                      Point = 0
                  },
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "Milky Way Black Hole").JourneyID,
                      Question = "There are at least how many stars in the Milky Way Galaxy?",
                      Answer = "100,000,000,000",
                      Point = 0
                  },
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "Milky Way Black Hole").JourneyID,
                      Question = "What type of galaxy is the Milky Way?",
                      Answer = "Spiral Galaxy",
                      Point = 0
                  },
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "Milky Way Black Hole").JourneyID,
                      Question = "Likely what is Saggitarius A, the object at the center of the Milky Way?",
                      Answer = "A supermassive black hole",
                      Point = 0
                  },
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "Milky Way Black Hole").JourneyID,
                      Question = "How massive is Saggitarius A (in solar masses)?",
                      Answer = "4,200,000 solar masses",
                      Point = 0
                  },
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "Andromeda").JourneyID,
                      Question = "What is Andromeda?",
                      Answer = "A spiral galaxy",
                      Point = 0
                  },
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "Andromeda").JourneyID,
                      Question = "Approximately how far away is Andromeda from The Milky Way?",
                      Answer = "2,500,000 ly",
                      Point = 0
                  },
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "Andromeda").JourneyID,
                      Question = "Approximately how far across is the Andromeda Galaxy?",
                      Answer = "220,000 ly",
                      Point = 0
                  },
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "Andromeda").JourneyID,
                      Question = "The Milky Way and Andromeda Galaxies are expected to collide in how many years?",
                      Answer = "4,500,000 years",
                      Point = 0
                  },
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "Andromeda").JourneyID,
                      Question = "Approximately how many stars are in the Andromeda Galaxy?",
                      Answer = "1,000,000,000,000 stars",
                      Point = 0
                  }
                };

                foreach (Trivia t in trivia)
                {
                    context.Trivia.Add(t);
                }
                context.SaveChanges();


                var celesteHost = new CelesteHost[]
                {
                  new CelesteHost {
                      Lesson = "This is a Moon Lesson.",
                      JourneyID = journey.Single(j => j.Destination == "Moon").JourneyID,
                      ImageURL = "https://s-media-cache-ak0.pinimg.com/564x/48/4c/34/484c347c62cbb2d7759adcac763a6994.jpg"
                  },
                  new CelesteHost {
                      Lesson = "This is a Mars Lesson.",
                      JourneyID = journey.Single(j => j.Destination == "Mars").JourneyID,
                      ImageURL = "https://s-media-cache-ak0.pinimg.com/564x/48/4c/34/484c347c62cbb2d7759adcac763a6994.jpg"
                  },
                  new CelesteHost {
                      Lesson = "This is a Jupiter Lesson.",
                      JourneyID = journey.Single(j => j.Destination == "Jupiter").JourneyID,
                      ImageURL = "https://s-media-cache-ak0.pinimg.com/564x/48/4c/34/484c347c62cbb2d7759adcac763a6994.jpg"
                  },
                  new CelesteHost {
                      Lesson = "This is a Saturn Lesson.",
                      JourneyID = journey.Single(j => j.Destination == "Saturn").JourneyID,
                      ImageURL = "https://s-media-cache-ak0.pinimg.com/564x/48/4c/34/484c347c62cbb2d7759adcac763a6994.jpg"
                  },
                  new CelesteHost {
                      Lesson = "This is a Sun Lesson.",
                      JourneyID = journey.Single(j => j.Destination == "Sun").JourneyID,
                      ImageURL = "https://s-media-cache-ak0.pinimg.com/564x/48/4c/34/484c347c62cbb2d7759adcac763a6994.jpg"
                  },
                  new CelesteHost {
                      Lesson = "This is an Oort Cloud Lesson.",
                      JourneyID = journey.Single(j => j.Destination == "The Oort Cloud").JourneyID,
                      ImageURL = "https://s-media-cache-ak0.pinimg.com/564x/48/4c/34/484c347c62cbb2d7759adcac763a6994.jpg"
                  },
                  new CelesteHost {
                      Lesson = "This is an Alpha Centauri Lesson.",
                      JourneyID = journey.Single(j => j.Destination == "Alpha Centauri").JourneyID,
                      ImageURL = "https://s-media-cache-ak0.pinimg.com/564x/48/4c/34/484c347c62cbb2d7759adcac763a6994.jpg"
                  },
                  new CelesteHost {
                      Lesson = "This is a Milky Way Lesson.",
                      JourneyID = journey.Single(j => j.Destination == "Milky Way Black Hole").JourneyID,
                      ImageURL = "https://s-media-cache-ak0.pinimg.com/564x/48/4c/34/484c347c62cbb2d7759adcac763a6994.jpg"
                  },
                  new CelesteHost {
                      Lesson = "This is an Andromeda Lesson.",
                      JourneyID = journey.Single(j => j.Destination == "Andromeda").JourneyID,
                      ImageURL = "https://s-media-cache-ak0.pinimg.com/564x/48/4c/34/484c347c62cbb2d7759adcac763a6994.jpg"
                  }
                };

                foreach (CelesteHost ch in celesteHost)
                {
                    context.CelesteHost.Add(ch);
                }
                context.SaveChanges();

                var explorer = new Explorer[]
                {
                    new Explorer {
                      firebaseID = "test1",
                      FirstName = "Jerry",
                      LastName = "Jones",
                      Username = "Gjere1",
                      Age = 20,
                      DateCreated = new DateTime()
                  },
                    new Explorer {
                      firebaseID = "test2",
                      FirstName = "Jerome",
                      LastName = "Jerkins",
                      Username = "Gjere2",
                      Age = 30,
                      DateCreated = new DateTime()
                  },
                    new Explorer {
                      firebaseID = "test3",
                      FirstName = "Geraldo",
                      LastName = "Jerfrey",
                      Username = "Gjere3",
                      Age = 40,
                      DateCreated = new DateTime()
                  }
                };

                foreach (Explorer e in explorer)
                {
                    context.Explorer.Add(e);
                }
                context.SaveChanges();
            }
        }
    }
}