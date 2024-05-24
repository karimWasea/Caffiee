namespace DataAcessLayers
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    using static C_Utilities.Enumes;

    public class FinancialAdvance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public string ApplicaionuserId { get; set; }
        public Applicaionuser ApplicationUser { get; set; }
        public FinancialAdvanceType FinancialAdvanceType { get; set; }
        // Other relevant properties

        // Navigation property for history entries
        public virtual ICollection<FinancialAdvanceHistory> History { get; set; }
    }


}
