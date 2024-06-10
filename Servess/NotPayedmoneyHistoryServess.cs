﻿using AutoMapper;
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
           var queryable =  _context.NotPayedmoneyHistory.Include(i => i.UserNotPayedmoney).Include(i => i.NotPayedmoneys).Where(i => (i.PaymentStatus == criteria.PaymentStatus || criteria.PaymentStatus == 0)

             && (criteria.UserNotPayedmoneyName == null || i.UserNotPayedmoney.UserName.Contains(criteria.UserNotPayedmoneyName)) && (i.HospitalaoOrprationtyp == criteria.HospitalaoOrprationtyp || criteria.HospitalaoOrprationtyp == 0)

             ).Select(i => new NotPayedmoneyHistoryVM
             {

                 Id = i.Id,
                 HospitalaoOrprationtyp = i.HospitalaoOrprationtyp
                  ,
                 UserNotPayedmoneyName = i.UserNotPayedmoney.UserName,
                 ChangeDate = i.ChangeDate,
                 ChangedByUserId = i.ChangedByUserId,
                 CreationTime = i.CreationTime,
                  NotpayedAmount = i.NotpayedAmount,
                 ishospital = i.ishospital,
                 NotPayedmoneyId = i.NotPayedmoneyId,
                 PaymentStatus = i.PaymentStatus,
                 TotalNotpayedAmount = i.NotPayedmoneys.TotalPayedAmount,
                 TotalPayedAmount = i.NotPayedmoneys.TotalPayedAmount,
                 UserNotPayedmoneyId = i.UserNotPayedmoneyId,

             }
            ).OrderBy(g => g.Id);

            // Provide a default value for PageNumber if it's null
            int pageNumber = criteria.PageNumber ?? 1;

            var pagedList = GetPagedData(queryable, pageNumber);

            return pagedList;



        }



        public IPagedList<NotPayedmoneyHistoryVM> SaveNotPayedmoneyHistoryDetails(int id , int? pageNuber )
        {
            var queryable = _context.NotPayedmoneyHistory.Include(i => i.UserNotPayedmoney).Where(i =>  i.NotPayedmoneyId==id

                       

                        ).Select(i => new NotPayedmoneyHistoryVM
                        {

                            Id = i.Id,
                            HospitalaoOrprationtyp = i.HospitalaoOrprationtyp
                             ,
                            UserNotPayedmoneyName = i.UserNotPayedmoney.UserName,
                            ChangeDate = i.ChangeDate,
                            ChangedByUserId = i.ChangedByUserId,
                            CreationTime = i.CreationTime,
                            Description = i.Description,
                            NotpayedAmount = i.NotpayedAmount,
                            ishospital = i.ishospital,
                            NotPayedmoneyId = i.NotPayedmoneyId,
                            PaymentStatus = i.PaymentStatus,
                            
                            UserNotPayedmoneyId = i.UserNotPayedmoneyId,

                        }
                       ).OrderBy(g => g.Id);

            // Provide a default value for PageNumber if it's null
            int pageNumber = pageNuber??   1;

            var pagedList = GetPagedData(queryable, pageNumber);

            return pagedList;
        }

        public void DeleteNotPayedmoneyHistory(int id)
        {
            throw new NotImplementedException();
        }

        public IPagedList<NotPayedmoneyHistoryVM> SearchNotPayedmoneyHistory(NotPayedmoneyHistoryVM criteria)
        {
            throw new NotImplementedException();
        }

     


        public void SaveNotPayedmoneyHistory(NotPayedmoneyHistoryVM criteria)
        {
            throw new NotImplementedException();
        }

        public IPagedList<NotPayedmoneyHistoryVM> PrintforHospitallDay(int id)
        {
            throw new NotImplementedException();
        }
    }
}
