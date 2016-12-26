using System;
using System.ComponentModel.DataAnnotations;
using Celeste.Models.ViewModels;

namespace Celeste.Models
{
    public class AnswersViewModel
    {
        public string Answer {get;set;}
        public int QuestionsID {get;set;}
        public QuestionsViewModel Questions {get;set;}
        public AnswersViewModel(){}
        public AnswersViewModel(Answers a) 
        {
            Answer = a.Answer;
        }
    }
}