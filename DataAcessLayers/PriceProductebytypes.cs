﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using static C_Utilities.Enumes;

namespace DataAcessLayers
{
    public class  PriceProductebytypes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
         public  Product Product  { get; set; }
        public ICollection<NotPayedmoney> NotPayedmoney { get; set; }

        public int ProductId { get; set; }
        public int CustomerTypeId { get; set; }
        public CustomerType CustomerType { get; set; }
        public int ? Qantity { get; set; }
        public int? Discount { get; set; } // Nullable discount property
        public int ? price { get; set; }
     }

}
