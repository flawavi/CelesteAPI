using System;
using System.ComponentModel.DataAnnotations;

namespace Celeste.Models
{
    public class UserJourney
    {
        [Key]
        public int UserJourneyID {get;set;}
        public int UserID {get;set;}
        public int Point {get;set;}
        public bool isCompleted {get;set;}
        public DateTime DateCreated {get;set;}
    }
}