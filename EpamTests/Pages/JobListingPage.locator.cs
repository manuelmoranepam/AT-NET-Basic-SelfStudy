using OpenQA.Selenium;

namespace EpamTests.Pages;

public partial class JobListingPage
{
	private readonly By _jobTitleHeadingLocator = By.XPath("//h1[contains(@class, 'vacancy-details-23__job-title')]");

	private IWebElement JobTitleHeading => _driver.FindElement(_jobTitleHeadingLocator);
}
