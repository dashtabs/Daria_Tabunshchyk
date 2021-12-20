using OpenQA.Selenium;

namespace OrangeTests.Page_Objects
{
    class LoginPageObject
    {
        private IWebDriver _webDriver;
        private readonly By emailTextBox = By.XPath(".//*[@id='txtUsername']");
        private readonly By passwordTextBox = By.XPath(".//*[@id='txtPassword']");
        private readonly By signUpButton = By.XPath(".//*[@id='btnLogin']");

        public LoginPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
        public void Login(string email)
        {
            _webDriver.FindElement(emailTextBox).SendKeys(email);
        }
        public void Password(string password)
        {
            _webDriver.FindElement(passwordTextBox).SendKeys(password);
        }
        public void loginClick()
        {
            _webDriver.FindElement(signUpButton).Click();
        }
        public string Error()
        {
            return "Invalid credentials";
        }
    }
}
