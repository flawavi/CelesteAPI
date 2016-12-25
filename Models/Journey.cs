using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Celeste.Models
{
    public class Journey
    {
        [Key]
        public int JourneyID {get;set;}
        public string Name {get;set;}
        public string Destination {get;set;}
        public ICollection<Questions> QuestionList {get;set;}
    }
}