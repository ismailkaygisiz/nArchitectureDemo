using Core.Persistence.Pagination;

namespace Core.Application.Responses
{
    public class GetListResponse<TItem> : BasePageableModel
    {
        private IList<TItem> _items;

        public IList<TItem> Items
        {
            get => _items ??= new List<TItem>();
            set => _items = value;
        }
    }
}
