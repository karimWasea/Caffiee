using Cf_Viewmodels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using X.PagedList;

namespace Interfaces
{
    public interface IPriceProductebytypes : IGenericService<PriceProductebytypesVM>
    {
        public IPagedList<PriceProductebytypesVM> SearchForTypes(PriceProductebytypesVM criteria);
        public void AddShopingCaterCashHistory(PriceProductebytypesVM criteria);
        public void UpdateShopingCaterCashHistory(PriceProductebytypesVM criteria);
        public void FreeFinancialUserCash(string? SystemUserId, string? SystemUserName);
        public IEnumerable<PriceProductebytypesVM> GetallfromShopingCart(PriceProductebytypesVM criteria);



    }
}
