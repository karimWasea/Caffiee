using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataAcessLayers
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public decimal? Qantity { get; set; }
        public int  CategoryId { get; set; }
        public string? Description { get; set; }

        public Category Category { get; set; }
        public ICollection<UserProduct> UserProducts { get; set; }
    }

}
