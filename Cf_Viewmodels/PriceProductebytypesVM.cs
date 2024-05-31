using AutoMapper.Configuration.Annotations;

using Microsoft.AspNetCore.Mvc.Rendering;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cf_Viewmodels
{
    public class PriceProductebytypesVM : BaseVM
    {
        public IEnumerable<SelectListItem>? CustomerTypeIdList { get; set; } = Enumerable.Empty<SelectListItem>();

        public int ProductId { get; set; }
        public int CustomerTypeId { get; set; }
        public int? Qantity { get; set; }
        public int? Discount { get; set; } // Nullable discount property
        public int? price { get; set; }



    }
}
