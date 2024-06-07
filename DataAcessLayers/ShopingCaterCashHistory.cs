namespace DataAcessLayers
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    using static C_Utilities.Enumes;

    public class ShopingCaterCashHistory { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
         public int? Qantity { get; set; }
        public decimal? PayedAmount { get; set; }

 
        
        public int PriceProductebytypesId { get; set; }
        public int productid { get; set; }
        public string productName { get; set; }
        public int  catid { get; set; }
  
    }


}
