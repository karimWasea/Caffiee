using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using static C_Utilities.Enumes;

namespace DataAcessLayers
{
    public class UserProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public DateTime SalasDateTime { get; set; }  
        public string  ? ApplicaionuserId { get; set; }
        public Applicaionuser ApplicationUser { get; set; }

        public int SalseProductUserId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public int ?QantityBuy { get; set; }
        public SalseProductUserTyps SalseProductUserTyps { get; set; } 
    }

}
