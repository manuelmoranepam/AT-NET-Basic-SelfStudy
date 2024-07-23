using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace WebDriverLibrary.Extensions;

public static class IWebDriverWaitMechanismExtension
{
	public static void WaitUntilElementIsClickable(this IWebDriver webDriver, By locator, TimeSpan timeout, TimeSpan pollingInterval)
	{
		NullCheckAllParameters(webDriver, locator, timeout, pollingInterval);

		var wait = new WebDriverWait(new SystemClock(), webDriver, timeout, pollingInterval);

		wait.Until(ExpectedConditions.ElementToBeClickable(locator));
	}

	private static void NullCheckAllParameters(IWebDriver webDriver, By locator, TimeSpan timeout, TimeSpan pollingInterval)
	{
		ArgumentNullException.ThrowIfNull(webDriver);
		ArgumentNullException.ThrowIfNull(locator);
		ArgumentOutOfRangeException.ThrowIfLessThan(timeout, TimeSpan.FromSeconds(1));
		ArgumentOutOfRangeException.ThrowIfLessThan(pollingInterval, TimeSpan.FromSeconds(1));
		ArgumentOutOfRangeException.ThrowIfLessThan(timeout, pollingInterval);
	}
}
