using System;
using System.ComponentModel.DataAnnotations;

namespace Celeste.Models
{
    public class UserResponse
    {
        [Key]
        public int UserResponseID {get;set;}
        public int UserId {get;set;}
        public User User {get;set;}
        public bool Correct {get;set;}
        public DateTime DateCreated {get;set;}
    }
}