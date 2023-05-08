using System.Collections.Generic;

namespace packages.Api.Responses
{
    public class PagedResult<T> : PagedResultBase
    {
        public List<T> Items { get; set; } = new();
    }
}
