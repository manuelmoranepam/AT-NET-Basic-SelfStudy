using OpenQA.Selenium;

namespace EpamTests.Pages;

public partial class HomePage
{
	private readonly By _careersLinkLocator = By.XPath("//ul[contains(@class, 'top-navigation__row')]//a[contains(@class, 'top-navigation__item-link')][contains(@href, 'careers')]");

	private IWebElement CareersLink => _driver.FindElement(_careersLinkLocator);
}
