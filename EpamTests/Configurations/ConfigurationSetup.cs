using Microsoft.Extensions.Configuration;
using System.IO;

namespace EpamTests.Configurations;

internal class ConfigurationSetup
{
	private readonly IConfiguration _configuration;

	public ConfigurationSetup()
	{
		_configuration = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json", false, true)
			.Build();
	}

	public IConfiguration GetConfiguration()
	{
		return _configuration;
	}
}
