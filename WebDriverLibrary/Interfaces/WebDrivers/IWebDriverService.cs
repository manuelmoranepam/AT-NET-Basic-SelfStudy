using OpenQA.Selenium;
using WebDriverLibrary.Interfaces.Configurations;

namespace WebDriverLibrary.Interfaces.WebDrivers;

public interface IWebDriverService
{
	IWebDriverConfiguration GetConfiguration();
	IWebDriver GetWebDriver();
	void DisposeWebDriver();
	void NavigateTo(string url);
	string GetCurrentUrl();
}
