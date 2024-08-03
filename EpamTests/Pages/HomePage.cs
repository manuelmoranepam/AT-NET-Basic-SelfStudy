using LoggerLibrary.Interfaces.Loggers;
using OpenQA.Selenium;
using System;
using WebDriverLibrary.Interfaces.WebDrivers;

namespace EpamTests.Pages;

public partial class HomePage
{
	private readonly ILoggerService _loggerService;
	private readonly IWebDriverService _driverService;
	private readonly IWebDriver _driver;

	public HomePage(ILoggerService loggerService, IWebDriverService driverService)
	{
		ArgumentNullException.ThrowIfNull(loggerService);
		ArgumentNullException.ThrowIfNull(driverService);

		_loggerService = loggerService;
		_driverService = driverService;
		_driver = _driverService.GetWebDriver();

		_loggerService.LogInformation("HomePage instantiation complete.", []);
	}

	public void AcceptAllCookies()
	{
		ClickAcceptAllCookiesButton();
	}

	public void NavigateToCareersPage()
	{
		ClickCareersLink();
	}

	public void SearchFor(string searchText)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(searchText);

		ClickSearchButton();
		EnterSearchText(searchText);
		ClickFindButton();
	}
}
