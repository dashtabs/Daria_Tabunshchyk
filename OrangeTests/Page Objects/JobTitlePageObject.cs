using OpenQA.Selenium;

namespace OrangeTests.Page_Objects
{
    class JobTitlePageObject
    {
        private IWebDriver _webDriver;
        private readonly By AddJobButton = By.XPath(".//*[@id='btnAdd']");
        private readonly By JobTitleTextBox = By.XPath(".//*[@id='jobTitle_jobTitle']");
        private readonly By JobDescrTextBox = By.XPath(".//*[@id='jobTitle_jobDescription']");
        private readonly By NoteTextBox = By.XPath(".//*[@id='jobTitle_note']");
        private readonly By SaveButton = By.XPath(".//*[@id='btnSave']");
        private readonly By element = By.XPath("//*[text()='Student']");
        private readonly By DeleteButton = By.XPath(".//*[@id='btnDelete']");
        private readonly By DialogDelBut = By.XPath(".//*[@id='dialogDeleteBtn']");

        public JobTitlePageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }
        public void ClickAdd()
        {
            _webDriver.FindElement(AddJobButton).Click();
        }
        public void AddName(string name)
        {
            _webDriver.FindElement(JobTitleTextBox).SendKeys(name);
        }
        public void AddDescr(string description)
        {
            _webDriver.FindElement(JobDescrTextBox).SendKeys(description);
        }
        public void AddNote(string note)
        {
            _webDriver.FindElement(NoteTextBox).SendKeys(note);
        }
        public void Click()
        {
            _webDriver.FindElement(SaveButton).Click();
        }
        public void ElementClick()
        {
            _webDriver.FindElement(element).Click();
        }
        public void EditClick()
        {
            _webDriver.FindElement(SaveButton).Click();
        }
        public void Clear()
        {
            _webDriver.FindElement(JobDescrTextBox).Clear();
        }
        public void newDescr(string descr)
        {
            _webDriver.FindElement(JobDescrTextBox).SendKeys(descr);
        }
        public void DeleteClick()
        {
            _webDriver.FindElement(DeleteButton).Click();
        }
        public void DeleteConfirm()
        {
            _webDriver.FindElement(DialogDelBut).Click();
        }
    }

}
