using System;
using System.ComponentModel.DataAnnotations;
using Celeste.Models.ViewModels;

namespace Celeste.Models
{
    public class FakeAnswersViewModel
    {
        public int QuestionsID {get;set;}
        public string FakeAnswer {get;set;}
        public QuestionsViewModel Questions {get;set;}
        public FakeAnswersViewModel(){}
        public FakeAnswersViewModel(FakeAnswers fa) 
        {
            FakeAnswer = fa.FakeAnswer;
        }
    }
}