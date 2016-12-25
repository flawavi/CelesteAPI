using System;
using System.ComponentModel.DataAnnotations;

namespace Celeste.Models
{
    public class FakeAnswers 
    {
        [Key]
        public string FakeAnswersID {get;set;}
        public int QuestionsID {get;set;}
        public string FakeAnswer {get;set;}
    }
}