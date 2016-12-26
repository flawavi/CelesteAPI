using System;
using System.ComponentModel.DataAnnotations;

namespace Celeste.Models
{
    public class FakeAnswers 
    {
        [Key]
        public int FakeAnswersID {get;set;}
        public int QuestionsID {get;set;}
        public Questions Questions {get;set;}
        public string FakeAnswer {get;set;}
    }
}