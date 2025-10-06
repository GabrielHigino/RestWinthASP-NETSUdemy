using Erudio.HATEOAS.Hypermedia.Abstract;
using System.Collections.Generic;

namespace Erudio.HATEOAS.Hypermedia.Filters
{
    public class HyperMediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
    }
}
