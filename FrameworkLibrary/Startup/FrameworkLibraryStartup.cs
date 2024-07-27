using ConfigurationLibrary.Configurations;
using ConfigurationLibrary.Interfaces.Configurations;
using LoggerLibrary.Interfaces.Loggers;
using LoggerLibrary.Loggers;
using Microsoft.Extensions.DependencyInjection;
using System;
using WebDriverLibrary.Configurations;
using WebDriverLibrary.Interfaces.Configurations;
using WebDriverLibrary.Interfaces.WebDrivers;
using WebDriverLibrary.WebDrivers;

namespace FrameworkLibrary.Startup;

public class FrameworkLibraryStartup
{
	private readonly IServiceProvider _services;

	public FrameworkLibraryStartup(string filePath)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(filePath);

		_services = new ServiceCollection()
			.AddSingleton<IConfigurationService>(new ConfigurationService(filePath))
			.AddScoped<ILoggerService, SerilogLoggerService>()
			.AddSingleton<IWebDriverConfiguration, WebDriverConfiguration>()
			.AddScoped<IWebDriverService, SeleniumWebDriverService>()
			.BuildServiceProvider();
	}

	public IServiceProvider GetFrameworkServiceProvider()
	{
		return _services;
	}
}
