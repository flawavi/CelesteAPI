using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Celeste.Models
{
    public class Questions 
    {
        [Key]
        public int QuestionsID {get;set;}
        public int JourneyID {get;set;}
        public Journey Journey {get;set;}
        public string Question {get;set;}
        public int Point {get;set;} 
        public ICollection<Answers> AnswerList {get;set;}
        public ICollection<FakeAnswers> FakeAnswerList {get;set;}
    }
}