using System;
using System.ComponentModel.DataAnnotations;

namespace Celeste.Models
{
    public class ExplorerResponse
    {
        [Key]
        public int ExplorerResponseID {get;set;}
        public int ExplorerID {get;set;}
        public Explorer Explorer {get;set;}
        public bool Correct {get;set;}
        public DateTime DateCreated {get;set;}
    }
}