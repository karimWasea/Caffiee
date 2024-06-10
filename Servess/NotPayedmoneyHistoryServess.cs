using AutoMapper;
using C_Utilities;

using Cf_Viewmodels;
using DataAcessLayers;
using Interfaces;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Servess
{
    public class NotPayedmoneyHistoryServess : PaginationHelper<NotPayedmoneyHistoryVM>, INotPayedmoneyHistoryServess
    {
        public readonly ApplicationDBcontext _context; 
        Imgoperation _Imgoperation;

        private readonly IMapper _mapper;

        public NotPayedmoneyHistoryServess(ApplicationDBcontext context, IMapper mapper    ,     Imgoperation imgoperation
)
        {
            _Imgoperation = imgoperation;
            _context = context;
            _mapper = mapper;

        }

        public bool CheckIfExisit(productVM entity)
        {
            return _context.products.Any(i => i.Id != entity.Id && i.ProductName == entity.ProductName &&i.Price==entity.Price);
        }

        public void SaveNotPayedmoney(NotPayedmoneyHistoryVM criteria)
        {
            throw new NotImplementedException();
        }

        public void DeleteNotPayedmoney(int id)
        {
            throw new NotImplementedException();
        }

        public IPagedList<NotPayedmoneyHistoryVM> SearchNotPayedmoney(NotPayedmoneyHistoryVM criteria)
        {
            throw new NotImplementedException();
        }

        public void SaveNotPayedmoneyHistoryDetails(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteNotPayedmoneyHistory(int id)
        {
            throw new NotImplementedException();
        }

        public IPagedList<NotPayedmoneyHistoryVM> SearchNotPayedmoneyHistory(NotPayedmoneyHistoryVM criteria)
        {
            throw new NotImplementedException();
        }




        //public IPagedList<productVM> Search(productVM criteria)
        //{
        //    var queryable = _context.products.Where(
        //        product =>
        //            (criteria.ProductName == null || product.ProductName.Contains(criteria.ProductName))
        //            && (criteria.Description == null || product.Description.Contains(criteria.Description)))
        //        .Select(i => new productVM
        //        {
        //            Id = i.Id,
        //            ProductName = i.ProductName,
        //            Description = i.Description,
        //            Discount = i.Discount,
        //            CategoryTyPe = (Enumes.CategoryType)i.CategoryTyPe,
        //            Price = i.Price,
        //            Qantity = i.Qantity,
        //             //, CategoryName= i.Category.CategoryName,
        //             CoverString= _context.ProductAttachments.Where(p=>p.ProductId==i.Id).OrderByDescending(i=>i.ProductId).FirstOrDefault().FilePath,
        //        })
        //        .OrderBy(g => g.Id);

        //    // Provide a default value for PageNumber if it's null
        //    int pageNumber = criteria.PageNumber ?? 1;

        //    var pagedList = GetPagedData(queryable, pageNumber);

        //    return pagedList;
        //}




    }
}
