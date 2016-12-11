using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Celeste.Models
{
    public class ExplorerJourney
    {
        [Key]
        public int ExplorerJourneyID {get;set;}
        public int ExplorerID {get;set;}
        public int JourneyID {get;set;}
        public int Score {get;set;}
        public bool isCompleted {get;set;}
        public Journey Journey {get;set;}
        public Explorer Explorer {get;set;}
        public DateTime DateCreated {get;set;}
    }
}