using System;
using WebDriverLibrary.Extensions;

namespace EpamTests.Pages;

public partial class HomePage
{
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
