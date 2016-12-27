using System;
using System.ComponentModel.DataAnnotations;
using Celeste.Models.ViewModels;

namespace Celeste.Models.ViewModels
{
    public class QuestionsViewModel
    {
        public int QuestionsID {get;set;}
        public string Question {get;set;}
        public int JourneyID {get;set;}
        public JourneyViewModel Journey {get;set;}
        public QuestionsViewModel(){}
        public QuestionsViewModel(Questions q) 
        {
            Question = q.Question;
            QuestionsID = q.QuestionsID;
            JourneyID = q.JourneyID;
        }
    }
}