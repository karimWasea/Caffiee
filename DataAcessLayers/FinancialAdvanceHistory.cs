using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static C_Utilities.Enumes;

namespace DataAcessLayers
{
    public class FinancialAdvanceHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string SystemUserId { get; set; }
        public string SystemUserName { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public decimal? OldAmount { get; set; }
        public decimal? NewAmount { get; set; }
        public DateTime  ChangeDate { get; set; }
        public string ChangedByUserId { get; set; }
         public virtual Applicaionuser ApplicationUser { get; set; }
        public string ?Description { get; set; }
        public int NotPayedmoneyId { get; set; }
        public Status Stutes { get; set; }


        public virtual NotPayedmoney NotPayedmoneys { get; set; }
    }


}
