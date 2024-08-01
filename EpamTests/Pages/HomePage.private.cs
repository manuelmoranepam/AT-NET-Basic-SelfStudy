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
			AcceptAllCookiesButton.Click();
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
}
