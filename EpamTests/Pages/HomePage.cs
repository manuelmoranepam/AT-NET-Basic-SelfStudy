using Microsoft.Extensions.Logging;
using OpenQA.Selenium;
using System;
using WebDriverLibrary.Interfaces.Managers;

namespace EpamTests.Pages;

public partial class HomePage
{
	private readonly ILogger<HomePage> _logger;
	private readonly IWebDriverManager _driverManager;
	private readonly IWebDriver _driver;

	public HomePage(ILogger<HomePage> logger, IWebDriverManager driverManager)
	{
		ArgumentNullException.ThrowIfNull(logger);
		ArgumentNullException.ThrowIfNull(driverManager);

		_logger = logger;
		_driverManager = driverManager;
		_driver = _driverManager.GetInstanceOf();

		_logger.LogInformation("HomePage instantiation complete.");
	}

	public void NavigateToCareersPage()
	{
		ClickCareersLink();
	}
}
