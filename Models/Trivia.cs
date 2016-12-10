using System;
using System.ComponentModel.DataAnnotations;

namespace Celeste.Models
{
    public class Trivia 
    {
        [Key]
        public int TriviaID {get;set;}
        public int JourneyID {get;set;}
        public Journey Journey {get;set;}
        public string Question {get;set;}
        public string Answer {get;set;}
        public int Point {get;set;} 
    }
}