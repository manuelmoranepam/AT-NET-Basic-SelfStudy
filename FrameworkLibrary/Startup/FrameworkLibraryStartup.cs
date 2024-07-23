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
		.AddLogging(builder => builder.AddConsole())
		.AddSingleton(configuration)
		.AddSingleton<IWebDriverConfiguration, WebDriverConfiguration>()
		.AddScoped<IWebDriverManager, SeleniumWebDriverManager>()
		.BuildServiceProvider();

	public IServiceProvider GetFrameworkServiceProvider()
	{
		return _services;
	}
}
