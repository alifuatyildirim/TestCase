namespace TestCase.Contract.Abstraction
{
    public abstract class PagedSearchableQuery : PagedQuery, ISearchableQuery
    {
        public string? SearchText { get; set; }
    }
}
