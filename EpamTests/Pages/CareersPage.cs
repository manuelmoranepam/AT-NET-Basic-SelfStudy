using EpamTests.Interfaces.Models.Careers;
using LoggerLibrary.Interfaces.Loggers;
using OpenQA.Selenium;
using System;
using WebDriverLibrary.Interfaces.WebDrivers;

namespace EpamTests.Pages;

public partial class CareersPage
{
	private readonly ILoggerService _loggerService;
	private readonly IWebDriverService _webDriverService;
	private readonly IWebDriver _driver;

	public CareersPage(ILoggerService loggerService, IWebDriverService webDriverService)
	{
		ArgumentNullException.ThrowIfNull(loggerService);
		ArgumentNullException.ThrowIfNull(webDriverService);

		_loggerService = loggerService;
		_webDriverService = webDriverService;
		_driver = _webDriverService.GetWebDriver();

		_loggerService.LogInformation("CareersPage instantiation complete.", []);
	}

	public void FillCareersForm(ICareerSearch careerSearch)
	{
		ArgumentNullException.ThrowIfNull(careerSearch);

		ScrollToJobSearchForm();

		ToggleLocationContainer(true);
		ToggleCountryList(careerSearch.Location, true);
		ToggleLocationContainer(true);
		SelectLocation(careerSearch.Location);
		ToggleLocationContainer(false);

		EnterKeyword(careerSearch.Keyword);
		SelectSuggestion(careerSearch.JobName);
	}
}
