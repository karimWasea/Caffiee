using AutoMapper.Configuration.Annotations;

using Microsoft.AspNetCore.Mvc.Rendering;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static C_Utilities.Enumes;

namespace Cf_Viewmodels
{
    public class PriceProductebytypesVM : BaseVM
    {
        public IEnumerable<SelectListItem>? CustomerTypeIdList { get; set; } = Enumerable.Empty<SelectListItem>();
        public CustomerType CustomerType { get; set; }
         public string CustomerTypeName { get; set; } // Call extension method on the instance
        //public string CustomerTypeName => CustomerType.GetDescription();  // Call extension method on the instance

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImg{ get; set; } =string.Empty  ;
        public CategoryType Catid { get; set; }  
        public decimal? ProductOldPrice { get; set; }
          public int? Qantity { get; set; }
        public int? Discount { get; set; } // Nullable discount property
        public int? price { get; set; }



    }
}
