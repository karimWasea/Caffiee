using AutoMapper.Configuration.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cf_Viewmodels
{
    public class ProductVm
    {
        public int Id { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public string? ProductName { get; set; }
        public decimal? Price { get; set; }
        public decimal? Qantity { get; set; }
        public int CategoryId { get; set; }
        public string? Description { get; set; }
        public int? Discount { get; set; } // Nullable discount property

        public CategoryVm? Category { get; set; }
    }
}
