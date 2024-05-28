﻿using X.PagedList;

namespace Interfaces
{
    public interface IGenericService<T> :IPaginationHelper<T> where T : class
    {
        void Create(T entity);
        void Update(T entity);
        void Save();
        void Delete(int id);
        IPagedList<T> Search(T criteria);
        T Get(int id);
        IPagedList<T> GetAll(int pageNumber, int pageSize);
        IEnumerable<T> GetAll();
        bool CheckIfExisit(T entity);
    }
 
}
