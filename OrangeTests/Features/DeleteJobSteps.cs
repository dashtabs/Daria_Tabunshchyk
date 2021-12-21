using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OrangeTests.Page_Objects;
using System;
using TechTalk.SpecFlow;

namespace OrangeTests.Features
{
    [TestFixture]
    [AllureNUnit]
    [Binding]
    public class DeleteJobSteps
    {
        private LoginPageObject login;
        private JobTitlePageObject job;
        private IWebDriver driver = new OpenQA.Selenium.Chrome.ChromeDriver();

        [Given(@"I am already logged in")]
        public void GivenIAmAlreadyLoggedIn()
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
            login = new LoginPageObject(driver);
            login.Login("Admin");
            login.Password("admin123");
            login.loginClick();
        }
        
        [Given(@"I have navigated to page (.*)")]
        public void GivenIHaveNavigatedToPage(string url)
        {
            driver.Navigate().GoToUrl(url);
            job = new JobTitlePageObject(driver);
        }
        
        [Given(@"I click on the checkbox of Student element")]
        public void GivenIClickOnTheCheckbox()
        {
            IWebElement element = driver.FindElement(By.XPath("//td[@class='left']/a[text()='Student']"));
            IWebElement row = element.FindElement(By.XPath("./../.."));
            row.FindElement(By.XPath("td[1]/input")).Click();
        }
        
        [Given(@"I click Delete")]
        public void GivenIClickDelete()
        {
            job.DeleteClick();
        }
        
        [When(@"I click OK")]
        public void WhenIClickOK()
        {
            job.DeleteConfirm();
        }
        [AllureTag("CI")]
        [Then(@"The element with the title (.*) should be deleted")]
        public void ThenTheElementShouldBeDeleted(string name)
        {
            Boolean exist = driver.FindElements(By.XPath(string.Format("//*[contains(text(), " + name + ")]"))).Count == 0;
            Assert.IsFalse(exist, "Title " + name + " shouldn't be visible on the grid");
        }
    }
}
