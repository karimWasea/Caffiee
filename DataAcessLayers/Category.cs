﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataAcessLayers
{
    public class Category

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public string ? CategoryName { get; set; }
        public string? Description { get; set; }

        public ICollection<Product> Products { get; set; }
    }

}
