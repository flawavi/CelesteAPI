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

                var questions = new Questions[]
                {
                  new Questions {
                      JourneyID = journey.Single(j => j.Destination == "Moon").JourneyID,
                      Question = "What is the radius of the moon?",
                      Point = 0
                  },
                  new Questions {
                      JourneyID = journey.Single(j => j.Destination == "Moon").JourneyID,
                      Question = "What is the average distance between the Moon and the Earth?",
                      Point = 0
                  },
                  new Questions {
                      JourneyID = journey.Single(j => j.Destination == "Moon").JourneyID,
                      Question = "How many of the planets (not including Earth) can fit between the Earth and the Moon?",
                      Point = 0
                  },
                  new Questions {
                      JourneyID = journey.Single(j => j.Destination == "Moon").JourneyID,
                      Question = "About how many Earth days does it take the Moon to rotate on its axis?",
                      Point = 0
                  },
                  new Questions {
                      JourneyID = journey.Single(j => j.Destination == "Moon").JourneyID,
                      Question = "What is the approximate age of the Moon?",
                      Point = 0
                  },
                  new Questions {
                      JourneyID = journey.Single(j => j.Destination == "Mars").JourneyID,
                      Question = "What is the average distance between Mars and the Sun?",
                      Point = 0
                  },
                  new Questions {
                      JourneyID = journey.Single(j => j.Destination == "Mars").JourneyID,
                      Question = "What two elements are primarily responsible for Mars' red hue?",
                      Point = 0
                  },
                  new Questions {
                      JourneyID = journey.Single(j => j.Destination == "Mars").JourneyID,
                      Question = "What is the diameter of Mars?",
                      Point = 0
                  },
                  new Questions {
                      JourneyID = journey.Single(j => j.Destination == "Mars").JourneyID,
                      Question = "What are the names of the Martian moons?",
                      Point = 0
                  },
                  new Questions {
                      JourneyID = journey.Single(j => j.Destination == "Mars").JourneyID,
                      Question = "What is the name of the giant canyon on Mars?",
                      Point = 0
                  },
                  new Questions {
                      JourneyID = journey.Single(j => j.Destination == "Jupiter").JourneyID,
                      Question = "What is the diameter of Jupiter?",
                      Point = 0
                  },
                  new Questions {
                      JourneyID = journey.Single(j => j.Destination == "Jupiter").JourneyID,
                      Question = "How many moons does Jupiter have?",
                      Point = 0
                  },
                  new Questions {
                      JourneyID = journey.Single(j => j.Destination == "Jupiter").JourneyID,
                      Question = "The gas giant Jupiter is composed of 90% ____ and just under 10% ____?",
                      Point = 0
                  },
                  new Questions {
                      JourneyID = journey.Single(j => j.Destination == "Jupiter").JourneyID,
                      Question = "What is the average distance between Jupiter and the Sun?",
                      Point = 0
                  },
                  new Questions {
                      JourneyID = journey.Single(j => j.Destination == "Jupiter").JourneyID,
                      Question = "What is the name of the enormous storm on the surface of Jupiter. ",
                      Point = 0
                  },
                  new Questions {
                      JourneyID = journey.Single(j => j.Destination == "Saturn").JourneyID,
                      Question = "What is the average distance between Saturn and The Sun?",
                      Point = 0
                  },
                  new Questions {
                      JourneyID = journey.Single(j => j.Destination == "Saturn").JourneyID,
                      Question = "What is the approximate diameter of Saturn?",
                      Point = 0
                  },
                  new Questions {
                      JourneyID = journey.Single(j => j.Destination == "Saturn").JourneyID,
                      Question = "What peculiar shape surrounds Saturn's north pole?",
                      Point = 0
                  },
                  new Questions {
                      JourneyID = journey.Single(j => j.Destination == "Saturn").JourneyID,
                      Question = "Approximately how think are the rings of Saturn?",
                      Point = 0
                  },
                  new Questions {
                      JourneyID = journey.Single(j => j.Destination == "Saturn").JourneyID,
                      Question = "What is the name of Saturn's largest moon?",
                      Point = 0
                  },
                  new Questions {
                      JourneyID = journey.Single(j => j.Destination == "Sun").JourneyID,
                      Question = "What is the diameter of the Sun?",
                      Point = 0
                  },
                  new Questions {
                      JourneyID = journey.Single(j => j.Destination == "Sun").JourneyID,
                      Question = "What is the average distance between the Sun and Earth?",
                      Point = 0
                  },
                  new Questions {
                      JourneyID = journey.Single(j => j.Destination == "Sun").JourneyID,
                      Question = "What is the surface temperature of the Sun?",
                      Point = 0
                  },
                  new Questions {
                      JourneyID = journey.Single(j => j.Destination == "Sun").JourneyID,
                      Question = "How long does it take light to reach Earth from the Sun?",
                      Point = 0
                  },
                  new Questions {
                      JourneyID = journey.Single(j => j.Destination == "Sun").JourneyID,
                      Question = "Approximately how many Earths would fit inside the Sun?",
                      Point = 0
                  },
                  new Questions {
                      JourneyID = journey.Single(j => j.Destination == "The Oort Cloud").JourneyID,
                      Question = "The Oort cloud defines the boundary of what?",
                      Point = 0
                  },
                  new Questions {
                      JourneyID = journey.Single(j => j.Destination == "The Oort Cloud").JourneyID,
                      Question = "At its closest point, how far away is the Oort Cloud from the center of the Solar System (Sun)? And its farthest?",
                      Point = 0
                  },
                  new Questions {
                      JourneyID = journey.Single(j => j.Destination == "The Oort Cloud").JourneyID,
                      Question = "The Oort Cloud is responsible for producing what types of objects that fly by Earth periodically?",
                      Point = 0
                  },
                  new Questions {
                      JourneyID = journey.Single(j => j.Destination == "The Oort Cloud").JourneyID,
                      Question = "What is the basic shape of the Oort Cloud?",
                      Point = 0
                  },
                  new Questions {
                      JourneyID = journey.Single(j => j.Destination == "The Oort Cloud").JourneyID,
                      Question = "What is the estimated number of objects existing in the Oort Cloud?",
                      Point = 0
                  },
                  new Questions {
                      JourneyID = journey.Single(j => j.Destination == "Alpha Centauri").JourneyID,
                      Question = "Alpha Centauri is a star system consisting of how many stars?",
                      Point = 0
                  },
                  new Questions {
                      JourneyID = journey.Single(j => j.Destination == "Alpha Centauri").JourneyID,
                      Question = "How far away is Alpha Centauri from us?",
                      Point = 0
                  },
                  new Questions {
                      JourneyID = journey.Single(j => j.Destination == "Alpha Centauri").JourneyID,
                      Question = "Alpha Centauri forms the brightest 'star' in which constellation?",
                      Point = 0
                  },
                  new Questions {
                      JourneyID = journey.Single(j => j.Destination == "Alpha Centauri").JourneyID,
                      Question = "What is the surface temperature of Alpha Centauri?",
                      Point = 0
                  },
                  new Questions {
                      JourneyID = journey.Single(j => j.Destination == "Alpha Centauri").JourneyID,
                      Question = "How many stars are brighter than Alpha Centauri in the night sky?",
                      Point = 0
                  },
                  new Questions {
                      JourneyID = journey.Single(j => j.Destination == "Milky Way Black Hole").JourneyID,
                      Question = "Approximately how wide is the Milky Way?",
                      Point = 0
                  },
                  new Questions {
                      JourneyID = journey.Single(j => j.Destination == "Milky Way Black Hole").JourneyID,
                      Question = "There are at least how many stars in the Milky Way Galaxy?",
                      Point = 0
                  },
                  new Questions {
                      JourneyID = journey.Single(j => j.Destination == "Milky Way Black Hole").JourneyID,
                      Question = "What type of galaxy is the Milky Way?",
                      Point = 0
                  },
                  new Questions {
                      JourneyID = journey.Single(j => j.Destination == "Milky Way Black Hole").JourneyID,
                      Question = "Likely what is Saggitarius A, the object at the center of the Milky Way?",
                      Point = 0
                  },
                  new Questions {
                      JourneyID = journey.Single(j => j.Destination == "Milky Way Black Hole").JourneyID,
                      Question = "How massive is Saggitarius A (in solar masses)?",
                      Point = 0
                  },
                  new Questions {
                      JourneyID = journey.Single(j => j.Destination == "Andromeda").JourneyID,
                      Question = "What is Andromeda?",
                      Point = 0
                  },
                  new Questions {
                      JourneyID = journey.Single(j => j.Destination == "Andromeda").JourneyID,
                      Question = "Approximately how far away is Andromeda from The Milky Way?",
                      Point = 0
                  },
                  new Questions {
                      JourneyID = journey.Single(j => j.Destination == "Andromeda").JourneyID,
                      Question = "Approximately how far across is the Andromeda Galaxy?",
                      Point = 0
                  },
                  new Questions {
                      JourneyID = journey.Single(j => j.Destination == "Andromeda").JourneyID,
                      Question = "The Milky Way and Andromeda Galaxies are expected to collide in how many years?",
                      Point = 0
                  },
                  new Questions {
                      JourneyID = journey.Single(j => j.Destination == "Andromeda").JourneyID,
                      Question = "Approximately how many stars are in the Andromeda Galaxy?",
                      Point = 0
                  }
                };

                foreach (Questions q in questions)
                {
                    context.Questions.Add(q);
                }
                context.SaveChanges();

                var answers = new Answers[]
                {
                  new Answers {
                      QuestionsID = questions.Single(q => q.Question == "What is the radius of the moon?").QuestionsID,
                      Answer = "1,080 miles"
                  },
                  new Answers {
                      QuestionsID = questions.Single(q => q.Question == "What is the average distance between the Moon and the Earth?").QuestionsID,
                      Answer = "240,000 miles"
                  },
                  new Answers {
                      QuestionsID = questions.Single(q => q.Question == "How many of the planets (not including Earth) can fit between the Earth and the Moon?").QuestionsID,
                      Answer = "All of them"
                  },
                  new Answers {
                      QuestionsID = questions.Single(q => q.Question == "About how many Earth days does it take the Moon to rotate on its axis?").QuestionsID,
                      Answer = "27"
                  },
                  new Answers {
                      QuestionsID = questions.Single(q => q.Question == "What is the approximate age of the Moon?").QuestionsID,
                      Answer = "4,500,000,000 years"
                  },
                  new Answers {
                      QuestionsID = questions.Single(q => q.Question == "What is the average distance between Mars and the Sun?").QuestionsID,
                      Answer = "1,420,000 miles"
                  },
                  new Answers {
                      QuestionsID = questions.Single(q => q.Question == "What two elements are primarily responsible for Mars' red hue?").QuestionsID,
                      Answer = "Iron and Oxygen"
                  },
                  new Answers {
                      QuestionsID = questions.Single(q => q.Question == "What is the diameter of Mars?").QuestionsID,
                      Answer = "4,200 miles"
                  },
                  new Answers {
                      QuestionsID = questions.Single(q => q.Question == "What are the names of the Martian moons?").QuestionsID,
                      Answer = "Phobos and Deimos"
                  },
                  new Answers {
                      QuestionsID = questions.Single(q => q.Question == "What is the name of the giant canyon on Mars?").QuestionsID,
                      Answer = "Valles Marineris"
                  },
                  new Answers {
                      QuestionsID = questions.Single(q => q.Question == "What is the diameter of Jupiter?").QuestionsID,
                      Answer = "86,880 miles"
                  },
                  new Answers {
                      QuestionsID = questions.Single(q => q.Question == "How many moons does Jupiter have?").QuestionsID,
                      Answer = "67"
                  },
                  new Answers {
                      QuestionsID = questions.Single(q => q.Question == "The gas giant Jupiter is composed of 90% ____ and just under 10% ____?").QuestionsID,
                      Answer = "Hydrogen Helium"
                  },
                  new Answers {
                      QuestionsID = questions.Single(q => q.Question == "What is the average distance between Jupiter and the Sun?").QuestionsID,
                      Answer = "480,000,000 miles"
                  },
                  new Answers {
                      QuestionsID = questions.Single(q => q.Question == "What is the name of the enormous storm on the surface of Jupiter?").QuestionsID,
                      Answer = "The Great Red Spot"
                  },
                  new Answers {
                      QuestionsID = questions.Single(q => q.Question == "What is the average distance between Saturn and The Sun?").QuestionsID,
                      Answer = "888,200,000 miles"
                  },
                  new Answers {
                      QuestionsID = questions.Single(q => q.Question == "What is the approximate diameter of Saturn?").QuestionsID,
                      Answer = "72,370 miles"
                  },
                  new Answers {
                      QuestionsID = questions.Single(q => q.Question == "What peculiar shape surrounds Saturn's north pole?").QuestionsID,
                      Answer = "Hexagon"
                  },
                  new Answers {
                      QuestionsID = questions.Single(q => q.Question == "Approximately how think are the rings of Saturn?").QuestionsID,
                      Answer = "30 feet"
                  },
                  new Answers {
                      QuestionsID = questions.Single(q => q.Question == "What is the name of Saturn's largest moon?").QuestionsID,
                      Answer = "Titan"
                  },
                  new Answers {
                      QuestionsID = questions.Single(q => q.Question == "What is the diameter of the Sun?").QuestionsID,
                      Answer = "865,000 miles"
                  },
                  new Answers {
                      QuestionsID = questions.Single(q => q.Question == "What is the average distance between the Sun and Earth?").QuestionsID,
                      Answer = "93,000,000 miles"
                  },
                  new Answers {
                      QuestionsID = questions.Single(q => q.Question == "What is the surface temperature of the Sun?").QuestionsID,
                      Answer = "9,940°F"
                  },
                  new Answers {
                      QuestionsID = questions.Single(q => q.Question == "How long does it take light to reach Earth from the Sun?").QuestionsID,
                      Answer = "8 minutes 20 seconds"
                  },
                  new Answers {
                      QuestionsID = questions.Single(q => q.Question == "Approximately how many Earths would fit inside the Sun?").QuestionsID,
                      Answer = "1,300,000"
                  },
                  new Answers {
                      QuestionsID = questions.Single(q => q.Question == "The Oort cloud defines the boundary of what?").QuestionsID,
                      Answer = "The Solar System"
                  },
                  new Answers {
                      QuestionsID = questions.Single(q => q.Question == "At its closest point, how far away is the Oort Cloud from the center of the Solar System (Sun)? And its farthest?").QuestionsID,
                      Answer = "0.8 ly, 3.2 ly"
                  },
                  new Answers {
                      QuestionsID = questions.Single(q => q.Question == "The Oort Cloud is responsible for producing what types of objects that fly by Earth periodically?").QuestionsID,
                      Answer = "Comets"
                  },
                  new Answers {
                      QuestionsID = questions.Single(q => q.Question == "What is the basic shape of the Oort Cloud?").QuestionsID,
                      Answer = "A Sphere"
                  },
                  new Answers {
                      QuestionsID = questions.Single(q => q.Question == "What is the estimated number of objects existing in the Oort Cloud?").QuestionsID,
                      Answer = "2,000,000,000,000"
                  },
                  new Answers {
                      QuestionsID = questions.Single(q => q.Question == "Alpha Centauri is a star system consisting of how many stars?").QuestionsID,
                      Answer = "3"
                  },
                  new Answers {
                      QuestionsID = questions.Single(q => q.Question == "How far away is Alpha Centauri from us?").QuestionsID,
                      Answer = "4.37 ly"
                  },
                  new Answers {
                      QuestionsID = questions.Single(q => q.Question == "Alpha Centauri forms the brightest 'star' in which constellation?").QuestionsID,
                      Answer = "Centaurus"
                  },
                  new Answers {
                      QuestionsID = questions.Single(q => q.Question == "What is the surface temperature of Alpha Centauri?").QuestionsID,
                      Answer = "9,940°F"
                  },
                  new Answers {
                      QuestionsID = questions.Single(q => q.Question == "How many stars are brighter than Alpha Centauri in the night sky?").QuestionsID,
                      Answer = "2"
                  },
                  new Answers {
                      QuestionsID = questions.Single(q => q.Question == "Approximately how wide is the Milky Way?").QuestionsID,
                      Answer = "100,000 ly"
                  },
                  new Answers {
                      QuestionsID = questions.Single(q => q.Question == "There are at least how many stars in the Milky Way Galaxy?").QuestionsID,
                      Answer = "100,000,000,000"
                  },
                  new Answers {
                      QuestionsID = questions.Single(q => q.Question == "What type of galaxy is the Milky Way?").QuestionsID,
                      Answer = "Spiral Galaxy"
                  },
                  new Answers {
                      QuestionsID = questions.Single(q => q.Question == "Likely what is Saggitarius A, the object at the center of the Milky Way?").QuestionsID,
                      Answer = "A supermassive black hole"
                  },
                  new Answers {
                      QuestionsID = questions.Single(q => q.Question == "How massive is Saggitarius A (in solar masses)?").QuestionsID,
                      Answer = "4,200,000 solar masses"
                  },
                  new Answers {
                      QuestionsID = questions.Single(q => q.Question == "What is Andromeda?").QuestionsID,
                      Answer = "A spiral galaxy"
                  },
                  new Answers {
                      QuestionsID = questions.Single(q => q.Question == "Approximately how far away is Andromeda from The Milky Way?").QuestionsID,
                      Answer = "2,500,000 ly"
                  },
                  new Answers {
                      QuestionsID = questions.Single(q => q.Question == "Approximately how far across is the Andromeda Galaxy?").QuestionsID,
                      Answer = "220,000 ly"
                  },
                  new Answers {
                      QuestionsID = questions.Single(q => q.Question == "The Milky Way and Andromeda Galaxies are expected to collide in how many years?").QuestionsID,
                      Answer = "4,500,000 years"
                  },
                  new Answers {
                      QuestionsID = questions.Single(q => q.Question == "Approximately how many stars are in the Andromeda Galaxy?").QuestionsID,
                      Answer = "1,000,000,000,000 stars"
                  }
                };

                  foreach (Answers a in answers)
                  {
                      context.Answers.Add(a);
                  }
                  context.SaveChanges();

                var fakeAnswers = new FakeAnswers[]
                {
                    new FakeAnswers 
                    {
                        FakeAnswer = "2,100 miles",
                        QuestionsID = questions.Single(q => q.Question == "What is the radius of the moon?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "600 miles",
                        QuestionsID = questions.Single(q => q.Question == "What is the radius of the moon?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "5,0200 miles",
                        QuestionsID = questions.Single(q => q.Question == "What is the radius of the moon?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "10,500 miles",
                        QuestionsID = questions.Single(q => q.Question == "What is the radius of the moon?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "1,000,000 miles",
                        QuestionsID = questions.Single(q => q.Question == "What is the average distance between the Moon and the Earth?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "5,000 miles",
                        QuestionsID = questions.Single(q => q.Question == "What is the average distance between the Moon and the Earth?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "750,000 miles",
                        QuestionsID = questions.Single(q => q.Question == "What is the average distance between the Moon and the Earth?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "500 miles",
                        QuestionsID = questions.Single(q => q.Question == "What is the average distance between the Moon and the Earth?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "1,000,000 miles",
                        QuestionsID = questions.Single(q => q.Question == "True or false? All of the other planets could fit neatly between the Earth and Moon.").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "5,000 miles",
                        QuestionsID = questions.Single(q => q.Question == "True or false? All of the other planets could fit neatly between the Earth and Moon.").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "750,000 miles",
                        QuestionsID = questions.Single(q => q.Question == "True or false? All of the other planets could fit neatly between the Earth and Moon.").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "500 miles",
                        QuestionsID = questions.Single(q => q.Question == "True or false? All of the other planets could fit neatly between the Earth and Moon.").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "1 day",
                        QuestionsID = questions.Single(q => q.Question == "About how many Earth days does it take the Moon to rotate on its axis?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "21 days",
                        QuestionsID = questions.Single(q => q.Question == "About how many Earth days does it take the Moon to rotate on its axis?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "36 days",
                        QuestionsID = questions.Single(q => q.Question == "About how many Earth days does it take the Moon to rotate on its axis?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "42 days",
                        QuestionsID = questions.Single(q => q.Question == "About how many Earth days does it take the Moon to rotate on its axis?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "10,000 years",
                        QuestionsID = questions.Single(q => q.Question == "What is the approximate age of the Moon?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "5,000,000 years",
                        QuestionsID = questions.Single(q => q.Question == "What is the approximate age of the Moon?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "1,000,000,000 years",
                        QuestionsID = questions.Single(q => q.Question == "What is the approximate age of the Moon?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "250,000,000 years",
                        QuestionsID = questions.Single(q => q.Question == "What is the approximate age of the Moon?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "2,000,000,000 miles",
                        QuestionsID = questions.Single(q => q.Question == "What is the average distance between Mars and the Sun?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "200,000 miles",
                        QuestionsID = questions.Single(q => q.Question == "What is the average distance between Mars and the Sun?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "5,000,000 miles",
                        QuestionsID = questions.Single(q => q.Question == "What is the average distance between Mars and the Sun?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "750,000 miles",
                        QuestionsID = questions.Single(q => q.Question == "What is the average distance between Mars and the Sun?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "Iron and Nitrogen",
                        QuestionsID = questions.Single(q => q.Question == "What two elements are primarily responsible for Mars' red hue?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "Oxygen and Helium",
                        QuestionsID = questions.Single(q => q.Question == "What two elements are primarily responsible for Mars' red hue?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "Helium and Nitrogen",
                        QuestionsID = questions.Single(q => q.Question == "What two elements are primarily responsible for Mars' red hue?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "Iron and Helium",
                        QuestionsID = questions.Single(q => q.Question == "What two elements are primarily responsible for Mars' red hue?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "800 miles",
                        QuestionsID = questions.Single(q => q.Question == "What is the diameter of Mars?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "25,000 miles",
                        QuestionsID = questions.Single(q => q.Question == "What is the diameter of Mars?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "8,400 miles",
                        QuestionsID = questions.Single(q => q.Question == "What is the diameter of Mars?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "12,300 miles",
                        QuestionsID = questions.Single(q => q.Question == "What is the diameter of Mars?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "Phoebe and Dunbar",
                        QuestionsID = questions.Single(q => q.Question == "What are the names of the Martian moons?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "Phyllis and Delilah",
                        QuestionsID = questions.Single(q => q.Question == "What are the names of the Martian moons?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "Photon and Deus",
                        QuestionsID = questions.Single(q => q.Question == "What are the names of the Martian moons?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "Phoenix and Dynamo",
                        QuestionsID = questions.Single(q => q.Question == "What are the names of the Martian moons?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "Valar Morghulis",
                        QuestionsID = questions.Single(q => q.Question == "What is the name of the giant canyon on Mars?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "Valley of the Mongols",
                        QuestionsID = questions.Single(q => q.Question == "What is the name of the giant canyon on Mars?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "Victus Monumentos",
                        QuestionsID = questions.Single(q => q.Question == "What is the name of the giant canyon on Mars?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "Mount Vastus",
                        QuestionsID = questions.Single(q => q.Question == "What is the name of the giant canyon on Mars?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "100,000 miles",
                        QuestionsID = questions.Single(q => q.Question == "What is the diameter of Jupiter?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "250,000 miles",
                        QuestionsID = questions.Single(q => q.Question == "What is the diameter of Jupiter?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "33,000 miles",
                        QuestionsID = questions.Single(q => q.Question == "What is the diameter of Jupiter?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "52,250 miles",
                        QuestionsID = questions.Single(q => q.Question == "What is the diameter of Jupiter?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "24",
                        QuestionsID = questions.Single(q => q.Question == "How many moons does Jupiter have?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "1",
                        QuestionsID = questions.Single(q => q.Question == "How many moons does Jupiter have?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "9",
                        QuestionsID = questions.Single(q => q.Question == "How many moons does Jupiter have?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "77",
                        QuestionsID = questions.Single(q => q.Question == "How many moons does Jupiter have?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "Helium Hydrogen",
                        QuestionsID = questions.Single(q => q.Question == "The gas giant Jupiter is composed of 90% ____ and just under 10% ____?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "Helium Oxygen",
                        QuestionsID = questions.Single(q => q.Question == "The gas giant Jupiter is composed of 90% ____ and just under 10% ____?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "Oxygen Hydrogen",
                        QuestionsID = questions.Single(q => q.Question == "The gas giant Jupiter is composed of 90% ____ and just under 10% ____?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "Hydrogen Nitrogen",
                        QuestionsID = questions.Single(q => q.Question == "The gas giant Jupiter is composed of 90% ____ and just under 10% ____?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "250,000,000 miles",
                        QuestionsID = questions.Single(q => q.Question == "What is the average distance between Jupiter and the Sun?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "1,000,000,000 miles",
                        QuestionsID = questions.Single(q => q.Question == "What is the average distance between Jupiter and the Sun?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "640,000,000 miles",
                        QuestionsID = questions.Single(q => q.Question == "What is the average distance between Jupiter and the Sun?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "100,000,000 miles",
                        QuestionsID = questions.Single(q => q.Question == "What is the average distance between Jupiter and the Sun?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "The Great Big Storm",
                        QuestionsID = questions.Single(q => q.Question == "What is the name of the enormous storm on the surface of Jupiter?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "The Swirling Storm",
                        QuestionsID = questions.Single(q => q.Question == "What is the name of the enormous storm on the surface of Jupiter?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "The Red Storm",
                        QuestionsID = questions.Single(q => q.Question == "What is the name of the enormous storm on the surface of Jupiter?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "The Spot",
                        QuestionsID = questions.Single(q => q.Question == "What is the name of the enormous storm on the surface of Jupiter?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "666,200,000 miles",
                        QuestionsID = questions.Single(q => q.Question == "What is the average distance between Saturn and The Sun?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "500,000,000 miles",
                        QuestionsID = questions.Single(q => q.Question == "What is the average distance between Saturn and The Sun?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "1,200,000,000 miles",
                        QuestionsID = questions.Single(q => q.Question == "What is the average distance between Saturn and The Sun?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "888,2000,000,000 miles",
                        QuestionsID = questions.Single(q => q.Question == "What is the average distance between Saturn and The Sun?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "27,370 miles",
                        QuestionsID = questions.Single(q => q.Question == "What is the approximate diameter of Saturn?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "37,720 miles",
                        QuestionsID = questions.Single(q => q.Question == "What is the approximate diameter of Saturn?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "98,000 miles",
                        QuestionsID = questions.Single(q => q.Question == "What is the approximate diameter of Saturn?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "86,870 miles",
                        QuestionsID = questions.Single(q => q.Question == "What is the approximate diameter of Saturn?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "Circle",
                        QuestionsID = questions.Single(q => q.Question == "What peculiar shape surrounds Saturn's north pole?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "Octagon",
                        QuestionsID = questions.Single(q => q.Question == "What peculiar shape surrounds Saturn's north pole?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "Triangle",
                        QuestionsID = questions.Single(q => q.Question == "What peculiar shape surrounds Saturn's north pole?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "Sphere",
                        QuestionsID = questions.Single(q => q.Question == "What peculiar shape surrounds Saturn's north pole?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "1000 feet",
                        QuestionsID = questions.Single(q => q.Question == "Approximately how think are the rings of Saturn?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "500 feet",
                        QuestionsID = questions.Single(q => q.Question == "Approximately how think are the rings of Saturn?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "3 foot",
                        QuestionsID = questions.Single(q => q.Question == "Approximately how think are the rings of Saturn?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "10 feet",
                        QuestionsID = questions.Single(q => q.Question == "Approximately how think are the rings of Saturn?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "Giant",
                        QuestionsID = questions.Single(q => q.Question == "What is the name of Saturn's largest moon?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "Titus",
                        QuestionsID = questions.Single(q => q.Question == "What is the name of Saturn's largest moon?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "Triton",
                        QuestionsID = questions.Single(q => q.Question == "What is the name of Saturn's largest moon?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "Thor",
                        QuestionsID = questions.Single(q => q.Question == "What is the name of Saturn's largest moon?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "585,000 miles",
                        QuestionsID = questions.Single(q => q.Question == "What is the diameter of the Sun?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "385,800 miles",
                        QuestionsID = questions.Single(q => q.Question == "What is the diameter of the Sun?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "8,650,000 miles",
                        QuestionsID = questions.Single(q => q.Question == "What is the diameter of the Sun?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "3,858,000 miles",
                        QuestionsID = questions.Single(q => q.Question == "What is the diameter of the Sun?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "50,000,000 miles",
                        QuestionsID = questions.Single(q => q.Question == "What is the average distance between the Sun and Earth?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "93,000 miles",
                        QuestionsID = questions.Single(q => q.Question == "What is the average distance between the Sun and Earth?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "10,000,000 miles",
                        QuestionsID = questions.Single(q => q.Question == "What is the average distance between the Sun and Earth?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "356,000,000 miles",
                        QuestionsID = questions.Single(q => q.Question == "What is the average distance between the Sun and Earth?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "20,000°F",
                        QuestionsID = questions.Single(q => q.Question == "What is the surface temperature of the Sun?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "1,000,000°F",
                        QuestionsID = questions.Single(q => q.Question == "What is the surface temperature of the Sun?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "93,000°F",
                        QuestionsID = questions.Single(q => q.Question == "What is the surface temperature of the Sun?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "200,000°F",
                        QuestionsID = questions.Single(q => q.Question == "What is the surface temperature of the Sun?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "Instantaneous",
                        QuestionsID = questions.Single(q => q.Question == "How long does it take light to reach Earth from the Sun?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "1 minute 20 seconds",
                        QuestionsID = questions.Single(q => q.Question == "How long does it take light to reach Earth from the Sun?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "10 minutes 35 seconds",
                        QuestionsID = questions.Single(q => q.Question == "How long does it take light to reach Earth from the Sun?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "22 minutes 43 seconds",
                        QuestionsID = questions.Single(q => q.Question == "How long does it take light to reach Earth from the Sun?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "1,300",
                        QuestionsID = questions.Single(q => q.Question == "Approximately how many Earths would fit inside the Sun?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "2,000,000",
                        QuestionsID = questions.Single(q => q.Question == "Approximately how many Earths would fit inside the Sun?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "300",
                        QuestionsID = questions.Single(q => q.Question == "Approximately how many Earths would fit inside the Sun?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "130,000",
                        QuestionsID = questions.Single(q => q.Question == "Approximately how many Earths would fit inside the Sun?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "The Sun",
                        QuestionsID = questions.Single(q => q.Question == "The Oort cloud defines the boundary of what?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "The universe",
                        QuestionsID = questions.Single(q => q.Question == "The Oort cloud defines the boundary of what?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "The Asteroid Belt",
                        QuestionsID = questions.Single(q => q.Question == "The Oort cloud defines the boundary of what?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "The Milky Way",
                        QuestionsID = questions.Single(q => q.Question == "The Oort cloud defines the boundary of what?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "2 ly, 5 ly",
                        QuestionsID = questions.Single(q => q.Question == "At its closest point, how far away is the Oort Cloud from the center of the Solar System (Sun)? And its farthest?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "0.5 ly, 1.6 ly",
                        QuestionsID = questions.Single(q => q.Question == "At its closest point, how far away is the Oort Cloud from the center of the Solar System (Sun)? And its farthest?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "1 ly, 2 ly",
                        QuestionsID = questions.Single(q => q.Question == "At its closest point, how far away is the Oort Cloud from the center of the Solar System (Sun)? And its farthest?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "0.1 ly, 2.3 ly",
                        QuestionsID = questions.Single(q => q.Question == "At its closest point, how far away is the Oort Cloud from the center of the Solar System (Sun)? And its farthest?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "Planets",
                        QuestionsID = questions.Single(q => q.Question == "The Oort Cloud is responsible for producing what types of objects that fly by Earth periodically?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "Particles",
                        QuestionsID = questions.Single(q => q.Question == "The Oort Cloud is responsible for producing what types of objects that fly by Earth periodically?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "Galaxies",
                        QuestionsID = questions.Single(q => q.Question == "The Oort Cloud is responsible for producing what types of objects that fly by Earth periodically?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "Moons",
                        QuestionsID = questions.Single(q => q.Question == "The Oort Cloud is responsible for producing what types of objects that fly by Earth periodically?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "A Taurus",
                        QuestionsID = questions.Single(q => q.Question == "What is the basic shape of the Oort Cloud?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "A Circle",
                        QuestionsID = questions.Single(q => q.Question == "What is the basic shape of the Oort Cloud?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "A Ring",
                        QuestionsID = questions.Single(q => q.Question == "What is the basic shape of the Oort Cloud?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "A Box",
                        QuestionsID = questions.Single(q => q.Question == "What is the basic shape of the Oort Cloud?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "2,000,000,000",
                        QuestionsID = questions.Single(q => q.Question == "What is the estimated number of objects existing in the Oort Cloud?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "1,500,000",
                        QuestionsID = questions.Single(q => q.Question == "What is the estimated number of objects existing in the Oort Cloud?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "9,900,000",
                        QuestionsID = questions.Single(q => q.Question == "What is the estimated number of objects existing in the Oort Cloud?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "1,000,000,000,000",
                        QuestionsID = questions.Single(q => q.Question == "What is the estimated number of objects existing in the Oort Cloud?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "2",
                        QuestionsID = questions.Single(q => q.Question == "Alpha Centauri is a star system consisting of how many stars?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "6",
                        QuestionsID = questions.Single(q => q.Question == "Alpha Centauri is a star system consisting of how many stars?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "5",
                        QuestionsID = questions.Single(q => q.Question == "Alpha Centauri is a star system consisting of how many stars?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "9",
                        QuestionsID = questions.Single(q => q.Question == "Alpha Centauri is a star system consisting of how many stars?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "2.45 ly",
                        QuestionsID = questions.Single(q => q.Question == "How far away is Alpha Centauri from us?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "1.86 ly",
                        QuestionsID = questions.Single(q => q.Question == "How far away is Alpha Centauri from us?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "14.27 ly",
                        QuestionsID = questions.Single(q => q.Question == "How far away is Alpha Centauri from us?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "8.5 ly",
                        QuestionsID = questions.Single(q => q.Question == "How far away is Alpha Centauri from us?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "Century",
                        QuestionsID = questions.Single(q => q.Question == "Alpha Centauri forms the brightest 'star' in which constellation?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "Centennial",
                        QuestionsID = questions.Single(q => q.Question == "Alpha Centauri forms the brightest 'star' in which constellation?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "Centepede",
                        QuestionsID = questions.Single(q => q.Question == "Alpha Centauri forms the brightest 'star' in which constellation?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "Centellephus",
                        QuestionsID = questions.Single(q => q.Question == "Alpha Centauri forms the brightest 'star' in which constellation?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "52,700°F",
                        QuestionsID = questions.Single(q => q.Question == "What is the surface temperature of Alpha Centauri?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "12,060°F",
                        QuestionsID = questions.Single(q => q.Question == "What is the surface temperature of Alpha Centauri?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "105,000°F",
                        QuestionsID = questions.Single(q => q.Question == "What is the surface temperature of Alpha Centauri?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "7,560°F",
                        QuestionsID = questions.Single(q => q.Question == "What is the surface temperature of Alpha Centauri?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "12",
                        QuestionsID = questions.Single(q => q.Question == "How many stars are brighter than Alpha Centauri in the night sky?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "5",
                        QuestionsID = questions.Single(q => q.Question == "How many stars are brighter than Alpha Centauri in the night sky?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "1,020",
                        QuestionsID = questions.Single(q => q.Question == "How many stars are brighter than Alpha Centauri in the night sky?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "256",
                        QuestionsID = questions.Single(q => q.Question == "How many stars are brighter than Alpha Centauri in the night sky?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "100,000 miles",
                        QuestionsID = questions.Single(q => q.Question == "Approximately how wide is the Milky Way?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "10,000 ly",
                        QuestionsID = questions.Single(q => q.Question == "Approximately how wide is the Milky Way?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "1,000,000 miles",
                        QuestionsID = questions.Single(q => q.Question == "Approximately how wide is the Milky Way?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "1,000,000,000 ly",
                        QuestionsID = questions.Single(q => q.Question == "Approximately how wide is the Milky Way?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "100,000",
                        QuestionsID = questions.Single(q => q.Question == "There are at least how many stars in the Milky Way Galaxy?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "85,000",
                        QuestionsID = questions.Single(q => q.Question == "There are at least how many stars in the Milky Way Galaxy?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "750,000",
                        QuestionsID = questions.Single(q => q.Question == "There are at least how many stars in the Milky Way Galaxy?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "800,000,000",
                        QuestionsID = questions.Single(q => q.Question == "There are at least how many stars in the Milky Way Galaxy?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "Elliptical Galaxy",
                        QuestionsID = questions.Single(q => q.Question == "What type of galaxy is the Milky Way?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "Irregular Galaxy",
                        QuestionsID = questions.Single(q => q.Question == "What type of galaxy is the Milky Way?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "Regular Galaxy",
                        QuestionsID = questions.Single(q => q.Question == "What type of galaxy is the Milky Way?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "Circular Galaxy",
                        QuestionsID = questions.Single(q => q.Question == "What type of galaxy is the Milky Way?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "A supermassive quasar",
                        QuestionsID = questions.Single(q => q.Question == "Likely what is Saggitarius A, the object at the center of the Milky Way?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "A really big planet",
                        QuestionsID = questions.Single(q => q.Question == "Likely what is Saggitarius A, the object at the center of the Milky Way?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "A gigantic star",
                        QuestionsID = questions.Single(q => q.Question == "Likely what is Saggitarius A, the object at the center of the Milky Way?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "A supernova",
                        QuestionsID = questions.Single(q => q.Question == "Likely what is Saggitarius A, the object at the center of the Milky Way?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "100 solar masses",
                        QuestionsID = questions.Single(q => q.Question == "How massive is Saggitarius A (in solar masses)?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "2,500 solar masses",
                        QuestionsID = questions.Single(q => q.Question == "How massive is Saggitarius A (in solar masses)?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "125,000 solar masses",
                        QuestionsID = questions.Single(q => q.Question == "How massive is Saggitarius A (in solar masses)?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "2,000,000 masses",
                        QuestionsID = questions.Single(q => q.Question == "How massive is Saggitarius A (in solar masses)?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "A black hole",
                        QuestionsID = questions.Single(q => q.Question == "What is Andromeda?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "A star",
                        QuestionsID = questions.Single(q => q.Question == "What is Andromeda?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "An elliptical galaxy",
                        QuestionsID = questions.Single(q => q.Question == "What is Andromeda?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "A comet",
                        QuestionsID = questions.Single(q => q.Question == "What is Andromeda?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "50 ly",
                        QuestionsID = questions.Single(q => q.Question == "Approximately how far away is Andromeda from The Milky Way?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "1,000 ly",
                        QuestionsID = questions.Single(q => q.Question == "Approximately how far away is Andromeda from The Milky Way?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "650,000,000 ly",
                        QuestionsID = questions.Single(q => q.Question == "Approximately how far away is Andromeda from The Milky Way?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "57,850,000 ly",
                        QuestionsID = questions.Single(q => q.Question == "Approximately how far away is Andromeda from The Milky Way?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "1,000,000,000,000 miles",
                        QuestionsID = questions.Single(q => q.Question == "Approximately how far across is the Andromeda Galaxy?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "10,000 ly",
                        QuestionsID = questions.Single(q => q.Question == "Approximately how far across is the Andromeda Galaxy?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "22,000 ly",
                        QuestionsID = questions.Single(q => q.Question == "Approximately how far across is the Andromeda Galaxy?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "220,000 miles",
                        QuestionsID = questions.Single(q => q.Question == "Approximately how far across is the Andromeda Galaxy?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "4,000,000 years",
                        QuestionsID = questions.Single(q => q.Question == "The Milky Way and Andromeda Galaxies are expected to collide in how many years?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "10,000,000 years",
                        QuestionsID = questions.Single(q => q.Question == "The Milky Way and Andromeda Galaxies are expected to collide in how many years?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "44,000,000,000 years",
                        QuestionsID = questions.Single(q => q.Question == "The Milky Way and Andromeda Galaxies are expected to collide in how many years?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "420,000 years",
                        QuestionsID = questions.Single(q => q.Question == "The Milky Way and Andromeda Galaxies are expected to collide in how many years?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "4,000,000 stars",
                        QuestionsID = questions.Single(q => q.Question == "Approximately how many stars are in the Andromeda Galaxy?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "999,999,999,999,999,999 stars",
                        QuestionsID = questions.Single(q => q.Question == "Approximately how many stars are in the Andromeda Galaxy?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "88,500,070,000 stars",
                        QuestionsID = questions.Single(q => q.Question == "Approximately how many stars are in the Andromeda Galaxy?").QuestionsID
                    },
                    new FakeAnswers 
                    {
                        FakeAnswer = "530,000 stars",
                        QuestionsID = questions.Single(q => q.Question == "Approximately how many stars are in the Andromeda Galaxy?").QuestionsID
                    },
                };

                foreach (FakeAnswers fa in fakeAnswers)
                  {
                      context.FakeAnswers.Add(fa);
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