using System;
using TechTalk.SpecFlow;
using OrangeTests.Page_Objects;
using OpenQA.Selenium;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Allure.Core;
using NUnit.Allure.Attributes;

namespace OrangeTests.Features
{
    [TestFixture]
    [AllureNUnit]
    [Binding]
    public class LoggingInSteps
    {
        private LoginPageObject login;
        private IWebDriver driver = new OpenQA.Selenium.Chrome.ChromeDriver();
        [Given(@"I go to url")]
        public void GivenIAmTryingToLogIn()
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
            login = new LoginPageObject(driver);
        }
        [Given(@"The login is (.*)")]
        public void GivenTheLoginIs(string p0)
        {
            login.Login(p0);
        }
        
        [Given(@"The password is (.*)")]
        public void GivenThePasswordIs(string p0)
        {
            login.Password(p0);
        }
        
        [When(@"I press LOGIN")]
        public void IPressLOGIN()
        {
            login.loginClick();
        }
        [AllureTag("CI")]
        [Then(@"The link should be (.*)")]
        public void TheLinkShouldBe(string p0)
        {
            var actual = driver.Url;
            Assert.True(actual == p0);
        }
        [AllureTag("CI")]
        [Then(@"I shoud see (.*)")]
        public void ThenIShoudSeeAn(string p0)
        {
            Assert.True(login.Error() == "Invalid credentials");
        }
    }
}
