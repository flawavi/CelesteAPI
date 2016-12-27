using System;
using System.ComponentModel.DataAnnotations;

namespace Celeste.Models
{
    public class Answers 
    {
        [Key]
        public int AnswersID {get;set;}
        public int QuestionsID {get;set;}
        public Questions Questions {get;set;}
        public int JourneyID {get;set;}
        public bool Real {get;set;}
        public string Answer {get;set;}
    }
}