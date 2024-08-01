using OpenQA.Selenium;
using System;
using WebDriverLibrary.Enums;

namespace WebDriverLibrary.Interfaces.Configurations
{
	public interface IWebDriverConfiguration
	{
		TimeSpan AsynchronousJSTimeout { get; set; }
		BrowserType Browser { get; set; }
		TimeSpan ImplicitTimeout { get; set; }
		bool IsHeadless { get; set; }
		bool IsMaximized { get; set; }
		PageLoadStrategy PageLoadStrategy { get; set; }
		TimeSpan LongTimeout { get; set; }
		TimeSpan MediumTimeout { get; set; }
		TimeSpan PageLoadTimeout { get; set; }
		TimeSpan PollingInterval { get; set; }
		TimeSpan SmallTimeout { get; set; }
	}
}
