using OpenQA.Selenium.Interactions;
using System;
using WebDriverLibrary.Extensions;

namespace EpamTests.Pages;

public partial class HomePage
{
	private bool IsAcceptAllCookiesButtonDisplayed()
	{
		try
		{
			return AcceptAllCookiesButton.Displayed;
		}
		catch
		{
			_loggerService.LogInformation("The Accept All Cookies button is not displayed", _acceptAllCookiesButtonLocator);

			return false;
		}
	}

	private void ClickAcceptAllCookiesButton()
	{
		var isDisplayed = IsAcceptAllCookiesButtonDisplayed();

		if (isDisplayed)
		{
			new Actions(_driver)
				.Pause(_driverService.GetConfiguration().PollingInterval)
				.MoveToElement(AcceptAllCookiesButton)
				.Click()
				.Build()
				.Perform();
		}
	}

	private void ClickCareersLink()
	{
		try
		{
			_driver.WaitUntilElementIsClickable(_careersLinkLocator,
				_driverService.GetConfiguration().LongTimeout,
				_driverService.GetConfiguration().PollingInterval);

			CareersLink.Click();
		}
		catch (Exception ex)
		{
			_loggerService.LogError(ex, message: "Failed to click the careers link with locator {0}.", args: _careersLinkLocator);

			throw;
		}
	}

	private void ClickSearchButton()
	{
		try
		{
			_driver.WaitUntilElementIsClickable(_searchButtonLocator,
				_driverService.GetConfiguration().LongTimeout,
				_driverService.GetConfiguration().PollingInterval);

			SearchButton.Click();
		}
		catch (Exception exception)
		{
			_loggerService.LogError(exception, message: "Failed to click the search button with locator {0}.", args: _searchButtonLocator);

			throw;
		}
	}

	private void ClearSearchTextbox()
	{
		try
		{
			_driver.WaitUntilElementIsVisible(_searchTextboxLocator,
				_driverService.GetConfiguration().LongTimeout,
				_driverService.GetConfiguration().PollingInterval);

			SearchTextbox.Clear();
		}
		catch (Exception exception)
		{
			_loggerService.LogError(exception, message: "Failed to clear the search textbox with locator {0}.", args: _searchTextboxLocator);

			throw;
		}
	}

	private void EnterSearchText(string searchText)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(searchText);

		try
		{
			ClearSearchTextbox();

			SearchTextbox.SendKeys(searchText);
		}
		catch (Exception exception)
		{
			_loggerService.LogError(exception, message: "Failed to enter the search text {0} in the search textbox with locator {1}.", args: [searchText, _searchTextboxLocator]);

			throw;
		}
	}

	private void ClickFindButton()
	{
		try
		{
			_driver.WaitUntilElementIsClickable(_findButtonLocator,
				_driverService.GetConfiguration().LongTimeout,
				_driverService.GetConfiguration().PollingInterval);

			FindButton.Click();
		}
		catch (Exception exception)
		{
			_loggerService.LogError(exception, message: "Failed to click the find button with locator {0}.", args: _findButtonLocator);

			throw;
		}
	}
}