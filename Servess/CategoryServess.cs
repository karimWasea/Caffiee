//using AutoMapper;

//using Cf_Viewmodels;

//using DataAcessLayers;

//using Interfaces;

//using Microsoft.EntityFrameworkCore;
//using X.PagedList;

//namespace Servess
//{
//    public class CategoryServess :  PaginationHelper<CategoryVm>,ICategory
//    {
//        public readonly ApplicationDBcontext _context;

//        private readonly IMapper _mapper;
        
//        public CategoryServess(ApplicationDBcontext context , IMapper mapper)  
//        {
//            _context = context;
//            _mapper = mapper;

//        }
//        public bool CheckIfExisit(CategoryVm entity)
//        {
//         return   _context.Categories.Any(i => i.Id != entity.Id && i.CategoryName == entity.CategoryName);
//                }

//        public void Create(CategoryVm entity)
//        {
//            var category = new Category
//            {
//                // Id = entity.Id,
//                CategoryName = entity.CategoryName,
//                Description = entity.Description
//            };
//            _context.Categories.Add(category);
//        }

//        public void Delete(int id)
//        {
//             _context.Remove(_context.Categories.Find(id));  
        
//        }

//        public CategoryVm Get(int id)
//        {


//            //return _mapper.Map<RoomlDto>(_context.Rooms.Find(id));

//            return _context.Categories.Where(i => i.Id == id).Select(i => new CategoryVm { 
//           Id = i.Id,
//            CategoryName    =   i.CategoryName,
//             Description = i.Description,   
//          }).FirstOrDefault();
        
//        }


        



//        //public IPagedList<RoomlDto> Seach(RoomSM DtoSearch)
//        //{
//        //    var Qarable =


//        //        _context.Rooms.Include(i => i.Department).Where(
//        //        Departments =>

//        //        (DtoSearch.Id == 0 || DtoSearch.Id == null || Departments.Id == DtoSearch.Id)


//        //              && (DtoSearch.DepartmentName == null || Departments.Department.DepartmentName.Contains(DtoSearch.DepartmentName))

//        //              &&
//        //              (DtoSearch.Building == null || Departments.Building.Contains(DtoSearch.DepartmentName)) &&
//        //              (DtoSearch.RoomNumber == null || Departments.RoomNumber.Contains(DtoSearch.RoomNumber))


//        //              )
//        //        .Select(Departments => new RoomlDto
//        //        {
//        //            Id = Departments.Id,
//        //            DepartmentName = Departments.Department.DepartmentName,
//        //            Building = DtoSearch.Building,
//        //            RoomNumber = Departments.RoomNumber,
//        //            Capacity = Departments.Capacity,
//        //            DepartmentId = Departments.DepartmentId



//        //        }).OrderBy(g => g.Id);
//        //    var IPagedList = GetPagedData(Qarable, DtoSearch.PageNumber);

//        //    return IPagedList;
//        //}








//        public IPagedList<CategoryVm> GetAll(int pageNumber, int pageSize)
//        {
//            return _context.Categories.Select(s => new CategoryVm
//            {
//                CategoryName = s.CategoryName,
//                Description = s.Description,
//                Id = s.Id,
//            }).ToPagedList(pageNumber, pageSize);
//        }

//        public IEnumerable<CategoryVm> GetAll()
//        {
//            return _context.Categories.Select(s => new CategoryVm
//            {
//                CategoryName = s.CategoryName,
//                Description = s.Description,
//                Id = s.Id,
//            }).ToList();
//        }

//        public void Save()
//        {
//            _context.SaveChanges();
//        }

//        public IPagedList<CategoryVm> Search(CategoryVm criteria)
//        {
//            var Qarable =


//                _context.Categories.Where(
//                category =>

//                    (criteria.Id == 0 || criteria.Id == null || category.Id == criteria.Id)
//                          && (criteria.CategoryName == null || category.CategoryName.Contains(criteria.CategoryName))
//                          &&(criteria.Description == null || category.Description.Contains(criteria.Description))                           )
//                    .Select(category => new CategoryVm
//                    {
//                        Id = category.Id,
//                        CategoryName = category.CategoryName,
//                        Description= category.Description,
//                    }).OrderBy(g => g.Id);
//            var IPagedList = GetPagedData(Qarable);

//            return IPagedList;
//        }

//        public void Update(CategoryVm entity)
//        {
//            var category = _context.Categories.Find(entity.Id);
//            if (category != null)
//            {
//                category.Description = entity.Description;
//                category.CategoryName = entity.CategoryName;
//                category.Description = entity.Description;

//                _context.SaveChanges();
//            }
//        }
//    }
//}
