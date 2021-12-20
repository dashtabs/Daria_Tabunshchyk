using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OrangeTests.Page_Objects;
using TechTalk.SpecFlow;

namespace OrangeTests.Features
{
    [TestFixture]
    [AllureNUnit]
    [Binding]
    public class EditJobSteps
    {
        private LoginPageObject login;
        private JobTitlePageObject job;
        private IWebDriver driver = new OpenQA.Selenium.Chrome.ChromeDriver();

        [Given(@"I have logged in")]
        public void GivenIAmLoggedIn()
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
            login = new LoginPageObject(driver);
            login.Login("Admin");
            login.Password("admin123");
            login.loginClick();
        }
        [Given(@"I navigate to page (.*)")]
        public void GivenINavigatedToPage(string url)
        {
            driver.Navigate().GoToUrl(url);
            job = new JobTitlePageObject(driver);
        }
        [Given(@"I click on the name")]
        public void GivenIClickOnTheName()
        {
            job.ElementClick();
        }
        [Given(@"I click Edit")]
        public void GivenIClickEdit()
        {
            job.EditClick();
        }
        [Given(@"I clear the description")]
        public void GivenIClearTheDescription()
        {
            job.Clear();
        }
        [Given(@"I write the description (.*)")]
        public void GivenIEnterTheDescription(string description)
        {
            job.newDescr(description);
        }
        [When(@"I click Save")]
        public void WhenIClickSaveButton()
        {
            job.EditClick();
        }
        [AllureTag("CI")]
        [Then(@"The element with the description (.*) should be visible")]
        public void ThenTheElementWithTheDescription(string description)
        {
            IWebElement element = driver.FindElement(By.XPath(string.Format("//*[contains(text(), " + description + ")]")));
            Assert.IsTrue(element.Displayed, "Description Sleepy should be visible on the grid");
        }
    }
}
