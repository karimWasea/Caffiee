using Cf_Viewmodels;

using Microsoft.AspNetCore.Mvc.Rendering;

using X.PagedList;

namespace Interfaces
{
    public interface Ilookup
    {
        
          List<SelectListItem> GetCustomerType();
          List<SelectListItem> GetCategoryType();
        //public IQueryable<SelectListItem> GetCustomerTypesId(int selectedId = 0);
 



    }

}
