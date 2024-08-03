using ConfigurationLibrary.Interfaces.Configurations;
using EpamTests.Pages;
using FrameworkLibrary.Startup;
using LoggerLibrary.Interfaces.Loggers;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Linq;
using WebDriverLibrary.Interfaces.WebDrivers;

namespace EpamTests.Tests;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class SearchTest
{
	private const string _appSettingsFilePath = "appsettings.json";
	private const string _applicationUrl = "ApplicationUrl";

	private readonly IServiceScopeFactory _scopeFactory;

	private IServiceScope _scope;
	private ILoggerService _loggerService;
	private IWebDriverService _driverService;
	private HomePage _homePage;
	private SearchPage _searchPage;

	public SearchTest()
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
		_searchPage = new SearchPage(_loggerService, _driverService);

		_driverService.NavigateTo(url);
	}

	[Test]
	[TestCase("BLOCKCHAIN")]
	[TestCase("Cloud")]
	[TestCase("Automation")]
	public void Search_WhenSearchingForSomething_ResultIsNotEmpty(string searchText)
	{
		_homePage.AcceptAllCookies();
		_homePage.SearchFor(searchText);

		var searchResults = _searchPage.GetSearchResults();

		Assert.Multiple(() =>
		{
			var isSearchTextContained = searchResults.All(result => result.Heading.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
					result.Description.Contains(searchText, StringComparison.OrdinalIgnoreCase));

			Assert.That(isSearchTextContained, Is.True);

			var resultsNotContainingSearchText = searchResults.Where(result => !result.Heading.Contains(searchText, StringComparison.OrdinalIgnoreCase) &&
					!result.Description.Contains(searchText, StringComparison.OrdinalIgnoreCase));

			Assert.That(resultsNotContainingSearchText.Any(), Is.False);

			resultsNotContainingSearchText.ToList().ForEach(result =>
				_loggerService.LogInformation("Search result not containing '{0}':\n\tHeading: {1}\n\tDescription: {2}",
					[searchText, result.Heading, result.Description]));
		});
	}

	[TearDown]
	public void TearDown()
	{
		_driverService.DisposeWebDriver();
		_loggerService.CloseAndFlush();
		_scope.Dispose();
	}
}
