using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using WebDriverLibrary.Configurations;
using WebDriverLibrary.Interfaces.Configurations;
using WebDriverLibrary.Interfaces.Managers;
using WebDriverLibrary.Managers;

namespace FrameworkLibrary.Startup;

public class FrameworkLibraryStartup(IConfiguration configuration)
{
	private readonly IServiceProvider _services = new ServiceCollection()
		.AddSingleton(configuration)
		.AddLogging(builder => builder.ClearProviders()
			.AddConfiguration(configuration.GetSection("Logging"))
			.AddConsole())
		.AddSingleton<IWebDriverConfiguration, WebDriverConfiguration>()
		.AddScoped<IWebDriverManager, SeleniumWebDriverManager>()
		.BuildServiceProvider();

	public IServiceProvider GetFrameworkServiceProvider()
	{
		return _services;
	}
}
