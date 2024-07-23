using EpamTests.Configurations;
using FrameworkLibrary.Startup;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using WebDriverLibrary.Interfaces.Managers;

namespace EpamTests.Tests;

[TestFixture]
public class CareersTest
{
	private const string _applicationUrl = "ApplicationUrl";

	private IServiceProvider _services;
	private IWebDriverManager _driverManager;

	[OneTimeSetUp]
	public void OneTimeSetup()
	{
		_services = new FrameworkLibraryStartup(
			new ConfigurationSetup()
			.GetConfiguration())
			.GetFrameworkServiceProvider();
	}

	[SetUp]
	public void SetUp()
	{
		_driverManager = _services.GetRequiredService<IWebDriverManager>();
	}

	[Test]
	public void GetFrameworkServiceProvider_WhenWebDriverManager_TheInstanceIsNotNull()
	{
		var url = _services.GetRequiredService<IConfiguration>()
			.GetSection(_applicationUrl).Value ?? throw new Exception();

		_driverManager.NavigateTo(url);
		var actualUrl = _driverManager.GetInstanceOf().Url;

		Assert.That(actualUrl, Is.EqualTo(url));
	}

	[TearDown]
	public void TearDown()
	{
		_driverManager.DisposeOf();
	}
}
