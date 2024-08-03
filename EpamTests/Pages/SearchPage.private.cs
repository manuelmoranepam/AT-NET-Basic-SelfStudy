using EpamTests.Interfaces.Models.SearchResults;
using EpamTests.Models.SearchResults;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using WebDriverLibrary.Extensions;

namespace EpamTests.Pages;

public partial class SearchPage
{
	private IList<ISearchResult> GetSearchResultsList()
	{
		try
		{
			_driver.WaitUntilElementIsVisible(_searchResultListLocator,
				_driverService.GetConfiguration().LongTimeout,
				_driverService.GetConfiguration().PollingInterval);

			var searchResults = new List<ISearchResult>();

			foreach (var searchResult in SearchResultList)
			{
				searchResults.Add(GetSearchResultItem(searchResult));
			}

			return searchResults;
		}
		catch (Exception excpetion)
		{
			_loggerService.LogError(excpetion, "An error occurred while getting search results.", _searchResultDescriptionLocator);

			throw;
		}
	}

	private ISearchResult GetSearchResultItem(IWebElement searchResult)
	{
		ArgumentNullException.ThrowIfNull(searchResult);

		var heading = searchResult.FindElement(_searchResultHeadingLocator).Text;
		var description = searchResult.FindElement(_searchResultDescriptionLocator).Text;

		return new SearchResultItem
		{
			Heading = heading,
			Description = description
		};
	}
}
