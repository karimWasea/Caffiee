using AutoMapper;
using Cf_Viewmodels;
using DataAcessLayers;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Servess
{
    public class ProductService : PaginationHelper<ProductVm>, IProduct
    {
        public readonly ApplicationDBcontext _context;

        private readonly IMapper _mapper;

        public ProductService(ApplicationDBcontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public bool CheckIfExisit(ProductVm entity)
        {
            return _context.products.Any(i => i.Id != entity.Id && i.ProductName == entity.ProductName);
        }

        public void Create(ProductVm entity)
        {
            var product = new Product
            {
                Id = entity.Id,
                ProductName = entity.ProductName,
                Description = entity.Description,
                Discount = entity.Discount,
                CategoryId = entity.CategoryId,
                CreationTime = entity.CreationTime,
                Price = entity.Price,
                Qantity = entity.Qantity
            };
            _context.products.Add(product);
        }
        public void Update(ProductVm entity)
        {
            var product = _context.products.Find(entity.Id);
            if (product != null)
            {
                product.CreationTime = entity.CreationTime;
                product.ProductName = entity.ProductName;
                product.Price = entity.Price;
                product.Qantity = entity.Qantity;
                product.CategoryId = entity.CategoryId;
                product.Description = entity.Description;
                product.Discount = entity.Discount;
                _context.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            _context.Remove(_context.products.Find(id));

        }

        public ProductVm Get(int id)
        {


            return _mapper.Map<ProductVm>(_context.products.Find(id));

            return _context.products.Where(i => i.Id == id).Select(i => new ProductVm
            {
                Id = i.Id,
                ProductName = i.ProductName,
                Description = i.Description,
                Discount = i.Discount,
                CategoryId = i.CategoryId,
                CreationTime = i.CreationTime,
                Price = i.Price,
                Qantity = i.Qantity
            }).FirstOrDefault();

        }






        //public IPagedList<RoomlDto> Seach(RoomSM DtoSearch)
        //{
        //    var Qarable =


        //        _context.Rooms.Include(i => i.Department).Where(
        //        Departments =>

        //        (DtoSearch.Id == 0 || DtoSearch.Id == null || Departments.Id == DtoSearch.Id)


        //              && (DtoSearch.DepartmentName == null || Departments.Department.DepartmentName.Contains(DtoSearch.DepartmentName))

        //              &&
        //              (DtoSearch.Building == null || Departments.Building.Contains(DtoSearch.DepartmentName)) &&
        //              (DtoSearch.RoomNumber == null || Departments.RoomNumber.Contains(DtoSearch.RoomNumber))


        //              )
        //        .Select(Departments => new RoomlDto
        //        {
        //            Id = Departments.Id,
        //            DepartmentName = Departments.Department.DepartmentName,
        //            Building = DtoSearch.Building,
        //            RoomNumber = Departments.RoomNumber,
        //            Capacity = Departments.Capacity,
        //            DepartmentId = Departments.DepartmentId



        //        }).OrderBy(g => g.Id);
        //    var IPagedList = GetPagedData(Qarable, DtoSearch.PageNumber);

        //    return IPagedList;
        //}








        public IPagedList<ProductVm> GetAll(int pageNumber, int pageSize)
        {
            return _context.products.Include(s=> s.Category).Select(i => new ProductVm
            {
                Id = i.Id,
                ProductName = i.ProductName,
                Description = i.Description,
                Discount = i.Discount,
                CategoryId = i.CategoryId,
                CreationTime = i.CreationTime,
                Price = i.Price,
                Qantity = i.Qantity,
                Category = new CategoryVm
                {
                    Id = i.Category.Id,
                    CategoryName = i.Category.CategoryName,
                    Description = i.Category.Description,
                }
            }).ToPagedList(pageNumber, pageSize);
        }



        public void Save()
        {
            _context.SaveChanges();
        }

        public IPagedList<ProductVm> Search(ProductVm criteria)
        {
            var Qarable =


                _context.products.Where(
                product =>

                    (criteria.Id == 0 || criteria.Id == null || product.Id == criteria.Id)
                          && (criteria.ProductName == null || product.ProductName.Contains(criteria.ProductName))
                          && (criteria.Description == null || product.Description.Contains(criteria.Description)))
                    .Select(i => new ProductVm
                    {
                        Id = i.Id,
                        ProductName = i.ProductName,
                        Description = i.Description,
                        Discount = i.Discount,
                        CategoryId = i.CategoryId,
                        CreationTime = i.CreationTime,
                        Price = i.Price,
                        Qantity = i.Qantity
                    }).OrderBy(g => g.Id);
            var IPagedList = GetPagedData(Qarable);

            return IPagedList;
        }

        public IEnumerable<ProductVm> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
