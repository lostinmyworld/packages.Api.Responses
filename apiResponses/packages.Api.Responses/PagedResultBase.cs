namespace packages.Api.Responses
{
    public abstract class PagedResultBase
    {
        public int CurrentPage { get; set; }
        public int CurrentPageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalEntries { get; set; }
    }
}
