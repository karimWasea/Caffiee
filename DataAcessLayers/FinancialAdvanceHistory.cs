using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataAcessLayers
{
    public class FinancialAdvanceHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public decimal OldAmount { get; set; }
        public decimal NewAmount { get; set; }
        public DateTime ChangeDate { get; set; }
        public string ChangedByUserId { get; set; }
        public string Description { get; set; }

        public virtual FinancialAdvance FinancialAdvance { get; set; }
    }


}
