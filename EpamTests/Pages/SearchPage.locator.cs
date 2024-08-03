using OpenQA.Selenium;
using System.Collections.Generic;

namespace EpamTests.Pages;

public partial class SearchPage
{
	private readonly By _searchResultListLocator = By.TagName("article");
	private readonly By _searchResultHeadingLocator = By.XPath(".//h3[contains(@class, 'search-results__title')]");
	private readonly By _searchResultDescriptionLocator = By.XPath(".//p[contains(@class, 'search-results__description')]");

	private IList<IWebElement> SearchResultList => _driver.FindElements(_searchResultListLocator);
}
