using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using WebDriverLibrary.Enums;
using WebDriverLibrary.Interfaces.Configurations;

namespace WebDriverLibrary.Configurations
{
	public class WebDriverConfiguration : IWebDriverConfiguration
	{
		[JsonProperty(nameof(Browser))]
		public BrowserType Browser { get; set; }

		[JsonProperty(nameof(IsHeadless))]
		public bool IsHeadless { get; set; }

		[JsonProperty(nameof(IsMaximized))]
		public bool IsMaximized { get; set; }

		[JsonProperty(nameof(PageLoadTimeout))]
		public TimeSpan PageLoadTimeout { get; set; }

		[JsonProperty(nameof(ImplicitTimeout))]
		public TimeSpan ImplicitTimeout { get; set; }

		[JsonProperty(nameof(AsynchronousJSTimeout))]
		public TimeSpan AsynchronousJSTimeout { get; set; }

		[JsonProperty(nameof(LongTimeout))]
		public TimeSpan LongTimeout { get; set; }

		[JsonProperty(nameof(MediumTimeout))]
		public TimeSpan MediumTimeout { get; set; }

		[JsonProperty(nameof(SmallTimeout))]
		public TimeSpan SmallTimeout { get; set; }

		[JsonProperty(nameof(PollingInterval))]
		public TimeSpan PollingInterval { get; set; }

		public WebDriverConfiguration(ILogger<WebDriverConfiguration> logger, IConfiguration configuration)
		{
			ArgumentNullException.ThrowIfNull(logger);
			ArgumentNullException.ThrowIfNull(configuration);

			logger.LogInformation("Creating instance of WebDriverConfiguration.");

			var section = configuration.GetSection("WebDriverConfiguration") ??
				throw new ArgumentNullException(nameof(configuration));

			section.Bind(this);

			logger.LogInformation("WebDriverConfiguration instance created.");
		}
	}
}
