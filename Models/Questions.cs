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
        public ICollection<Answers> AnswerList {get;set;}
    }
}