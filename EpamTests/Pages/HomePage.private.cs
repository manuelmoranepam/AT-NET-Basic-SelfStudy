using Microsoft.Extensions.Logging;
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
				_driverManager.GetConfiguration().LongTimeout,
				_driverManager.GetConfiguration().PollingInterval);

			CareersLink.Click();
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, message: "Failed to click the careers link with locator {0}.", args: _careersLinkLocator);

			throw;
		}
	}
}
