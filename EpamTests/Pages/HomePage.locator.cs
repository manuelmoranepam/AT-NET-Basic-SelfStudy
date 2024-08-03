using OpenQA.Selenium;

namespace EpamTests.Pages;

public partial class HomePage
{
	private readonly By _acceptAllCookiesButtonLocator = By.XPath("//button[@id = 'onetrust-accept-btn-handler']");
	private readonly By _careersLinkLocator = By.LinkText("Careers");
	private readonly By _searchButtonLocator = By.XPath("//ul[contains(@class, 'header__controls')]/li//button[contains(@class, 'header-search__button')]");
	private readonly By _searchTextboxLocator = By.Id("new_form_search");
	private readonly By _findButtonLocator = By.XPath("//div[contains(@class, 'search-results__action-section')]/button[contains(@class, 'custom-search-button')]");

	private IWebElement AcceptAllCookiesButton => _driver.FindElement(_acceptAllCookiesButtonLocator);
	private IWebElement CareersLink => _driver.FindElement(_careersLinkLocator);
	private IWebElement SearchButton => _driver.FindElement(_searchButtonLocator);
	private IWebElement SearchTextbox => _driver.FindElement(_searchTextboxLocator);
	private IWebElement FindButton => _driver.FindElement(_findButtonLocator);
}
