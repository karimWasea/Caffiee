using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using static C_Utilities.Enumes;

namespace DataAcessLayers
{
    public class CustomerType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public DateTime SalasDateTime { get; set; }  
        public string Types { get; set; }  
        public string  ApplicaionuserId { get; set; }
        public Applicaionuser ApplicationUser { get; set; }

    
     }

}
