namespace DataAcessLayers
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    using static C_Utilities.Enumes;

    public class FinancialUserCash
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public int? Qantity { get; set; }
        public int? price { get; set; }
        public DateTime Date { get; set; }
         public FinancialAdvanceType FinancialAdvanceType { get; set; }
        public int PriceProductebytypesId { get; set; }
         public ICollection< PriceProductebytypes > PriceProductebytypes { get; set; }
 
    }


}
