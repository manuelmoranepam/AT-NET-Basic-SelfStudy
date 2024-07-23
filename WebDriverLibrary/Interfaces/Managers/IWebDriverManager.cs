using OpenQA.Selenium;
using WebDriverLibrary.Interfaces.Configurations;

namespace WebDriverLibrary.Interfaces.Managers;

public interface IWebDriverManager
{
	IWebDriverConfiguration GetConfiguration();
	IWebDriver GetInstanceOf();
	void DisposeOf();
	void NavigateTo(string url);
}
