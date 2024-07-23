using EpamTests.Configurations;
using EpamTests.Extensions.Configurations;
using EpamTests.Pages;
using FrameworkLibrary.Startup;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System;
using WebDriverLibrary.Interfaces.Managers;

namespace EpamTests.Tests;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class CareersTest
{
	private const string _applicationUrl = "ApplicationUrl";

	private readonly IServiceProvider _services;
	private readonly IWebDriverManager _driverManager;
	private readonly HomePage _homePage;
	private readonly ILogger<HomePage> _logger;

	public CareersTest()
	{
		_services = new FrameworkLibraryStartup(
			new ConfigurationSetup()
			.GetConfiguration())
			.GetFrameworkServiceProvider();

		_logger = _services.GetRequiredService<ILogger<HomePage>>();
		_driverManager = _services.GetRequiredService<IWebDriverManager>();

		_homePage = new HomePage(_logger, _driverManager);
	}

	[SetUp]
	public void SetUp()
	{
		var url = _services.GetRequiredService<IConfiguration>().GetSectionValue<string>(_applicationUrl);

		_driverManager.NavigateTo(url);
	}

	[Test]
	public void HomePage_WhenClickingTheCareersLink_TheUserLandsOnTheCareersPage()
	{
		_homePage.NavigateToCareersPage();

		var actualUrl = _driverManager.GetInstanceOf().Url;

		Assert.That(actualUrl.Contains("careers"));
	}

	[TearDown]
	public void TearDown()
	{
		_driverManager.DisposeOf();
	}
}
