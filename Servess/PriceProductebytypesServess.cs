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

using static C_Utilities.Enumes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Servess
{
    public class PriceProductebytypesServess : PaginationHelper<PriceProductebytypesVM>, IPriceProductebytypes
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
            return _context.PriceProductebytypes.Any(i => i.Id != entity.Id && i.ProductId == entity.ProductId 
            
            && i.CustomerType == entity.CustomerType && i.price == entity.price);
        }

        public void Save(PriceProductebytypesVM criteria)
        {
            var Entity = _mapper.Map<DataAcessLayers.PriceProductebytypes>(criteria);
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
            var queryable = _context.PriceProductebytypes.Include(i => i.Product).Where(
                product =>
                    (  criteria.ProductId == 0 || product.ProductId == criteria.ProductId)
                    && (  criteria.CustomerType == 0 || product.CustomerType == criteria.CustomerType))
                .Select(i => new PriceProductebytypesVM
                {
                    ProductName=i.Product.ProductName,
                     CustomerType = i.CustomerType,
                       ProductId = i.ProductId,
                       Id = i.Id,
                          Discount = i.Discount,
 Qantity = i.Qantity,
  price = i.price
 
                })
                .OrderBy(g => g.Id);

            // Provide a default value for PageNumber if it's null
            int pageNumber = criteria.PageNumber ?? 1;

            var pagedList = GetPagedData(queryable, pageNumber);

            return pagedList;
        }

        public IPagedList<PriceProductebytypesVM> SearchForTypes(PriceProductebytypesVM searchCriteria)
        {
            var query = _context.PriceProductebytypes
                .Include(i => i.Product)
                    .ThenInclude(p => p.Category)
                .Include(i => i.Product)
                    .ThenInclude(i => i.ProductAttachment)
                .Where(product =>
                    (searchCriteria.CustomerType == 0 || product.CustomerType == searchCriteria.CustomerType) &&
                    (searchCriteria.Catid == 0 || product.Product.Category.Id == searchCriteria.Catid) &&
                    (searchCriteria.ProductName == null || product.Product.ProductName.Contains(searchCriteria.ProductName)))
                .Select(i => new PriceProductebytypesVM
                {
                    ProductName = i.Product.ProductName,
                    CustomerType = i.CustomerType,
                    ProductId = i.ProductId,
                    Id = i.Id,
                    Discount = i.Discount,
                    Qantity = i.Qantity,
                    price = i.price,
                    Catid = i.Product.Category.Id,
                    ProductImg = i.Product.ProductAttachment
                                    .OrderByDescending(att => att.Id)
                                    .FirstOrDefault().FilePath ?? "default_image_path"
                })
                .OrderBy(g => g.Id);

            int pageNumber = searchCriteria.PageNumber ?? 1;
            var data = GetPagedData(query, pageNumber);
            return data;
        }



    }
}
