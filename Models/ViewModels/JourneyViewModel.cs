using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Celeste.Models.ViewModels
{
    public class JourneyViewModel
    {
        public int JourneyID {get;set;}
        public string Name {get;set;}
        public string Destination {get;set;}
        public JourneyViewModel() {}
        public JourneyViewModel(Journey j) 
        {
            JourneyID = j.JourneyID;
            Name = j.Name;
            Destination = j.Destination;
        }

    }
}