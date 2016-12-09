using System;

namespace Celeste.Models
{
    public class UserResponse
    {
        public int UserResponseID {get;set;}
        public int UserId {get;set;}
        public bool Correct {get;set;}
        public DateTime DateCreated {get;set;}
    }
}