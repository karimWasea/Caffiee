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
    public class ProductService : PaginationHelper<productVM>, IProduct
    {
        public readonly ApplicationDBcontext _context;

        private readonly IMapper _mapper;

        public ProductService(ApplicationDBcontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public bool CheckIfExisit(productVM entity)
        {
            return _context.products.Any(i => i.Id != entity.Id && i.ProductName == entity.ProductName &&i.CategoryId==entity.CategoryId&&i.Price==entity.Price);
        }


        public void Save(productVM criteria)
        {
            var Entity = _mapper.Map< DataAcessLayers.Product  >(criteria);
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
            _context.Remove(_context.products.Find(id));
            _context.SaveChanges();

        }

        public productVM Get(int id)
        {


            return _mapper.Map<productVM>(_context.products.Find(id));

            

        }

        public IPagedList<productVM> Search(productVM criteria)
        {
            var queryable = _context.products.Include(i => i.Category).Where(
                product =>
                    (criteria.ProductName == null || product.ProductName.Contains(criteria.ProductName))
                    && (criteria.Description == null || product.Description.Contains(criteria.Description)))
                .Select(i => new productVM
                {
                    Id = i.Id,
                    ProductName = i.ProductName,
                    Description = i.Description,
                    Discount = i.Discount,
                    CategoryId = i.CategoryId,
                    Price = i.Price,
                    Qantity = i.Qantity
                     , CategoryName= i.Category.CategoryName,
                })
                .OrderBy(g => g.Id);

            // Provide a default value for PageNumber if it's null
            int pageNumber = criteria.PageNumber ?? 1;

            var pagedList = GetPagedData(queryable, pageNumber);

            return pagedList;
        }




    }
}
