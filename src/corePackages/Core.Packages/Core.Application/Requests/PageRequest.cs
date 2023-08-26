namespace Core.Application.Requests
{
    public class PageRequest
    {
        public PageRequest()
        {
            PageIndex = 0;
            PageSize = 20;
        }

        public PageRequest(int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
