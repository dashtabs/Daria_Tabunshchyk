# Selenium C# tests 

Checking https://opensource-demo.orangehrmlive.com/ website functionality. 

## Run tests
Open the project in Visual Studio. Open your test explorer. Features are named in alphabetical order, so you can just click `run all tests`. To generate the Allure report, you might need to install `Allure` and `scoop`.

## Allure
Open `Powershell` and type `allure serve` and path to your `Allure Results` folder. 

## Preparations
We work with a Page Object model. Here we need two classes: `JobTitlePageObject` and `LoginPageObject`. We don't work with other pages in this assignment. See the corresponding classes for the understanding of their applications.

We write the following to have the ability to use the script for any browser (but will use write ours for Chrome).
```C#
private IWebDriver driver;
```

## Task 0
##### Your script should login to the website using specified creditenals.
Username: `Admin`
Password: `admin123`

1. Please, use `A_Login.feature` to see the desirable result or an error result scenarios.
2. Go to `A_LogginInSteps.cs` to see the definition.

## Task 1
##### Add new job: Student or Intern.
For this and following steps, we need `JobTitlePageObject`.
Please, use `B_addJob.feature` to see the desirable outcome and the following step definition.

1. Go to Admin -> Job - Job Titles.
We use the `B_addJob.feature` for this purpose. .
2. Add job title. Add Job Description: free text up to 20 chars. Add note. Save changes.
This is implemented in `B_addJobSteps.cs`.

We create the following record.
Title:`Student`
Description:`Eat, sleep, study, repeat.`
Note:`Pls try not to die in the proccess`

We access elements via `XPath` by `id`. For example, with the `Save Button`:
```C#
IWebElement SaveButton = driver.FindElement(By.XPath(".//*[@id='btnSave']"));
```

## Task 2
##### Check newly added title is visible on the grid.
This is also implemented in `B_addJobSteps.cs` via `Assert`. We find our newly added title (titles are unique).
```C#
[Then(@"The element with the title (.*) should be visible")]
        public void ThenTheElementShouldBeVisible(string title)
        {
            IWebElement element = driver.FindElement(By.XPath(string.Format("//*[contains(text(), " + title + ")]")));
            Assert.IsTrue(element.Displayed, "Title Student should be visible on the grid");
        }
```

## Task 3
##### Modify your Job Title (select your field -> click on the Edit button).
See the `C_editJob.feature` and `C_editJobSteps.cs`
We change the description to `Sleepy`.

## Task 4
##### Check that your changes are visible on the Job Title page.
That's what the `Assert` in `C_editJobSteps.cs` is responsible for.
```
[Then(@"The element with the description (.*) should be visible")]
        public void ThenTheElementWithTheDescription(string description)
        {
            IWebElement element = driver.FindElement(By.XPath(string.Format("//*[contains(text(), " + description + ")]")));
            Assert.IsTrue(element.Displayed, "Description Sleepy should be visible on the grid");
        }
```

## Task 5
##### Select your field, click the Remove button.
The interesting part is in selecting a field we know very little about. Implement as follows in:
```C#
IWebElement element = driver.FindElement(By.XPath("//td[@class='left']/a[text()='Student']"));
IWebElement row = element.FindElement(By.XPath("./../.."));
row.FindElement(By.XPath("td[1]/input")).Click();
```

## Task 6
#####  Make sure your field is removed.
```C#
[Then(@"The element with the title (.*) should be deleted")]
        public void ThenTheElementShouldBeDeleted(string name)
        {
            Boolean exist = driver.FindElements(By.XPath(string.Format("//*[contains(text(), " + name + ")]"))).Count == 0;
            Assert.IsFalse(exist, "Title Student shouldn't be visible on the grid");
        }
```




