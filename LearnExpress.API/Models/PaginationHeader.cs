namespace LearnExpress.API.Models
{
    public class PaginationHeader
    {
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public bool HasPrevius { get; set; }
        public bool HasNext { get; set; }

        public PaginationHeader(int totalCount, int pageSize, int currentPage, int totalPages, bool hasPrevius, bool hasNext)
        {
            TotalCount = totalCount;
            PageSize = pageSize;
            CurrentPage = currentPage;
            TotalPages = totalPages;
            HasPrevius = hasPrevius;
            HasNext = hasNext;
        }
    }
}
