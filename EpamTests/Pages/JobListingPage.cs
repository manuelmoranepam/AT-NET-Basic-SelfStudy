using LoggerLibrary.Interfaces.Loggers;
using OpenQA.Selenium;
using System;
using WebDriverLibrary.Interfaces.WebDrivers;

namespace EpamTests.Pages;

public partial class JobListingPage
{
	private readonly ILoggerService _loggerService;
	private readonly IWebDriverService _webDriverService;
	private readonly IWebDriver _driver;

	public JobListingPage(ILoggerService loggerService, IWebDriverService webDriverService)
	{
		ArgumentNullException.ThrowIfNull(loggerService);
		ArgumentNullException.ThrowIfNull(webDriverService);

		_loggerService = loggerService;
		_webDriverService = webDriverService;
		_driver = _webDriverService.GetWebDriver();

		_loggerService.LogInformation("JobListingPage instantiation complete.", []);
	}

	public string GetJobTitle()
	{
		return GetJobTitleHeading();
	}
}
