using AutoMapper;

using C_Utilities;

using Cf_Viewmodels;

using DataAcessLayers;

using Interfaces;

using Microsoft.EntityFrameworkCore;

using System.Linq;

using X.PagedList;

namespace Servess
{
    public class CategoryServess : PaginationHelper<CategoryVm>, ICategory
    {
        public readonly ApplicationDBcontext _context;
        Imgoperation _Imgoperation;


        private readonly IMapper _mapper;

        public CategoryServess(ApplicationDBcontext context, IMapper mapper , Imgoperation Imgoperation)
        {
            _context = context;
            _mapper = mapper;
            _Imgoperation = Imgoperation;   


        }
        public bool CheckIfExisit(CategoryVm entity)
        {
            return _context.Categories.Any(i => i.Id != entity.Id && i.CategoryName == entity.CategoryName);
        }

      

        public void Delete(int id)
        {
            _context.Remove(_context.Categories.Find(id));
             _context.SaveChanges();

        }


        public CategoryVm Get(int id)
        {


            return _mapper.Map<CategoryVm>(_context.Categories.Find(id));



        }

        public void Save(CategoryVm criteria)
        {
            var Entity = _mapper.Map<DataAcessLayers.Category>(criteria);
            if (criteria.Id > 0)
            {
                var updated = _context.Update(Entity);
              var update=  _context.SaveChanges();
                if (update > 0)
                {
                    var path = _Imgoperation.UploadFile(criteria.Imge, "Category", Entity.CategoryName);
                    var ProductAttachment = new CategoryAttachment();

                    ProductAttachment.CategoryId = updated.Entity.Id;
                    ProductAttachment.FilePath = path;
                    ProductAttachment.FileType = "Category";
                    _context.Add(ProductAttachment);
                    _context.SaveChanges();
                }
              
            }else
            {

           var add =     _context.Add(Entity);
              var saved=   _context.SaveChanges();
                if(saved>0)
                {
                    var path = _Imgoperation.UploadFile(criteria.Imge, "Category", Entity.CategoryName);
                    var ProductAttachment = new CategoryAttachment();

                    ProductAttachment.CategoryId = add.Entity.Id;
                    ProductAttachment.FilePath = path;
                    ProductAttachment.FileType = "Category";
                    _context.Add(ProductAttachment);
                }
           

            }
            _context.SaveChanges();

        }

        public IPagedList<CategoryVm> Search(CategoryVm criteria)
        {
            var Qarable =


                _context.Categories.Where(
                category =>

                           (criteria.CategoryName == null || category.CategoryName.Contains(criteria.CategoryName))
                          && (criteria.Description == null || category.Description.Contains(criteria.Description)))
                    .Select(category => new CategoryVm
                    {
                        Id = category.Id,
                        CategoryName = category.CategoryName,
                        Description = category.Description,
                    }).OrderBy(g => g.Id);

            // Provide a default value for PageNumber if it's null
            int pageNumber = criteria.PageNumber ?? 1;

            var pagedList = GetPagedData(Qarable, pageNumber);

            return pagedList;
        }
    }

         
    
}
