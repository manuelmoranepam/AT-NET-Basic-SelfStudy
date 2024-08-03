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
	private readonly By _locationListLocator = By.XPath("//ul[@id = 'select2-new_form_job_search-location-results' and contains(@class, 'open')]//li[contains(@id, 'select2-new_form_job_search-location-result')]");
	private readonly By _locationParentLocator = By.XPath("./parent::ul");
	private readonly By _skillsContainerTogglerLocator = By.XPath("//form[@id = 'jobSearchFilterForm']//div[contains(@class, 'job-search__departments')]");
	private readonly By _skillListLocator = By.XPath("//div[contains(@class, 'multi-select-dropdown-container')]/div[not(contains(@class, ' hidden'))]//span[contains(@class, 'checkbox-custom-label')]");
	private readonly By _remoteCheckboxLocator = By.XPath("//input[@type = 'checkbox' and contains(@name, 'remote')]");
	private readonly By _remoteCheckboxLabel = By.XPath("//label[contains(@class, 'checkbox-custom-label') and contains(@for, 'remote')]");
	private readonly By _officeCheckboxLocator = By.XPath("//input[@type = 'checkbox' and contains(@name, 'office')]");
	private readonly By _officeCheckboxLabel = By.XPath("//label[contains(@class, 'checkbox-custom-label') and contains(@for, 'office')]");
	private readonly By _relocationCheckboxLocator = By.XPath("//input[@type = 'checkbox' and contains(@name, 'relocation')]");
	private readonly By _relocationCheckboxLabel = By.XPath("//label[contains(@class, 'checkbox-custom-label') and contains(@for, 'relocation')]");
	private readonly By _findButtonLocator = By.XPath("//form[@id = 'jobSearchFilterForm']/button[@type = 'submit']");
	private readonly By _viewAndApplyLinkListLocator = By.XPath("//a[contains(@class, 'search-result__item-apply-')]");

	private IWebElement JobSearchForm => _driver.FindElement(_jobSearchFormLocator);
	private IWebElement KeywordTextbox => _driver.FindElement(_keywordTextboxLocator);
	private IList<IWebElement> SuggestionList => _driver.FindElements(_suggestionListLocator);
	private IWebElement LocationContainer => _driver.FindElement(_locationContainerLocator);
	private IWebElement LocationContainerToggler => _driver.FindElement(_locationContainerTogglerLocator);
	private IList<IWebElement> LocationList => _driver.FindElements(_locationListLocator);
	private IWebElement SkillsContainerToggler => _driver.FindElement(_skillsContainerTogglerLocator);
	private IList<IWebElement> SkillList => _driver.FindElements(_skillListLocator);
	private IWebElement RemoteHiddenCheckbox => _driver.FindElement(_remoteCheckboxLocator);
	private IWebElement RemoteCheckboxLabel => _driver.FindElement(_remoteCheckboxLabel);
	private IWebElement FindButton => _driver.FindElement(_findButtonLocator);
	private IWebElement OfficeHiddenCheckbox => _driver.FindElement(_officeCheckboxLocator);
	private IWebElement OfficeCheckboxLabel => _driver.FindElement(_officeCheckboxLabel);
	private IWebElement RelocationHiddenCheckbox => _driver.FindElement(_relocationCheckboxLocator);
	private IWebElement RelocationCheckboxLabel => _driver.FindElement(_relocationCheckboxLabel);
	private IList<IWebElement> ViewAndApplyLinkList => _driver.FindElements(_viewAndApplyLinkListLocator);
}
