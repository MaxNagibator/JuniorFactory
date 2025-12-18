using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumConsoleApp
{
    internal class MyBrowser : IDisposable
    {
        IWebDriver driver = new ChromeDriver();

        public void Dispose()
        {
            driver.Close();
            driver.Dispose();
        }

        public void Login()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://money.bob217.ru/");
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement passwordField = wait.Until(d =>
                    d.FindElement(By.CssSelector(".mud-nav-link.mud-ripple")));

                var elements = driver.FindElements(By.CssSelector(".mud-nav-link.mud-ripple"));
                elements[1].Click();
            }
            catch (ElementNotInteractableException ex)
            {
                // todo можно сделать без ошибки, а просто проверить видимость
                var elements = driver.FindElements(By.CssSelector(".mud-button-root.mud-icon-button"));
                elements[0].Click();

                var elements2 = driver.FindElements(By.CssSelector(".mud-nav-link.mud-ripple"));
                elements2[1].Click();
            }

            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            //IWebElement passwordField = wait.Until(d =>
            //    d.FindElement(By.XPath("//input[@type='password']")));

            var login = driver.FindElement(By.CssSelector(".mud-input-slot.mud-input-root.mud-input-root-text"));
            var password = driver.FindElement(By.XPath("//input[@type='password']"));
            login.SendKeys("demo");
            password.SendKeys("123123");

            Thread.Sleep(1000);
            var loginBtn = driver.FindElement(By.XPath("//button[@type='submit']"));
            loginBtn.Click();
        }

        internal void CreateOperation(string comment, int sum)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement passwordField = wait.Until(d =>
                d.FindElement(By.CssSelector(".mud-nav-link.mud-ripple")));

            ClickByXpath("(//*[contains(@class, 'mud-button-root') and contains(@class, 'mud-button')])[18]");

            driver.FindElement(By.CssSelector(".mud-input-slot.mud-input-root.mud-input-root-text")).SendKeys(sum.ToString());
            driver.FindElements(By.CssSelector(".mud-input-slot.mud-input-root.mud-input-root-text"))[4].Click();
            driver.FindElement(By.CssSelector(".mud-list-item")).Click();
            //driver.FindElements(By.CssSelector(".mud-input-slot.mud-input-root.mud-input-root-text"))[8].Click();
            driver.FindElements(By.CssSelector(".mud-input-slot.mud-input-root.mud-input-root-text"))[8].SendKeys(comment);
            Thread.Sleep(1000);
            var btn = driver.FindElements(By.CssSelector(".mud-button-root.mud-button.mud-button-filled"))[0];
            btn.Click();
            Thread.Sleep(1000);
        }

        private void ClickByXpath(string xpath)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement passwordField = wait.Until(d =>
                d.FindElement(By.XPath(xpath)));

            var createOpeartionBtn = driver.FindElement(By.XPath(xpath));
            createOpeartionBtn.Click();
        }
    }
}
