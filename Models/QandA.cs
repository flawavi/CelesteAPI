using System;

namespace Celeste.Models
{
    public class QandA 
    {
        public int QandAID {get;set;}
        public string Category {get;set;}
        public string Question {get;set;}
        public string Answer {get;set;}
        public int? Point {get;set;} 
    }
}