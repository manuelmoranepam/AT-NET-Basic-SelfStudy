using OpenQA.Selenium;
using System.Collections.Generic;

namespace EpamTests.Pages;

public partial class CareersPage
{
	private readonly By _jobSearchFormLocator = By.Id("jobSearchFilterForm");
	private readonly By _keywordTextboxLocator = By.Id("new_form_job_search-keyword");
	private readonly By _suggestionListLocator = By.XPath("//div[contains(@class, 'autocomplete-suggestions') and not(contains(@style, 'display: none;'))]/div[contains(@class, 'autocomplete-suggestion')]");
	private readonly By _locationContainerLocator = By.CssSelector("span.select2-container");
	private readonly By _locationContainerTogglerLocator = By.ClassName("select2-selection__arrow");
	private readonly By _locationListLocator = By.XPath("//li[contains(@id, 'select2-new_form_job_search-location-result')]");
	private readonly By _locationParentLocator = By.XPath("./parent::ul");

	private IWebElement JobSearchForm => _driver.FindElement(_jobSearchFormLocator);
	private IWebElement KeywordTextbox => _driver.FindElement(_keywordTextboxLocator);
	private IList<IWebElement> SuggestionList => _driver.FindElements(_suggestionListLocator);
	private IWebElement LocationContainer => _driver.FindElement(_locationContainerLocator);
	private IWebElement LocationContainerToggler => _driver.FindElement(_locationContainerTogglerLocator);
	private IList<IWebElement> LocationList => _driver.FindElements(_locationListLocator);
}
