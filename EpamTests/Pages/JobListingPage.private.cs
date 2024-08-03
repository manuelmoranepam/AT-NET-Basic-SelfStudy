using System;
using WebDriverLibrary.Extensions;

namespace EpamTests.Pages;

public partial class JobListingPage
{
	private string GetJobTitleHeading()
	{
		try
		{
			_driver.WaitUntilElementIsVisible(_jobTitleHeadingLocator,
				_webDriverService.GetConfiguration().LongTimeout,
				_webDriverService.GetConfiguration().PollingInterval);

			return JobTitleHeading.Text;
		}
		catch (Exception exception)
		{
			_loggerService.LogError(exception, "Failed to get the job title heading.", _jobTitleHeadingLocator);

			throw;
		}
	}
}
