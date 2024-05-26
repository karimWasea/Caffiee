using X.PagedList;

namespace Interfaces
{
    public interface IGenericService<T> :IPaginationHelper<T> where T : class
    {
        void Save(T entity);
        void Delete(int id);
        IPagedList<T> Search(T criteria);
        T Get(int id);
        IPagedList<T> GetAll();
        bool CheckIfExisit(T entity);
    }
 
}
