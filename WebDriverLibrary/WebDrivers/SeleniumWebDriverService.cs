using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using WebDriverLibrary.Enums;
using WebDriverLibrary.Interfaces.Configurations;
using WebDriverLibrary.Interfaces.WebDrivers;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace WebDriverLibrary.WebDrivers;

public class SeleniumWebDriverService : IWebDriverService
{

	private readonly IWebDriver _webDriver;
	private readonly IWebDriverConfiguration _driverConfiguration;

	public SeleniumWebDriverService(IWebDriverConfiguration driverConfiguration)
	{
		ArgumentNullException.ThrowIfNull(driverConfiguration);

		_driverConfiguration = driverConfiguration;

		_webDriver = CreateWebDriver();

		ApplyConfigurations();
	}

	private IWebDriver CreateWebDriver()
	{
		return _driverConfiguration.Browser switch
		{
			BrowserType.Edge => CreateEdgeDriver(),
			BrowserType.Chrome => CreateChromeDriver(),
			BrowserType.Firefox => CreateFirefoxDriver(),
			_ => throw new ArgumentException("Browser type not supported")
		};
	}

	private EdgeDriver CreateEdgeDriver()
	{
		_ = new DriverManager().SetUpDriver(new EdgeConfig());

		var options = GetEdgeOptions();

		var driver = new EdgeDriver(options);

		return driver;
	}

	private EdgeOptions GetEdgeOptions()
	{
		var options = new EdgeOptions();

		options.AddArgument("--inprivate");
		options.PageLoadStrategy = _driverConfiguration.PageLoadStrategy;

		if (_driverConfiguration.IsHeadless)
			options.AddArgument("--headless");

		return options;
	}

	private ChromeDriver CreateChromeDriver()
	{
		_ = new DriverManager().SetUpDriver(new ChromeConfig());

		var options = GetChromeOptions();

		var driver = new ChromeDriver(options);

		return driver;
	}

	private ChromeOptions GetChromeOptions()
	{
		var options = new ChromeOptions();

		options.AddArgument("--incognito");
		options.PageLoadStrategy = _driverConfiguration.PageLoadStrategy;

		if (_driverConfiguration.IsHeadless)
			options.AddArgument("--headless");

		return options;
	}

	private FirefoxDriver CreateFirefoxDriver()
	{
		_ = new DriverManager().SetUpDriver(new FirefoxConfig());

		var options = GetFirefoxOptions();

		var driver = new FirefoxDriver(options);

		return driver;
	}

	private FirefoxOptions GetFirefoxOptions()
	{
		var options = new FirefoxOptions();

		options.AddArgument("--private");
		options.PageLoadStrategy = _driverConfiguration.PageLoadStrategy;

		if (_driverConfiguration.IsHeadless)
			options.AddArgument("--headless");

		return options;
	}

	private void ApplyConfigurations()
	{
		_webDriver.Manage().Timeouts().PageLoad = _driverConfiguration.PageLoadTimeout;
		_webDriver.Manage().Timeouts().ImplicitWait = _driverConfiguration.ImplicitTimeout;
		_webDriver.Manage().Timeouts().AsynchronousJavaScript = _driverConfiguration.AsynchronousJSTimeout;
		_webDriver.Manage().Cookies.DeleteAllCookies();

		if (_driverConfiguration.IsMaximized)
			_webDriver.Manage().Window.Maximize();
	}

	public IWebDriverConfiguration GetConfiguration()
	{
		return _driverConfiguration;
	}

	public IWebDriver GetWebDriver()
	{
		return _webDriver;
	}

	public void DisposeWebDriver()
	{
		if (_webDriver is not null)
		{
			_webDriver.Close();
			_webDriver.Quit();
			_webDriver.Dispose();
		}
	}

	public void NavigateTo(string url)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(url);

		_webDriver.Navigate().GoToUrl(url);
	}

	public string GetCurrentUrl()
	{
		return _webDriver.Url;
	}
}
