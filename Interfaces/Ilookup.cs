using Cf_Viewmodels;

using Microsoft.AspNetCore.Mvc.Rendering;

using X.PagedList;

namespace Interfaces
{
    public interface Ilookup
    {
        
        public List<SelectListItem> GetCustomerType();
        public IQueryable<SelectListItem> GetCustomerTypesId(int selectedId = 0);



    }

}
