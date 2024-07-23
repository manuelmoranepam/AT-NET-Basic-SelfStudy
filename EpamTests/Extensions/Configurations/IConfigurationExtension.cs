using Microsoft.Extensions.Configuration;
using System;

namespace EpamTests.Extensions.Configurations;

public static class IConfigurationExtension
{
	public static T GetSectionValue<T>(this IConfiguration configuration, string sectionKey)
	{
		ArgumentNullException.ThrowIfNull(configuration);
		ArgumentException.ThrowIfNullOrWhiteSpace(sectionKey);

		var value = configuration.GetSection(sectionKey).Get<T>() ??
			throw new ArgumentNullException(sectionKey);

		return value;
	}
}
