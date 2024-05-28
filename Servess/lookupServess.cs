using AutoMapper;

using Cf_Viewmodels;

using DataAcessLayers;

using Interfaces;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using System.Linq;

using X.PagedList;

using static C_Utilities.Enumes;

using CustomerType = C_Utilities.Enumes.CustomerType;

namespace Servess
{
    public class lookupServess : Ilookup
    {
        private readonly ApplicationDBcontext _applicationDBcontext;
        private readonly UserManager<Applicaionuser> _user;


        public lookupServess(UserManager<Applicaionuser> userManager, ApplicationDBcontext applicationDBcontext)
        {
            _applicationDBcontext = applicationDBcontext;
            _user = userManager;



        }
          
        public List<SelectListItem> GetCustomerType()
        {
            var weekdays = Enum.GetValues(typeof(CustomerType))
                               .Cast<C_Utilities.Enumes.CustomerType>()
                               .Select(d => new SelectListItem
                               {
                                   Value = ((int)d).ToString(),
                                   Text = d.ToString()
                               })
                               .ToList();

            return weekdays;
        }


        

        public IQueryable<SelectListItem> GetCustomerTypesId(int selectedId=0)
        {

            IQueryable<SelectListItem>? applicationuser = _applicationDBcontext.CustomerTypes.Select(x => new SelectListItem {
                
                Value = x.Id.ToString(), 
                
                Text = x.TypesName ,
                Selected = x.Id == selectedId


            }).OrderBy(c => c.Text).AsNoTracking();
            return applicationuser;
        }
         

     




    }
}
