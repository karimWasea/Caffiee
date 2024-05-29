namespace Cf_Viewmodels
{
    public class BaseVM
    {
        public int Id { get; set; }
        public int ?PageNumber { get; set; }
      public  int pageSize { get; set; }



    }
    public class CategoryVm: BaseVM
    {
         public string? CategoryName { get; set; }
        public string? Description { get; set; }
    }
}
