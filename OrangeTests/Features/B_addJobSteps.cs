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
    public class AddJobSteps
    {
        private LoginPageObject login;
        private JobTitlePageObject job;
        private IWebDriver driver = new OpenQA.Selenium.Chrome.ChromeDriver();

        [Given(@"I am logged in")]
        public void GivenIAmLoggedIn()
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
            login = new LoginPageObject(driver);
            login.Login("Admin");
            login.Password("admin123");
            login.loginClick();
        }
        
        [Given(@"I navigated to page (.*)")]
        public void GivenINavigatedToPage(string url)
        {
            driver.Navigate().GoToUrl(url);
            job = new JobTitlePageObject(driver);
        }
        
        [Given(@"I click the Add button")]
        public void GivenIClickTheAddButton()
        {
            job.ClickAdd();
        }
        
        [Given(@"I enter the title (.*)")]
        public void GivenIEnterTheTitleStudent(string name)
        {
            job.AddName(name);
        }
        
        [Given(@"I enter the description (.*)")]
        public void GivenIEnterTheDescription(string descr)
        {
            job.AddDescr(descr);
        }
        
        [Given(@"I enter the note (.*)")]
        public void GivenIEnterTheNote(string note)
        {
            job.AddNote(note);
        }
        
        [When(@"I click Save button")]
        public void WhenIClickSaveButton()
        {
            job.Click();
        }
        [AllureTag("CI")]
        [Then(@"The element with the title (.*) should be visible")]
        public void ThenTheElementShouldBeVisible(string title)
        {
            IWebElement element = driver.FindElement(By.XPath(string.Format("//*[contains(text(), " + title + ")]")));
            Assert.IsTrue(element.Displayed, "Title Student should be visible on the grid");
        }
    }
}
