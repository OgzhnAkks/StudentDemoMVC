namespace StudentDemoMVC.Helper
{
    public class PagingFunction
    {
        public static List<T> GetPage<T>(List<T> list, int pageSize, int pageNumber)
        {
            return list.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
