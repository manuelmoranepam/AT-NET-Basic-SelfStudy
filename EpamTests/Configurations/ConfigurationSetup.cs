using Microsoft.Extensions.Configuration;
using System.IO;

namespace EpamTests.Configurations;

internal class ConfigurationSetup
{
	public IConfiguration GetConfiguration()
	{
		return new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json", false, true)
			.Build();
	}
}
