using System;
using System.ComponentModel.DataAnnotations;
using Celeste.Models.ViewModels;

namespace Celeste.Models
{
    public class TriviaViewModel
    {
        public JourneyViewModel Journey {get;set;}
        public string Question {get;set;}
        public string Answer {get;set;}
        public int Point {get;set;} 
        public TriviaViewModel(){}
        public TriviaViewModel(Trivia t) 
        {
            Question = t.Question;
            Answer = t.Answer;
            Point = t.Point;
        }
    }
}