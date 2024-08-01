using ConfigurationLibrary.Interfaces.Configurations;
using EpamTests.Interfaces.Models.Careers;
using EpamTests.Models.Careers;
using EpamTests.Pages;
using EpamTests.TestData;
using FrameworkLibrary.Startup;
using LoggerLibrary.Interfaces.Loggers;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using WebDriverLibrary.Interfaces.WebDrivers;

namespace EpamTests.Tests;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CareersTest
{
	private const string _appSettingsFilePath = "appsettings.json";
	private const string _applicationUrl = "ApplicationUrl";

	private readonly IServiceScopeFactory _scopeFactory;

	private IServiceScope _scope;
	private ILoggerService _loggerService;
	private IWebDriverService _driverService;
	private HomePage _homePage;
	private CareersPage _careersPage;

	public CareersTest()
	{
		_scopeFactory = new FrameworkLibraryStartup(_appSettingsFilePath)
			.GetServiceScopeFactory();
	}

	[SetUp]
	public void SetUp()
	{
		_scope = _scopeFactory.CreateScope();

		var url = _scope.ServiceProvider.GetRequiredService<IConfigurationService>()
			.GetConfigurationValue<string>(_applicationUrl);

		_loggerService = _scope.ServiceProvider.GetRequiredService<ILoggerService>();
		_driverService = _scope.ServiceProvider.GetRequiredService<IWebDriverService>();

		_homePage = new HomePage(_loggerService, _driverService);
		_careersPage = new CareersPage(_loggerService, _driverService);

		_driverService.NavigateTo(url);
	}

	[Test, TestCaseSource(typeof(TestDataLoader<CareerSearch>), nameof(TestDataLoader<CareerSearch>.LoadTestData), new object[] { "TestData/Models/Careers/CareerSearch.json" })]
	public void CareerPage_WhenSearchingForACareer_LatestElementContainsProgrammingLanguage(ICareerSearch careerSearch)
	{
		_homePage.AcceptAllCookies();
		_homePage.NavigateToCareersPage();

		_careersPage.FillCareersForm(careerSearch);
	}

	[TearDown]
	public void TearDown()
	{
		_driverService.DisposeWebDriver();
		_loggerService.CloseAndFlush();
		_scope.Dispose();
	}
}
