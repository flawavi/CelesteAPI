using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Celeste.Models
{
    public class User
    {
        [Key]
        public int UserID {get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string UserName {get;set;}
        public int Age {get;set;}
        public string Email {get;set;}
        public DateTime DateCreated {get;set;}
        public ICollection<UserResponse> UserResponses {get;set;}
        public ICollection<Journey> Journies {get;set;}

    }
}