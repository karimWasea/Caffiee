using Cf_Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using X.PagedList;

namespace Interfaces
{
    public interface INotPayedmoneyHistoryServess : IPaginationHelper<NotPayedmoneyHistoryVM> 
    {


        void SaveNotPayedmoney(NotPayedmoneyHistoryVM criteria);
        void DeleteNotPayedmoney(int id);
        IPagedList<NotPayedmoneyHistoryVM> SearchNotPayedmoney(NotPayedmoneyHistoryVM criteria);


        public IPagedList<NotPayedmoneyHistoryVM> SaveNotPayedmoneyHistoryDetails(int id, int? pageNuber);
        void DeleteNotPayedmoneyHistory(int id);
        IPagedList<NotPayedmoneyHistoryVM> PrintforHospitallDay(int id);
        void SaveNotPayedmoneyHistory(NotPayedmoneyHistoryVM criteria);

    }




    public interface IFinancialUserCashHistoryServess : IPaginationHelper<FinancialUserCashHistoryVM>
    {


        void SaveNotPayedmoney(FinancialUserCashHistoryVM criteria);
        void DeleteNotPayedmoney(FinancialUserCashHistoryVM criteria);
        IPagedList<FinancialUserCashHistoryVM> SearchNotPayedmoney(FinancialUserCashHistoryVM criteria);


        void SaveNotPayedmoneyHistoryDetails(int id);
        void DeleteNotPayedmoneyHistory(int id);
        IPagedList<FinancialUserCashHistoryVM> SearchNotPayedmoneyHistory(FinancialUserCashHistoryVM criteria);
    }










}
