﻿using Microsoft.AspNetCore.Identity;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static C_Utilities.Enumes;

namespace DataAcessLayers
{
  
    public class Applicaionuser : IdentityUser 
    {
         public DateTime CreationTime { get; set; } = DateTime.Now;
      
        public CustomerType CustomerType { get; set; }
        public int  CustomerTypeId { get; set; }
        public Gender Gender { get; set; }
        public ICollection<NotPayedmoney> NotPayedmoney { get; set; }

        //public ICollection<UserProduct> UserProducts { get; set; }



    };
}
