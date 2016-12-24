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
                      Question = "True or false? All of the other planets could fit neatly between the Earth and Moon.",
                      Answer = "True",
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
                      Question = "What are the names of the Martian moons?",
                      Answer = "Phobos and Deimos",
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
                      Answer = "86,880 miles",
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
                      Question = "What is the name of the enormous storm on the surface of Jupiter. ",
                      Answer = "The Great Red Spot",
                      Point = 0
                  },
                  new Trivia {
                      JourneyID = journey.Single(j => j.Destination == "Saturn").JourneyID,
                      Question = "What is the average distance between Saturn and The Sun?",
                      Answer = "888,200,000 miles",
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
                      Question = "What is the name of Saturn's largest moon?",
                      Answer = "Titan   ",
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
                      Lesson = @"Some planets have many moons, and some have none. The Earth has one, and we call it The Moon.
                      The Moon has a significant impact on the geologic activity of Earth, specifically the tides. Without it, Earth would look and behave very differently. The Moon is approximately 27% the volume of Earth, with a radius of about 1,080 miles, but because it is relatively close to Earth, with an average distance of 240,000 miles, the effects of the Moon's gravity on Earth are pronounced. Interestingly, the rest of the planets (Mercury, Venus, Mars, Jupiter, Saturn, Neptune and Uranus) would all fit snugly between the Moon and Earth at that distance.
                      The Moon is about 4.5B years old, and it has been orbiting the Earth for so long that it has become tidally locked to Earth. The Moon revolves around the Earth every 27 days, and it takes the same amount of time for the Moon to revolve on its own axis. This is the principle reason why we only ever see one side of the Moon. ",
                      JourneyID = journey.Single(j => j.Destination == "Moon").JourneyID,
                      ImageURL = "https://s-media-cache-ak0.pinimg.com/564x/48/4c/34/484c347c62cbb2d7759adcac763a6994.jpg"
                  },
                  new CelesteHost {
                      Lesson = @"Mars is the fourth planet from the Sun, and sits approximately 1,420,000 miles from the Sun on average. Mars is a relatively small planet, with a diameter of 4,200 miles - just over half of Earth's. Mars has two small moons, Phobos and Deimos. Phobos has a diameter of 14 miles, and Deimos' is just over half the size of Phobos, with a diameter of 7.7 miles.
                      Mars glows red from our vantage point due to the fact that Mars is composed primarily of Oxygen and Iron, most of which is literally rusted. Despite its bleak, rocky terrain, Mars offers many jaw dropping geological wonders, including Valles Marineris, a canyon more than 2,500 miles long, 120 miles wide and 4.4 miles deep. Of the four terrestrial planets, Mars is the furthest from the Sun.",
                      JourneyID = journey.Single(j => j.Destination == "Mars").JourneyID,
                      ImageURL = "https://s-media-cache-ak0.pinimg.com/564x/48/4c/34/484c347c62cbb2d7759adcac763a6994.jpg"
                  },
                  new CelesteHost {
                      Lesson = @"Jupiter is the largest and most gravitationally influential planet in the solar system, orbiting the Sun from a distance of approximately 480 million miles. Jupiter has a diameter of 86,880 miles, meaning it is over 1,300 times the volume of Earth. Yes, that means over 1,300 Earths can fit inside of Jupiter.
                      Because it is a gas giant, it is not the most dense planet in the solar system, but its sheer volume makes up for it. Jupiter is composed mostly of two elements, 90% Hydrogen and just under 10% helium. Jupiter's strong gravity and rapid rotational velocity combine to form intense storms at the surface, the most famous of which is known as the Great Red Spot, which is so large that about 2.5 Earths could fit inside the storm.
                      Jupiter's powerful gravitational pull means that it can sustain orbits for many satellites, and indeed Jupiter has the most moons of any planet, at a whopping 67.",
                      JourneyID = journey.Single(j => j.Destination == "Jupiter").JourneyID,
                      ImageURL = "https://s-media-cache-ak0.pinimg.com/564x/48/4c/34/484c347c62cbb2d7759adcac763a6994.jpg"
                  },
                  new CelesteHost {
                      Lesson = @"Saturn, also a gas giant, is the most visually stunning planet in the solar system. Its most identifiable trait is its vast ring system, which is primarily composed of tiny icy bodies with some very large structures mixed in. Surprisingly, the ring system is incredibly thin, with an average thickness of only 30 feet!
                      Saturn has another, lesser known but equally stunning physical trait, located at its north pole. Surrounding the pole is a hexagonal shape that is still mostly inexplicable, but some scientists believe it comes from a steep gradient of atmospheric winds that interfere with each other, creating a near perfect hexagon. Each side of the hexagon is longer than the diameter of Earth.
                      Saturn is also a massive planet, with a diameter of 72,370 miles not including its rings, and is situated about 888,200,000 miles from the Sun, almost twice the distance between the Sun and Jupiter.
                      Saturn has 5 fewer moons than Jupiter has, totaling 62. The largest and most famous of which is known as Titan. It is famous for having a thick atmosphere, and for having bodies of liquid at its surface.",
                      JourneyID = journey.Single(j => j.Destination == "Saturn").JourneyID,
                      ImageURL = "https://s-media-cache-ak0.pinimg.com/564x/48/4c/34/484c347c62cbb2d7759adcac763a6994.jpg"
                  },
                  new CelesteHost {
                      Lesson = @"The Sun is the most important object in the solar system. Without it, there would be no order and no life. The Sun is the largest object in the solar system, with a diameter of approximately 865,000 miles, and is an average distance of 93,000,000 miles from Earth. Approximately 1,300,000 Earths can fit inside the Sun.
                      The Sun contains more than 99.8% of the mass of the solar system, and provides the vast majority of energy for life on Earth. It consists of 3/4 hydrogen and about 1/4 helium, and undergoes fusion at its core, which is the primary source of its light and heat. The surface temperature of the Sun is a staggering 9,940 degrees F.
                      It takes a long time for the energy of the Sun to escape from the core, but once it does, it only takes light 8 minutes and 20 seconds to reach Earth.",
                      JourneyID = journey.Single(j => j.Destination == "Sun").JourneyID,
                      ImageURL = "https://s-media-cache-ak0.pinimg.com/564x/48/4c/34/484c347c62cbb2d7759adcac763a6994.jpg"
                  },
                  new CelesteHost {
                      Lesson = @"The Oort Cloud is an oft overlooked aspect of the solar system, perhaps because it is so far away, or perhaps because its existence was theorized not long ago. 
                      The Oort Cloud is a roughly spherical border surrounding the entire solar system that consists of mostly small icy bodies, like comets and asteroids. It is extremely far away from the Sun; it's interior border is approximately 0.8 light years from the Sun, and it's exterior border is approximately 3.2 light years from the Sun. The Oort Cloud is extremely large, and consists of around 2 trillion objects.",
                      JourneyID = journey.Single(j => j.Destination == "The Oort Cloud").JourneyID,
                      ImageURL = "https://s-media-cache-ak0.pinimg.com/564x/48/4c/34/484c347c62cbb2d7759adcac763a6994.jpg"
                  },
                  new CelesteHost {
                      Lesson = @"Alpha Centauri is the closest neighboring star system to our solar system, at a distance of approximately 4.4 light years away. It is actually a tri-star system, consisting of a pair of stars known as Alpha Centauri A and B, as well as a smaller, red dwarf star known as Proxima Centauri. The star system itself can be seen with the naked eye, and forms the brightest point of light in the constellation Centaurus. There are only two stars in the night sky that are brighter than Alpha Centauri.
                      Alpha Centauri A is the same category star is the Sun, and has the same surface temperature.",
                      JourneyID = journey.Single(j => j.Destination == "Alpha Centauri").JourneyID,
                      ImageURL = "https://s-media-cache-ak0.pinimg.com/564x/48/4c/34/484c347c62cbb2d7759adcac763a6994.jpg"
                  },
                  new CelesteHost {
                      Lesson = @"Every object we have discussed so far resides within our galaxy, which we call The Milky Way. Along with our solar system and Alpha Centauri, there are 100,000,000 other stars, each with their own planets, moons, comets, etc.
                      The Milky Way is a spiral galaxy, meaning it has distinct bands of stars, nebulae and other clouds of matter that appear to spiral out from the center, where resides a massive black hole called Saggitarius A. Saggitarius A is 4,200,000 times more massive than the sun, and thus has an incredibly strong gravitational influence on its surroundings.",
                      JourneyID = journey.Single(j => j.Destination == "Milky Way Black Hole").JourneyID,
                      ImageURL = "https://s-media-cache-ak0.pinimg.com/564x/48/4c/34/484c347c62cbb2d7759adcac763a6994.jpg"
                  },
                  new CelesteHost {
                      Lesson = @"Much like the Milky Way contains billions stars and planets, the universe itself contains billions of galaxies. The closest galaxy to our Milky Way is another spiral galaxy known as Andromeda. Andromeda is a mere 2,500,000 light years from Earth. That is a mind boggling distance. Just to reiterate, one light year is about one trillion miles, and the Milky Way galaxy itself is 100,000 light years across.
                      Andromeda is about twice the size of the Milky Way, at around 220,000 light years across. Fun fact, Andromeda and the Milky Way are on a collision course, set to slam into each other in about 4,500,000 years. Oddly enough, however, there is so much space in each respective galaxy, that almost none of the 1 trillion stars in the Andromeda galaxy will directly collide with the 100 billion stars in the Milky Way.",
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