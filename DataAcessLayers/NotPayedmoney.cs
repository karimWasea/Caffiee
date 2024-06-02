﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using static C_Utilities.Enumes;

namespace DataAcessLayers
{
    public class NotPayedmoney
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public DateTime SalasDateTime { get; set; }
        public decimal? TotalPayedAmount { get; set; }
        public decimal? TotalNotpayedAmount { get; set; }
        public string ChangedByUserId { get; set; }
        public string NotpayedmoneyId { get; set; }
         public Applicaionuser UserNotPayedmoney { get; set; }
        public string ?SystemUserId { get; set; }
        public string? SystemUserName { get; set; }
        public int PriceProductebytypesid { get; set; }
        public PriceProductebytypes PriceProductebytypes { get; set; }
        
      public ICollection<FinancialAdvanceHistory> FinancialAdvanceHistory { get; set; }

        public PaymentStatus PaymentStatus { get; set; }
        public Status Stutes { get; set; }
      }

}
