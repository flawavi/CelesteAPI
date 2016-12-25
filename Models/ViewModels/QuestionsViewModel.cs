using System;
using System.ComponentModel.DataAnnotations;
using Celeste.Models.ViewModels;

namespace Celeste.Models
{
    public class QuestionsViewModel
    {
        public JourneyViewModel Journey {get;set;}
        public string Question {get;set;}
        public string Answer {get;set;}
        public int Point {get;set;} 
        public QuestionsViewModel(){}
        public QuestionsViewModel(Questions t) 
        {
            Question = t.Question;
            // Answer = t.Answer;
            Point = t.Point;
        }
    }
}