using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Celeste.Models
{
    public class Journey
    {
        [Key]
        public int JourneyID {get;set;}
        public int UserID {get;set;}
        public User User {get;set;}
        public string Name {get;set;}
        public string Destination {get;set;}
        public ICollection<Trivia> TriviaList {get;set;}
    }
}