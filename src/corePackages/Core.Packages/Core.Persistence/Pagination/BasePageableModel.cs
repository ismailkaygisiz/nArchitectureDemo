namespace Core.Persistence.Pagination
{
    public abstract class BasePageableModel
    {
        public int Size { get; set; }
        public int Index { get; set; }
        public long Count { get; set; }
        public int Pages { get; set; }
        public bool HasPrevious => Index > 0;
        public bool HasNext => Index + 1 < Pages;
    }
}
