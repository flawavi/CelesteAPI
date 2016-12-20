using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Celeste.Models
{
    public class ExplorerJourney
    {
        [Key]
        public int ExplorerJourneyID {get;set;}
        [Required]
        public int ExplorerID {get;set;}
        [Required]
        public int JourneyID {get;set;}
        [Required]
        public int Score {get;set;}
        [Required]
        public bool isCompleted {get;set;}
        public Journey Journey {get;set;}
        public Explorer Explorer {get;set;}
        [Required]
        public DateTime DateCreated {get;set;}
    }
}