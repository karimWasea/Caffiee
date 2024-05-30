using AutoMapper;
using Cf_Viewmodels;
using DataAcessLayers;
using Interfaces;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Servess
{
    public class PriceProductebytypesServess : PaginationHelper<PriceProductebytypesVM>, IPriceProductebytypesServess
    {
        public readonly ApplicationDBcontext _context;

        private readonly IMapper _mapper;

        public PriceProductebytypesServess(ApplicationDBcontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public bool CheckIfExisit(PriceProductebytypesVM entity)
        {
            return _context.PriceProductebytypes.Any(i => i.Id != entity.Id && i.ProductId== entity.ProductId &&i.CustomerTypeId==entity.CustomerTypeId&&i.price==entity.price);
        }


        public void Save(PriceProductebytypesVM criteria)
        {
            var Entity = _mapper.Map< DataAcessLayers.PriceProductebytypes>(criteria);
            if (criteria.Id > 0)
            {
                _context.Update(Entity);

            }
            {

                _context.Add(Entity);

            }
            _context.SaveChanges();

        }
        public void Delete(int id)
        {
            _context.Remove(_context.PriceProductebytypes.Find(id));
            _context.SaveChanges();

        }

        public PriceProductebytypesVM Get(int id)
        {


            return _mapper.Map<PriceProductebytypesVM>(_context.PriceProductebytypes.Find(id));

            

        }

        public IPagedList<PriceProductebytypesVM> Search(PriceProductebytypesVM criteria)
        {
            var queryable = _context.PriceProductebytypes.Include(i => i.Product).Include(p=>p.CustomerType).Where(
                product =>
                    (criteria.ProductId == null || product.ProductId==criteria.ProductId)
                    && (criteria. CustomerTypeId == null || product.CustomerTypeId== criteria.CustomerTypeId))
                .Select(i => new PriceProductebytypesVM
                {
                    //Id = i.Id,
                    //ProductName = i.ProductName,
                    //Description = i.Description,
                    //Discount = i.Discount,
                    //CategoryId = i.CategoryId,
                    //Price = i.Price,
                    //Qantity = i.Qantity
                    // , CategoryName= i.Category.CategoryName,
                })
                .OrderBy(g => g.Id);

            // Provide a default value for PageNumber if it's null
            int pageNumber = criteria.PageNumber ?? 1;

            var pagedList = GetPagedData(queryable, pageNumber);

            return pagedList;
        }




    }
}
