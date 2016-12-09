using System;

namespace Celeste.Models
{
    public class UserJourney
    {
        public int UserJourneyID {get;set;}
        public int UserID {get;set;}
        public int Point {get;set;}
        public bool isCompleted {get;set;}
        public DateTime DateCreated {get;set;}
    }
}