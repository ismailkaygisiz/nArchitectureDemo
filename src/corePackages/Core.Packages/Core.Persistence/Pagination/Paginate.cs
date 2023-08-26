namespace Core.Persistence.Pagination
{
    public class Paginate<TEntity>
    {
        public Paginate()
        {
            Items = Array.Empty<TEntity>();
        }

        public int Size { get; set; }
        public int Index { get; set; }
        public long Count { get; set; }
        public int Pages { get; set; }
        public IList<TEntity> Items { get; set; }
        public bool HasPrevious => Index > 0;
        public bool HasNext => Index + 1 < Pages;
    }
}
