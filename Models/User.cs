using System;

namespace Celeste.Models
{
    public class User
    {
        public int UserID {get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string UserName {get;set;}
        public int Age {get;set;}
        public string Email {get;set;}
        public DateTime DateCreated {get;set;}
    }
}