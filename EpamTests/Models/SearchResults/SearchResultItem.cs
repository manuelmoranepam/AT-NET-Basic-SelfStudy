using EpamTests.Interfaces.Models.SearchResults;

namespace EpamTests.Models.SearchResults;

internal class SearchResultItem : ISearchResult
{
	public string Heading { get; set; } = null!;
	public string Description { get; set; } = null!;
}
