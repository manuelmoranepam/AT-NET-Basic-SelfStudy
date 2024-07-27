using ConfigurationLibrary.Interfaces.Configurations;
using EpamTests.Pages;
using FrameworkLibrary.Startup;
using LoggerLibrary.Interfaces.Loggers;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using WebDriverLibrary.Interfaces.WebDrivers;

namespace EpamTests.Tests;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class CareersTest
{
	private const string _appSettingsFilePath = "appsettings.json";
	private const string _applicationUrl = "ApplicationUrl";

	private readonly IServiceProvider _services;

	private ILoggerService _loggerService;
	private IWebDriverService _driverService;
	private HomePage _homePage;

	public CareersTest()
	{
		_services = new FrameworkLibraryStartup(_appSettingsFilePath)
			.GetFrameworkServiceProvider();
	}

	[SetUp]
	public void SetUp()
	{
		var url = _services.GetRequiredService<IConfigurationService>()
			.GetConfigurationValue<string>(_applicationUrl);

		_loggerService = _services.GetRequiredService<ILoggerService>();
		_driverService = _services.GetRequiredService<IWebDriverService>();

		_homePage = new HomePage(_loggerService, _driverService);

		_driverService.NavigateTo(url);
	}

	[Test]
	public void HomePage_WhenClickingTheCareersLink_TheUserLandsOnTheCareersPage()
	{
		_homePage.NavigateToCareersPage();

		var actualUrl = _driverService.GetWebDriver().Url;

		Assert.That(actualUrl, Does.Contain("careers"));
	}

	[TearDown]
	public void TearDown()
	{
		_driverService.DisposeWebDriver();
	}
}
