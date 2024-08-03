using EpamTests.Interfaces.Models.SearchResults;
using LoggerLibrary.Interfaces.Loggers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using WebDriverLibrary.Interfaces.WebDrivers;

namespace EpamTests.Pages;

public partial class SearchPage
{
	private readonly ILoggerService _loggerService;
	private readonly IWebDriverService _driverService;
	private readonly IWebDriver _driver;

	public SearchPage(ILoggerService loggerService, IWebDriverService driverService)
	{
		ArgumentNullException.ThrowIfNull(loggerService);
		ArgumentNullException.ThrowIfNull(driverService);

		_loggerService = loggerService;
		_driverService = driverService;
		_driver = _driverService.GetWebDriver();

		_loggerService.LogInformation("SearchPage instantiation complete.", []);
	}

	public IList<ISearchResult> GetSearchResults()
	{
		return GetSearchResultsList();
	}
}
