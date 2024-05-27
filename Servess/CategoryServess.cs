using AutoMapper;

using Cf_Viewmodels;

using DataAcessLayers;

using Interfaces;

using Microsoft.EntityFrameworkCore;

using X.PagedList;

namespace Servess
{
    public class CategoryServess :  PaginationHelper<CategoryVm>,ICategory
    {
        public readonly ApplicationDBcontext _context;

        private readonly IMapper _mapper;
        
        public CategoryServess(ApplicationDBcontext context , IMapper mapper)  
        {
            _context = context;
            _mapper = mapper;

        }
        public bool CheckIfExisit(CategoryVm entity)
        {
         return   _context.Categories.Any(i => i.Id != entity.Id && i.CategoryName == entity.CategoryName);
                }

        public void Create(CategoryVm entity)
        {
            var category = new Category
            {
                // Id = entity.Id,
                CategoryName = entity.CategoryName,
                Description = entity.Description
            };
            _context.Categories.Add(category);
        }

        public void Delete(int id)
        {
             _context.Remove(_context.Categories.Find(id));  
        
        }

        public CategoryVm Get(int id)
        {


            //return _mapper.Map<RoomlDto>(_context.Rooms.Find(id));

            return _context.Categories.Where(i => i.Id == id).Select(i => new CategoryVm { 
           Id = i.Id,
            CategoryName    =   i.CategoryName,
             Description = i.Description,   
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








        public IPagedList<CategoryVm> GetAll(int pageNumber, int pageSize)
        {
            return _context.Categories.Select(s => new CategoryVm
            {
                CategoryName = s.CategoryName,
                Description = s.Description,
                Id = s.Id,
            }).ToPagedList(pageNumber, pageSize);
        }

       

        public void Save()
        {
            _context.SaveChanges();
        }

        public IPagedList<CategoryVm> Search(CategoryVm criteria)
        {
            throw new NotImplementedException();
        }
    }
}
