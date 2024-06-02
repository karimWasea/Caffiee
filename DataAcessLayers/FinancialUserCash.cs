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
        public decimal? PayedAmount { get; set; }
        public decimal? NotpayedAmount { get; set; }

        public DateTime Date { get; set; }
        public string? SystemUserId { get; set; }
        public string? SystemUserName { get; set; }
        public FinancialAdvanceType FinancialAdvanceType { get; set; }
        public int PriceProductebytypesId { get; set; }
         public ICollection< PriceProductebytypes > PriceProductebytypes { get; set; }
 
    }


}
