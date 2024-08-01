using ConfigurationLibrary.Interfaces.Configurations;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OpenQA.Selenium;
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

		[JsonProperty(nameof(PageLoadStrategy))]
		public PageLoadStrategy PageLoadStrategy { get; set; }

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

		public WebDriverConfiguration(IConfigurationService configurationService)
		{
			ArgumentNullException.ThrowIfNull(configurationService);

			var section = configurationService.GetConfigurationSection<IConfigurationSection>("WebDriverConfiguration");

			section.Bind(this);
		}
	}
}
