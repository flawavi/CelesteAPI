using System;
using System.ComponentModel.DataAnnotations;

namespace Celeste.Models
{
    public class CelesteHost
    {
        [Key]
        public int CelesteHostID {get;set;}
        public string Name {get;set;}
        public string Category {get;set;}
        public string Greeting {get;set;}
        public string Lesson {get;set;}
        public string ImageURL {get;set;}
    }
}