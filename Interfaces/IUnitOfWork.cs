namespace Interfaces
{
    public interface IUnitOfWork : IDisposable

    {
          ICategory _Category { get;   }
          IProduct _Product { get;   }
     }
}
