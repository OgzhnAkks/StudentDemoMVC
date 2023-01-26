namespace StudentDemoMVC.Models
{
    public class PaginationFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public PaginationFilter(int pageNumber = 1, int pageSize = 10)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize > 10 ? 10 : pageSize;
        }

    }
}
