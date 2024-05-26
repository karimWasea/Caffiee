using Microsoft.AspNetCore.Identity;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static C_Utilities.Enumes;

namespace DataAcessLayers
{
  
    public class Applicaionuser : IdentityUser 
    {
          public DateTime ?DateOfBirth { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public string? Address { get; set; }
        public string? City { get; set; }
        public string  ?Country { get; set; }
        public string? IdentifierImge { get; set; }
        public string? Job { get; set; }
        public CustomerType CustomerType { get; set; }
        public Gender Gender { get; set; }
         public string  ?IdentifierNumber { get; set; }
        public ICollection<FinancialAdvance> FinancialAdvances { get; set; }
        public ICollection<UserProduct> UserProducts { get; set; }



    };
}
