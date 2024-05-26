namespace Cf_Viewmodels
{
    public class BaseVM
    {
        public int Id { get; set; }


    }
    public class CategoryVm: BaseVM
    {
         public string? CategoryName { get; set; }
        public string? Description { get; set; }
    }
}
