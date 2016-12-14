using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Celeste.Models
{
    public class Explorer
    {
        [Key]
        public int ExplorerID {get;set;}
        [Required]
        public string FirstName {get;set;}
        [Required]
        public string LastName {get;set;}
        [Required]
        public string Username {get;set;}
        [Required]
        public int Age {get;set;}
        public DateTime DateCreated {get;set;}
        public ICollection<ExplorerResponse> ExplorerResponses {get;set;}
        public ICollection<Journey> Journies {get;set;}

    }
}