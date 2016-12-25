using System;
using System.ComponentModel.DataAnnotations;

namespace Celeste.Models
{
    public class Answers 
    {
        [Key]
        public int AnswersID {get;set;}
        public int QuestionsID {get;set;}
        public string Answer {get;set;}
    }
}