using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Celeste.Models
{
    public class Explorer
    {
        [Key]
        public int ExplorerID {get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string Username {get;set;}
        public int Age {get;set;}
        public string Email {get;set;}
        public DateTime DateCreated {get;set;}
        public ICollection<ExplorerResponse> ExplorerResponses {get;set;}
        public ICollection<Journey> Journies {get;set;}

    }
}