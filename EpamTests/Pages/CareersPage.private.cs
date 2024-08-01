using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Linq;
using WebDriverLibrary.Extensions;

namespace EpamTests.Pages;

public partial class CareersPage
{
	private void ScrollToJobSearchForm()
	{
		try
		{
			_driver.WaitUntilElementIsVisible(_jobSearchFormLocator,
				_webDriverService.GetConfiguration().LongTimeout,
				_webDriverService.GetConfiguration().PollingInterval);

			new Actions(_driver)
				.MoveToElement(JobSearchForm)
				.Pause(_webDriverService.GetConfiguration().PollingInterval)
				.Build()
				.Perform();
		}
		catch (Exception exception)
		{
			_loggerService.LogError(exception, "Failed to scroll to the job search form.", _jobSearchFormLocator);

			throw;
		}
	}

	private void ClearKeywordTextbox()
	{
		try
		{
			_driver.WaitUntilElementIsVisible(_keywordTextboxLocator,
				_webDriverService.GetConfiguration().LongTimeout,
				_webDriverService.GetConfiguration().PollingInterval);

			KeywordTextbox.Clear();
		}
		catch (Exception exception)
		{
			_loggerService.LogError(exception, "Failed to clear the keyword textbox.", _keywordTextboxLocator);

			throw;
		}
	}

	private void EnterKeyword(string keyword)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(keyword);

		try
		{
			ClearKeywordTextbox();

			KeywordTextbox.SendKeys(keyword);
		}
		catch (Exception exception)
		{
			_loggerService.LogError(exception, $"Failed to enter the keyword '{keyword}' into the keyword textbox.", _keywordTextboxLocator);

			throw;
		}
	}

	private void SelectSuggestion(string jobName)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(jobName);

		try
		{
			_driver.WaitUntilElementIsClickable(_suggestionListLocator,
				_webDriverService.GetConfiguration().LongTimeout,
				_webDriverService.GetConfiguration().PollingInterval);

			SuggestionList
				.First(element => element.Text.Contains(jobName, StringComparison.OrdinalIgnoreCase))
				.Click();
		}
		catch (Exception exception)
		{
			_loggerService.LogError(exception, $"Failed to select the suggestion '{jobName}'.", _suggestionListLocator);

			throw;
		}
	}

	private void ToggleLocationContainer(bool toggleOpen)
	{
		try
		{
			_driver.WaitUntilElementExists(_locationContainerLocator,
				_webDriverService.GetConfiguration().LongTimeout,
				_webDriverService.GetConfiguration().PollingInterval);

			var isOpen = LocationContainer.GetAttribute("class").Contains("select2-container--open");

			if (isOpen != toggleOpen)
			{
				ClickLocationContainerToggler();
			}
		}
		catch (Exception exception)
		{
			_loggerService.LogError(exception, "Failed to click the location textbox.", _locationContainerLocator);

			throw;
		}
	}

	private void ClickLocationContainerToggler()
	{
		try
		{
			_driver.WaitUntilElementIsClickable(_locationContainerTogglerLocator,
				_webDriverService.GetConfiguration().LongTimeout,
				_webDriverService.GetConfiguration().PollingInterval);

			LocationContainerToggler.Click();
		}
		catch (Exception exception)
		{
			_loggerService.LogError(exception, "Failed to click the location container toggler.", _locationContainerTogglerLocator);

			throw;
		}
	}

	private IWebElement GetLocationElement(string location)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(location);

		try
		{
			_driver.WaitUntilElementExists(_locationListLocator,
				_webDriverService.GetConfiguration().LongTimeout,
				_webDriverService.GetConfiguration().PollingInterval);

			return LocationList
				.First(element => element.Text.Trim()
					.Equals(location, StringComparison.OrdinalIgnoreCase));
		}
		catch (Exception exception)
		{
			_loggerService.LogError(exception, $"Failed to get the location '{location}'.", _locationListLocator);

			throw;
		}
	}

	private void SelectLocation(string location)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(location);

		try
		{
			var city = GetLocationElement(location);

			city.Click();

		}
		catch (Exception exception)
		{
			_loggerService.LogError(exception, $"Failed to select the location '{location}'.", _locationListLocator);

			throw;
		}
	}

	private void ToggleCountryList(string location, bool toggleOpen)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(location);

		try
		{
			var country = GetLocationElement(location)
				.FindElement(_locationParentLocator);

			var isOpen = country.GetAttribute("class").Contains("open");

			if (isOpen != toggleOpen)
			{
				country.Click();
			}
		}
		catch (Exception exception)
		{
			_loggerService.LogError(exception, $"Failed to click the country '{location}'.", _locationListLocator);

			throw;
		}
	}
}
